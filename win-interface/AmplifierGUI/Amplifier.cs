using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;

namespace AmplifierGUI
{
    public partial class Amplifier : Form
    {
        private bool _visible;
        private Controller _controller;
        private ManagementEventWatcher _watcher;

        public Amplifier()
        {
            InitializeComponent();
            // Initialize default array settings
            if (Properties.Settings.Default.Tone == null || Properties.Settings.Default.Tone.Length == 0)
                Properties.Settings.Default.Tone = new byte[] { 7, 7, 7 };
            if (Properties.Settings.Default.Trim == null || Properties.Settings.Default.Trim.Length == 0)
                Properties.Settings.Default.Trim = new byte[] { 15, 15, 15, 15, 15, 15 };
            Properties.Settings.Default.Save();

            StartListening();
            Tag = Handle; // Just for creating form handle before showing it
            UpdatePorts();
            LoadStartConfig();
        }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPorts.SelectedIndex < 0)
                return;
            Properties.Settings.Default.Port = (string) comboBoxPorts.Items[comboBoxPorts.SelectedIndex];
            Properties.Settings.Default.Save();
            
            _controller?.Dispose();
            CreateController();
        }

        private void CreateController()
        {
            string[] ports = SerialPort.GetPortNames();
            
            if (ports.Any(p => p == Properties.Settings.Default.Port) && (_controller == null || !_controller.IsOpen))
            {
                _controller?.Dispose();
                notifyIconTray.ShowBalloonTip(1000, "Amplifier", "Connected", ToolTipIcon.Info);
                _controller = new Controller(Properties.Settings.Default.Port);
                Amplifier_Shown(this, EventArgs.Empty);
                timerInit.Start();
            }
        }

        private void Amplifier_Shown(object sender, EventArgs e)
        {
            if (_controller != null)
            {
                trackBarVolume.Value = _controller.GetVolume();
                trackBarToneBass.Value = _controller.GetTone(Tone.Bass);
                trackBarToneMiddle.Value = _controller.GetTone(Tone.Middle);
                trackBarToneTreble.Value = _controller.GetTone(Tone.Treble);
                trackBarTrimFL.Value = _controller.GetTrim(Channel.FrontLeft);
                trackBarTrimFR.Value = _controller.GetTrim(Channel.FrontRight);
                trackBarTrimRL.Value = _controller.GetTrim(Channel.RearLeft);
                trackBarTrimRR.Value = _controller.GetTrim(Channel.RearRight);
                trackBarTrimCT.Value = _controller.GetTrim(Channel.Center);
                trackBarTrimSW.Value = _controller.GetTrim(Channel.SubWoofer);
                Functions fs = _controller.GetFunctions();
                checkBoxEnchanced.Checked = (fs & Functions.EnchancedSurround) > 0;
                checkBox3D.Checked = (fs & Functions._3D) > 0;
                checkBoxMixChannels.Checked = (fs & Functions.MixChannels) > 0;
                checkBoxMute.Checked = (fs & Functions.Mute) > 0;
                comboBoxInput.SelectedIndex = _controller.GetInput();
            }
            else
            {

                if (comboBoxPorts.Items.Count > 0)
                {
                    if (comboBoxPorts.Items.IndexOf(Properties.Settings.Default.Port) >= 0)
                        comboBoxPorts.SelectedItem = Properties.Settings.Default.Port;
                    else
                        comboBoxPorts.SelectedIndex = 0;
                }

                checkBoxAutorun.Checked = RegistryKeyExists(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\Amplifier");
            }
        }

        private void AutoRun(bool add)
        {
            try
            {
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                    true);
                if (rkApp == null)
                    return;
                if (add)
                {
                    rkApp.SetValue("Amplifier", Application.ExecutablePath + " /min");
                }
                else
                {
                    rkApp.DeleteValue("Amplifier", false);
                }
            }
            catch
            {
                checkBoxAutorun.Checked = false;
                // ignore
            }
        }

        internal static bool RegistryKeyExists(string key, string val = "")
        {
            RegistryKey k = Registry.CurrentUser.OpenSubKey(key, false);
            return k?.GetValue(val) != null;
        }

        private void checkBoxAutorun_CheckedChanged(object sender, EventArgs e)
        {
            AutoRun(checkBoxAutorun.Checked);
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            _controller?.SetVolume((byte) trackBarVolume.Value);
        }

        private void trackBarToneBass_Scroll(object sender, EventArgs e)
        {
            _controller?.SetTone(Tone.Bass, (byte) trackBarToneBass.Value);
        }

        private void trackBarToneMiddle_Scroll(object sender, EventArgs e)
        {
            _controller?.SetTone(Tone.Middle, (byte) trackBarToneMiddle.Value);
        }

        private void trackBarToneTreble_Scroll(object sender, EventArgs e)
        {
            _controller?.SetTone(Tone.Treble, (byte) trackBarToneTreble.Value);
        }

        private void trackBarTrimFL_Scroll(object sender, EventArgs e)
        {
            _controller?.SetTrim(Channel.FrontLeft, (byte) trackBarTrimFL.Value);
        }

        private void trackBarTrimFR_Scroll(object sender, EventArgs e)
        {
            _controller?.SetTrim(Channel.FrontRight, (byte) trackBarTrimFR.Value);
        }

        private void trackBarTrimRL_Scroll(object sender, EventArgs e)
        {
            _controller?.SetTrim(Channel.RearLeft, (byte) trackBarTrimRL.Value);
        }

        private void trackBarTrimRR_Scroll(object sender, EventArgs e)
        {
            _controller?.SetTrim(Channel.RearRight, (byte) trackBarTrimRR.Value);
        }

        private void trackBarTrimCT_Scroll(object sender, EventArgs e)
        {
            _controller?.SetTrim(Channel.Center, (byte) trackBarTrimCT.Value);
        }

        private void trackBarTrimSW_Scroll(object sender, EventArgs e)
        {
            _controller?.SetTrim(Channel.SubWoofer, (byte) trackBarTrimSW.Value);
        }

        private void checkBoxFunction_CheckedChanged(object sender, EventArgs e)
        {
            Functions fs = Functions.None;
            if (checkBoxEnchanced.Checked)
                fs |= Functions.EnchancedSurround;
            if (checkBox3D.Checked)
                fs |= Functions._3D;
            if (checkBoxMixChannels.Checked)
                fs |= Functions.MixChannels;
            if (checkBoxMute.Checked)
                fs |= Functions.Mute;
            if (checkBoxToneDefeat.Checked)
                fs |= Functions.ToneDefeat;
            _controller?.SetFunctions(fs);
        }

        private void Amplifier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                _visible = false;
                notifyIconTray.Visible = true;
                return;
            }
            _controller?.Dispose();
            _watcher.Stop();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(_visible && value);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIconTray.Visible = false;
            Application.Exit();
        }

        private void notifyIconTray_DoubleClick(object sender, EventArgs e)
        {
            _visible = true;
            Show();
            notifyIconTray.Visible = false;
        }

        private void StartListening()
        {
            int platform = (int) Environment.OSVersion.Platform;
            if (platform == 4 || platform == 6 || platform == 128)
                return;
            _watcher = new ManagementEventWatcher {Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent")};
            _watcher.EventArrived += DevicesChanged;
            _watcher.Start();
        }

        private void DevicesChanged(object sender, EventArrivedEventArgs e)
        {
            Invoke(new Action(UpdatePorts));
        }

        private void UpdatePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.Clear();
            // ReSharper disable once CoVariantArrayConversion
            comboBoxPorts.Items.AddRange(ports);

            if (ports.Any(p => p == Properties.Settings.Default.Port))
            {
                if (_controller == null || !_controller.IsOpen)
                {
                    CreateController();
                }
            }
            else
            {
                if (_controller != null) {
                    notifyIconTray.ShowBalloonTip(1000, "Amplifier", "Disconnected", ToolTipIcon.Info);
                    _controller.Dispose();
                }
            }
        }

        private void timerInit_Tick(object sender, EventArgs e)
        {
            if (_controller != null && !_controller.Initialized && _controller.Initialize())
            {
                notifyIconTray.ShowBalloonTip(1000, "Amplifier", "Initialized", ToolTipIcon.Info);
                timerInit.Stop();
            }
        }

        private void comboBoxInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller?.SetInput((byte) comboBoxInput.SelectedIndex);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/prototypvirus/amp-DA2023AA02");
        }

        private void LoadStartConfig()
        {
            trackBarVolume.Value = Properties.Settings.Default.Volume;
            trackBarToneBass.Value = Properties.Settings.Default.Tone[(int) Tone.Bass];
            trackBarToneMiddle.Value = Properties.Settings.Default.Tone[(int) Tone.Middle];
            trackBarToneTreble.Value = Properties.Settings.Default.Tone[(int) Tone.Treble];
            trackBarTrimFL.Value = Properties.Settings.Default.Trim[(int) Channel.FrontLeft];
            trackBarTrimFR.Value = Properties.Settings.Default.Trim[(int) Channel.FrontRight];
            trackBarTrimRL.Value = Properties.Settings.Default.Trim[(int) Channel.RearLeft];
            trackBarTrimRR.Value = Properties.Settings.Default.Trim[(int) Channel.RearRight];
            trackBarTrimCT.Value = Properties.Settings.Default.Trim[(int) Channel.Center];
            trackBarTrimSW.Value = Properties.Settings.Default.Trim[(int) Channel.SubWoofer];
            Functions fs = (Functions) Properties.Settings.Default.Functions;
            checkBoxEnchanced.Checked = (fs & Functions.EnchancedSurround) > 0;
            checkBox3D.Checked = (fs & Functions._3D) > 0;
            checkBoxMixChannels.Checked = (fs & Functions.MixChannels) > 0;
            checkBoxMute.Checked = (fs & Functions.Mute) > 0;
            comboBoxInput.SelectedIndex = Properties.Settings.Default.Input;
        }
    }
}
