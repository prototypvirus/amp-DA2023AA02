//
// Created by symbx on 01.01.19.
//

#include "pt2322.h"
#include <algorithm>

PT2322::PT2322(Wire *wire) {
    this->_wire = wire;
}

int PT2322::write(char b) {
    // write byte to bus
    this->_wire->begin(this->ADDRESS);
    int result = this->_wire->write(b);
    this->_wire->end();
    return result;
}

bool PT2322::reset() {
    // send reset command
    return this->write(this->SYS_RESET) == 0;
}

void PT2322::input() {
    // send input sw command
    this->write(this->INPUT_SW);
}

byte PT2322::setVolume(byte vol) {
    // set volume in range 0-MAX_VOLUME, and reverse
    vol = this->MAX_VOLUME - std::max<byte>(std::min<byte>(vol, this->MAX_VOLUME), 0);
    // split 10-steps and 1-steps
    byte bits = (byte) ((vol / 10) << 4);
    bits |= bits % 10;
    this->_wire->begin(this->ADDRESS);
    this->_wire->write(this->VOL_STEP_10 | (byte)((bits & 0xF0) >> 4));
    this->_wire->write(this->VOL_STEP_01 | (byte)(bits & 0x0F));
    this->_wire->end();
    return this->MAX_VOLUME - vol;
}

byte PT2322::trimChannel(Channel channel, byte trim) {
    // set trim in range 0-MAX_TRIM
    trim = std::max<byte>(std::min<byte>(trim, this->MAX_TRIM), 0);
    // remove first 4 bits
    trim &= 0x0F;
    // set channel
    trim |= (byte) channel;
    this->write(trim);
    return (byte) (trim & 0x0F);
}

byte PT2322::setTone(Tone tone, byte val) {
    // set tone in range MIN_TONE-MAX_TONE, and reverse
    val = std::max<byte>(std::min<byte>(val, (byte) (this->MAX_TONE * 2)), 0);
    // copy sign to result
    byte sign = 1;
    if(val < this->MAX_TONE)
        sign = 0;
    else
        val -= this->MAX_TONE;
    val /= 2;
    if(sign)
        val = (byte) ((this->MAX_TONE / 2) - val);
    this->write(tone | (sign << 3) | (val & 0x07));
    return (byte) (sign ? (this->MAX_TONE + ((this->MAX_TONE / 2) - val) * 2) : (val * 2));
}

void PT2322::turnFunctions(bool tone, bool is3d, bool mute) {
    byte res = 0;
    // Set bits of functions
    if(!tone) // (tone) - tone defeat else tone control
        res |= 0x02;
    if(!is3d) //  (is3d) - 3d is off else 3d is on
        res |= 0x04;
    if(mute) // (mute) - mute on else mute off
        res |= 0x08;
    this->write(FUNCTION | res);
}
