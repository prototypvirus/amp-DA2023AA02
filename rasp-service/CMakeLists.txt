cmake_minimum_required(VERSION 3.12)
project(amplifier)

set(CMAKE_CXX_STANDARD 14)

add_executable(amplifier main.cpp lib/wire.cpp lib/wire.h controller/pt2322.cpp controller/pt2322.h controller/pt2323.cpp controller/pt2323.h amplifier.cpp amplifier.h)