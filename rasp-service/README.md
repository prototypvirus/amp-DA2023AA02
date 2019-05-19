Controller for sound amplifier #DA2023AA02.
================
Building:
```
git clone https://github.com/prototypvirus/amp-DA2023AA02.git
mkdir rpi-kodi-amp/build
cd rpi-kodi-amp/build
cmake ..
make
```

Add application to startup as service (for example to systemctl services) with rights to write to i2c bus.
***Attention:*** If you want build not for Raspberry PI 2 please change i2c bus number in _amplifier.cpp_ for you version.

For controlling can use Kodi [plugin](https://github.com/prototypvirus/amp-DA2023AA02/tree/master/script.amplifier).