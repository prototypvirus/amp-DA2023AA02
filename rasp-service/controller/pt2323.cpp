//
// Created by symbx on 01.01.19.
//

#include "pt2323.h"

PT2323::PT2323(Wire *wire) {
    this->_wire = wire;
}

int PT2323::write(char b) {
    // write byte to bus
    this->_wire->begin(this->ADDRESS);
    int result = this->_wire->write(b);
    this->_wire->end();
    return result;
}

void PT2323::setInput(PT2323::InputLine line) {
    this->write(SET_INPUT| line);
}

void PT2323::surround(bool on) {
    this->write(SURROUND | (byte) (on ? 0 : 1));
}

void PT2323::mixChannels(bool on) {
    this->write(MIX_CHNL | (byte) (on ? 1 : 0));
}

void PT2323::mute(PT2323::Channel channel, bool on) {
    this->write(MUTE | channel | (byte) (on ? 1 : 0));
}
