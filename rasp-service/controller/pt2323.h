//
// Created by symbx on 01.01.19.
//

#pragma clang diagnostic push
#pragma ide diagnostic ignored "OCUnusedGlobalDeclarationInspection"
#pragma clang diagnostic ignored "-Wconversion"
#ifndef AMPLIFIER_PT2323_H
#define AMPLIFIER_PT2323_H

#include "../lib/wire.h"

class PT2323 {
public:
    enum InputLine {
        Direct = 0x07,
        Line4 = 0x08,
        Line3 = 0x09,
        Line2 = 0x0A,
        Line1 = 0x0B
    };

    enum Channel {
        FrontLeft = 0x00,
        FrontRight = 0x02,
        Center = 0x04,
        Subwoofer = 0x06,
        SideLeft = 0x08,
        SideRight = 0x0A,
        All = 0x0E
    };

    explicit PT2323(Wire* wire);
    void setInput(InputLine line);
    void surround(bool on);
    void mixChannels(bool on);
    void mute(Channel channel, bool on);

protected:
    const byte ADDRESS = 0x4A; /* 0x94 >> 1 */
    const byte SET_INPUT = 0xC0;
    const byte SURROUND = 0xD0;
    const byte MIX_CHNL = 0x90;
    const byte MUTE = 0xF0;
    Wire* _wire;
    int write(char b);
};


#endif //AMPLIFIER_PT2323_H

#pragma clang diagnostic pop