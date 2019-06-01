using System;
using System.IO.Ports;
using System.Threading;

namespace AmplifierGUI
{
    public class Controller : IDisposable
    {
        private readonly SerialPort _serial;

        public Controller(string port)
        {
            _serial = new SerialPort(port, 9600);
            Initialized = false;
            _serial.Open();
        }

        public bool IsOpen => _serial.IsOpen;

        public bool Initialized { get; private set; }
        
        private void Send(Command cmd, byte arg1 = 0, byte arg2 = 0)
        {
            Send((byte) cmd, arg1, arg2);
        }
        private void Send(byte cmd, byte arg1 = 0, byte arg2 = 0)
        {
            _serial.Write(new[] { cmd, arg1, arg2 }, 0, 3);
        }

        public bool Initialize()
        {
            try
            {
                Thread.Sleep(300);
                Initialized = false;
                Send(Command.Initialize);
                byte res = (byte) _serial.ReadByte();
                if (res < 1)
                    return false;
                SetVolume(Properties.Settings.Default.Volume);
                for (int i = 0; i < 3; i++)
                {
                    SetTone((Tone) i, Properties.Settings.Default.Tone[i]);
                }

                for (int i = 0; i < 6; i++)
                {
                    SetTrim((Channel) i, Properties.Settings.Default.Trim[i]);
                }

                SetFunctions(GetFunctions());
                SetInput(GetInput());
                Initialized = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetVolume(byte v)
        {
            Properties.Settings.Default.Volume = v;
            v = (byte) (79 - v);
            Send(Command.Volume, (byte) (v / 10), (byte) (v % 10));
            Properties.Settings.Default.Save();
        }

        public void SetTrim(Channel c, byte v)
        {
            Properties.Settings.Default.Trim[(int)c] = v;
            v = (byte) (15 - v);
            Send(Command.Trim, (byte) (((int) c + 1) << 4), v);
            Properties.Settings.Default.Save();
        }

        public void SetTone(Tone type, byte v)
        {
            Properties.Settings.Default.Tone[(int)type] = v;
            v = (v > 7) ? (byte) ((15 - v) | 8) : v;
            Send(Command.Tone, (byte) (((int)type + 9) << 4), v);
            Properties.Settings.Default.Save();
        }

        public void SetFunctions(Functions fs)
        {
            Properties.Settings.Default.Functions = (byte)fs;
            Send(Command.Functions, (byte) fs);
            Properties.Settings.Default.Save();
        }

        public void SetInput(byte i)
        {
            Properties.Settings.Default.Input = i;
            Send(Command.Input, (byte) (i + 7));
            Properties.Settings.Default.Save();
        }

        public byte GetVolume()
        {
            return Properties.Settings.Default.Volume;
        }

        public byte GetTrim(Channel c)
        {
            return Properties.Settings.Default.Trim[(int) c];
        }

        public byte GetTone(Tone t)
        {
            return Properties.Settings.Default.Tone[(int) t];
        }

        public Functions GetFunctions()
        {
            return (Functions) Properties.Settings.Default.Functions;
        }

        public byte GetInput()
        {
            return Properties.Settings.Default.Input;
        }

        public void Dispose()
        {
            _serial?.Dispose();
        }
    }

    public enum Command : byte
    {
        Initialize = 1,
        Volume = 2,
        Trim = 3,
        Tone = 4,
        Functions = 5,
        Input = 6
    }

    public enum Channel : byte
    {
        FrontLeft = 0,
        FrontRight = 1,
        Center = 2,
        RearLeft = 3,
        RearRight = 4,
        SubWoofer = 5
    }

    public enum Tone : byte
    {
        Bass = 0,
        Middle = 1,
        Treble = 2
    }

    [Flags]
    public enum Functions : byte
    {
        None = 0,
        EnchancedSurround = 0x01,
        MixChannels = 0x02,
        ToneDefeat = 0x04,
        _3D = 0x08,
        Mute = 0x10
    }
}