#include <iostream>
#include "amplifier.h"

int main() {
    auto * amp = new Amplifier();
    amp->run();
    delete amp;
    return 0;
}