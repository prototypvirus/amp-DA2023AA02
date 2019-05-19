//
// Created by symbx on 01.01.19.
//

#include <fstream>
#include <iostream>
#include <sys/stat.h>
#include <unistd.h>
#include <sys/socket.h>
#include <sys/un.h>
#include "amplifier.h"

Amplifier::Amplifier() {
    this->_wire = new Wire(1); // 1 - raspberry pi 2
    this->_processor = new PT2322(this->_wire);
    this->_selector = new PT2323(this->_wire);
    this->_volume = (byte) (this->_processor->MAX_VOLUME / 2);
    for (byte &i : this->_trim)
        i = 0;
    for (byte &i : this->_tone)
        i = 0;
    for (bool &i : this->_mute)
        i = false;
    this->_input = PT2323::Direct;
    this->_funcs = 0x03;
}

Amplifier::~Amplifier() {
    delete this->_selector;
    delete this->_processor;
    delete this->_wire;
}

void Amplifier::load() {
    std::string path = this->getConfigPath();
    std::ifstream file(path);
    if (file.fail()) {
        std::cout << "Does not have config file, save default." << std::endl;
        return;
    }
    file.read(&this->_volume, sizeof(byte));
    file.read(&this->_funcs, sizeof(byte));
    file.read((char*) &this->_input, sizeof(PT2323::InputLine));
    file.read(this->_trim, sizeof(byte) * 6);
    file.read(this->_tone, sizeof(byte) * 3);
    file.read((char*) this->_mute, sizeof(bool) * 7);
    file.close();
}

void Amplifier::save() {
    std::string path = this->getConfigPath();
    std::ofstream file(path);
    if (file.fail()) {
        std::cout << "Can't save config file." << std::endl;
        return;
    }
    file.write(&this->_volume, sizeof(byte));
    file.write(&this->_funcs, sizeof(byte));
    file.write((char*) &this->_input, sizeof(PT2323::InputLine));
    file.write(this->_trim, sizeof(byte) * 6);
    file.write(this->_tone, sizeof(byte) * 3);
    file.write((char*) this->_mute, sizeof(bool) * 7);
    file.flush();
    file.close();
}

const std::string Amplifier::getConfigPath() {
    char* home = getenv("HOME");
    std::string path(home);
    path.append("/.config");
    struct stat sb{};
    if(stat(path.c_str(), &sb) != 0)
        mkdir(path.c_str(), S_IRWXU);
    path.append("/amplifier.bcfg");
    return path;
}

bool Amplifier::init() {
    usleep(500000); // wait for initialization (500ms, min 300ms)
    std::cout << "Check..." << std::endl;
    if(!this->_processor->reset())
        return true;
    std::cout << "Data sent... may be amplifier online" << std::endl;

    this->_processor->input();
    this->_processor->setVolume(this->_volume);
    this->_selector->setInput(this->_input);

    this->_processor->turnFunctions((this->_funcs & 0x01) > 0, (this->_funcs & 0x02) > 0, (this->_funcs & 0x04) > 0);
    this->_selector->surround((this->_funcs & 0x08) > 0);
    this->_selector->mixChannels((this->_funcs & 0x10) > 0);

    this->_processor->trimChannel(PT2322::FrontLeft, this->_trim[0]);
    this->_processor->trimChannel(PT2322::FrontRight, this->_trim[1]);
    this->_processor->trimChannel(PT2322::Center, this->_trim[2]);
    this->_processor->trimChannel(PT2322::RearLeft, this->_trim[3]);
    this->_processor->trimChannel(PT2322::RearRight, this->_trim[4]);
    this->_processor->trimChannel(PT2322::Subwoofer, this->_trim[5]);

    this->_processor->setTone(PT2322::Bass, this->_tone[0]);
    this->_processor->setTone(PT2322::Middle, this->_tone[1]);
    this->_processor->setTone(PT2322::Treble, this->_tone[2]);

    this->_selector->mute(PT2323::FrontLeft, this->_mute[0]);
    this->_selector->mute(PT2323::FrontRight, this->_mute[1]);
    this->_selector->mute(PT2323::Center, this->_mute[2]);
    this->_selector->mute(PT2323::Subwoofer, this->_mute[3]);
    this->_selector->mute(PT2323::SideLeft, this->_mute[4]);
    this->_selector->mute(PT2323::SideRight, this->_mute[5]);
    this->_selector->mute(PT2323::All, this->_mute[6]);
    return false;
}

