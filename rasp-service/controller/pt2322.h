//
// Created by symbx on 01.01.19.
//

#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wconversion"
#ifndef AMPLIFIER_PT2322_H
#define AMPLIFIER_PT2322_H

#include "../lib/wire.h"

class PT2322 {
public:
    enum Tone {
        Bass = 0x90,
        Middle = 0xA0,
        Treble = 0xB0
    };
    enum Channel {
        FrontLeft = 0x10,
        FrontRight = 0x20,
        Center = 0x30,
        RearLeft = 0x40,
        RearRight = 0x50,
        Subwoofer = 0x60
    };
    explicit PT2322(Wire* wire);
    bool reset();
    void input();
    byte setVolume(byte vol);
    byte trimChannel(Channel channel, byte trim);
    byte setTone(Tone tone, byte val);
    void turnFunctions(bool tone, bool is3d, bool mute);

    const byte MAX_VOLUME = 79;
    const byte MAX_TRIM = 15;


protected:
    /* CONSTANTS */
    const byte ADDRESS = 0x44; /* 0x88 >> 1 */
    const byte FUNCTION = 0x70; /* 0b0111xxxx | x -function bit */
    const byte INPUT_SW = 0xC7;
    const byte VOL_STEP_01 = 0xD0;
    const byte VOL_STEP_10 = 0xE0;
    const byte SYS_RESET = 0xFF;
    const byte MAX_TONE = 14;
    const byte MIN_TONE = -14;

    Wire* _wire;
    int write(char b);
};


#endif //AMPLIFIER_PT2322_H

#pragma clang diagnostic pop