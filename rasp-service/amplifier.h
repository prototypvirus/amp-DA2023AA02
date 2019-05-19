//
// Created by symbx on 01.01.19.
//

#ifndef AMPLIFIER_AMPLIFIER_H
#define AMPLIFIER_AMPLIFIER_H

#include <string>
#include "lib/wire.h"
#include "controller/pt2322.h"
#include "controller/pt2323.h"

class Amplifier {
public:
    Amplifier();
    ~Amplifier();
    void run();

protected:
    Wire* _wire;
    PT2322* _processor;
    PT2323* _selector;
    byte _volume;
    byte _trim[6];
    byte _tone[3];
    byte _funcs;
    PT2323::InputLine _input;
    bool _mute[7];
    int _pipe;

    bool init();
    void load();
    void save();
    const std::string getConfigPath();
    bool process(int connection, byte cmd, byte arg);
    void response(int connection, byte val);
    void setVolume(byte vol);
    void setTrim(byte channel, byte trim);
    void setTone(byte tone, byte val);
    void useFunction(byte func, bool on);
    void setMute(byte channel, bool on);
    void setInput(byte channel);

    enum Command {
        VolumeSet = 1,
        VolumeGet = 2,
        TrimSet = 3,
        TrimGet = 4,
        ToneSet = 5,
        ToneGet = 6,
        FunctionSet = 7,
        FunctionGet = 8,
        MuteSet = 9,
        MuteGet = 10,
        Initialize = 11,
        Exit = 12,
        FuncGetAll = 13,
        InputGet = 14,
        InputSet = 15
    };
};


#endif //AMPLIFIER_AMPLIFIER_H