void Amplifier::run() {
    this->load();
    while(this->init()) {
        std::cout << "Wait for amplifier become online..." << std::endl;
        usleep(5000000); // 5s
    }
    this->_pipe = socket(AF_UNIX, SOCK_STREAM, 0);
    remove("/tmp/amplifier.pipe");
    struct sockaddr_un saddr = {AF_UNIX, "/tmp/amplifier.pipe"};
    bind(this->_pipe, (struct sockaddr*) &saddr, sizeof(saddr));
    listen(this->_pipe, 4);
    while(true) {
        int connection = accept(this->_pipe, nullptr, nullptr);
        bool out = false;
        byte* buffer = new byte[2];
        while(true) {
            ssize_t res = read(connection, buffer, 2);
            if(res < 2) {
                close(connection);
                break;
            }
            out = this->process(connection, buffer[0], buffer[1]);
        }
        delete[] buffer;
        if(out)
            break;
    }
    remove("/tmp/amplifier.pipe");
}

bool Amplifier::process(int connection, byte cmd, byte arg) {
    switch(cmd) {
        case VolumeSet:
            this->setVolume(arg);
            return false;
        case VolumeGet:
            this->response(connection, this->_volume);
            return false;
        case TrimSet:
            this->setTrim(arg >> 4, (byte) (arg & 0x0F));
            return false;
        case TrimGet:
            this->response(connection, this->_trim[arg]);
            return false;
        case ToneSet:
            this->setTone(arg >> 5, (byte) (arg & 0x1F));
            return false;
        case ToneGet:
            this->response(connection, this->_tone[arg]);
            return false;
        case FunctionSet:
            this->useFunction(arg >> 1, (arg & 0x01) > 0);
            return false;
        case FunctionGet:
            this->response(connection, (byte) ((this->_funcs & arg) > 0 ? 1 : 0));
            return false;
        case MuteSet:
            this->setMute(arg >> 1, (arg & 0x01) > 0);
            return false;
        case MuteGet:
            this->response(connection, this->_mute[arg]);
            return false;
        case Initialize:
            this->init();
            return false;
        case Exit:
            return true;
        case FuncGetAll:
            this->response(connection, this->_funcs);
            return false;
        case InputSet:
            this->setInput(arg);
            return false;
        case InputGet:
            this->response(connection, this->_input - 7);
            return false;
        default:
            std::cout << "Requested unknown command " << +cmd << '(' << +arg << ");" << std::endl;
            return false;
    }
}

void Amplifier::response(int connection, byte val) {
    write(connection, &val, sizeof(byte));
}

void Amplifier::setVolume(byte vol) {
    this->_volume = this->_processor->setVolume(vol);
    this->save();
}

void Amplifier::setTrim(byte channel, byte trim) {
    if(channel < 0 || channel > 5)
        return;
    this->_trim[channel] = this->_processor->trimChannel((PT2322::Channel) ((channel + 1) << 4), trim);
    this->save();
}

void Amplifier::setTone(byte tone, byte val) {
    if(tone < 0 || tone > 2)
        return;
    this->_tone[tone] = this->_processor->setTone((PT2322::Tone) (0x80 | (tone << 4)), val);
    this->save();
}

void Amplifier::useFunction(byte func, bool on) {
    if(on)
        this->_funcs |= func;
    else
        this->_funcs &= ~func;
    this->save();

    this->_processor->turnFunctions((this->_funcs & 0x01) > 0, (this->_funcs & 0x02) > 0, (this->_funcs & 0x04) > 0);
    this->_selector->surround((this->_funcs & 0x08) > 0);
    this->_selector->mixChannels((this->_funcs & 0x10) > 0);
}

void Amplifier::setMute(byte channel, bool on) {
    this->_mute[channel] = on;
    if(channel == 6)
        channel++;
    this->_selector->mute((PT2323::Channel) (channel << 1), on);
    this->save();
}

void Amplifier::setInput(byte channel) {
    this->_input = (PT2323::InputLine) (channel + 7);
    this->save();
    this->_selector->setInput(this->_input);
}
