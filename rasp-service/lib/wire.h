//
// Created by symbx on 01.01.19.
//
#include <sys/ioctl.h>

#ifndef AMPLIFIER_WIRE_H
#define AMPLIFIER_WIRE_H

typedef char byte;

class Wire {
public:
    //Create i2c bus [bus - 0(rpi1)|1(rpi2)]
    Wire(int bus);
    //Destruct object (close if not closed)
    ~Wire();
    //open (auto)
    int open();
    //close (auto)
    void close();
    //begin transmission
    int begin(byte addr);
    //write byte to i2c
    int write(byte val);
    //end transmission
    int end();

protected:
    int _bus;
    int _fd;
    byte _addr;
};


#endif //AMPLIFIER_WIRE_H
