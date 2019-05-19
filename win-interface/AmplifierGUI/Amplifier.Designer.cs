namespace AmplifierGUI
{
    partial class Amplifier
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Amplifier));
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.groupBoxVolume = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarToneTreble = new System.Windows.Forms.TrackBar();
            this.trackBarToneMiddle = new System.Windows.Forms.TrackBar();
            this.trackBarToneBass = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.trackBarTrimSW = new System.Windows.Forms.TrackBar();
            this.trackBarTrimCT = new System.Windows.Forms.TrackBar();
            this.trackBarTrimRR = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarTrimRL = new System.Windows.Forms.TrackBar();
            this.trackBarTrimFR = new System.Windows.Forms.TrackBar();
            this.trackBarTrimFL = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxToneDefeat = new System.Windows.Forms.CheckBox();
            this.checkBoxMute = new System.Windows.Forms.CheckBox();
            this.checkBoxMixChannels = new System.Windows.Forms.CheckBox();
            this.checkBox3D = new System.Windows.Forms.CheckBox();
            this.checkBoxEnchanced = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxAutorun = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerInit = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxInput = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.groupBoxVolume.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarToneTreble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarToneMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarToneBass)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimSW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimRR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimRL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimFR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimFL)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStripTray.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(6, 19);
            this.trackBarVolume.Maximum = 79;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolume.Size = new System.Drawing.Size(45, 300);
            this.trackBarVolume.TabIndex = 0;
            this.trackBarVolume.TickFrequency = 5;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // groupBoxVolume
            // 
            this.groupBoxVolume.Controls.Add(this.trackBarVolume);
            this.groupBoxVolume.Location = new System.Drawing.Point(12, 12);
            this.groupBoxVolume.Name = "groupBoxVolume";
            this.groupBoxVolume.Size = new System.Drawing.Size(57, 325);
            this.groupBoxVolume.TabIndex = 1;
            this.groupBoxVolume.TabStop = false;
            this.groupBoxVolume.Text = "Volume";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackBarToneTreble);
            this.groupBox1.Controls.Add(this.trackBarToneMiddle);
            this.groupBox1.Controls.Add(this.trackBarToneBass);
            this.groupBox1.Location = new System.Drawing.Point(75, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 325);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Treble";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Middle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bass";
            // 
            // trackBarToneTreble
            // 
            this.trackBarToneTreble.Location = new System.Drawing.Point(108, 42);
            this.trackBarToneTreble.Maximum = 15;
            this.trackBarToneTreble.Name = "trackBarToneTreble";
            this.trackBarToneTreble.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarToneTreble.Size = new System.Drawing.Size(45, 277);
            this.trackBarToneTreble.TabIndex = 2;
            this.trackBarToneTreble.Scroll += new System.EventHandler(this.trackBarToneTreble_Scroll);
            // 
            // trackBarToneMiddle
            // 
            this.trackBarToneMiddle.Location = new System.Drawing.Point(57, 42);
            this.trackBarToneMiddle.Maximum = 15;
            this.trackBarToneMiddle.Name = "trackBarToneMiddle";
            this.trackBarToneMiddle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarToneMiddle.Size = new System.Drawing.Size(45, 277);
            this.trackBarToneMiddle.TabIndex = 1;
            this.trackBarToneMiddle.Scroll += new System.EventHandler(this.trackBarToneMiddle_Scroll);
            // 
            // trackBarToneBass
            // 
            this.trackBarToneBass.Location = new System.Drawing.Point(6, 42);
            this.trackBarToneBass.Maximum = 15;
            this.trackBarToneBass.Name = "trackBarToneBass";
            this.trackBarToneBass.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarToneBass.Size = new System.Drawing.Size(45, 277);
            this.trackBarToneBass.TabIndex = 0;
            this.trackBarToneBass.Scroll += new System.EventHandler(this.trackBarToneBass_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.trackBarTrimSW);
            this.groupBox2.Controls.Add(this.trackBarTrimCT);
            this.groupBox2.Controls.Add(this.trackBarTrimRR);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.trackBarTrimRL);
            this.groupBox2.Controls.Add(this.trackBarTrimFR);
            this.groupBox2.Controls.Add(this.trackBarTrimFL);
            this.groupBox2.Location = new System.Drawing.Point(241, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 325);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trim";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "SW";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "CT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(159, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "RR";
            // 
            // trackBarTrimSW
            // 
            this.trackBarTrimSW.Location = new System.Drawing.Point(261, 42);
            this.trackBarTrimSW.Maximum = 15;
            this.trackBarTrimSW.Name = "trackBarTrimSW";
            this.trackBarTrimSW.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarTrimSW.Size = new System.Drawing.Size(45, 277);
            this.trackBarTrimSW.TabIndex = 8;
            this.trackBarTrimSW.Scroll += new System.EventHandler(this.trackBarTrimSW_Scroll);
            // 
            // trackBarTrimCT
            // 
            this.trackBarTrimCT.Location = new System.Drawing.Point(210, 42);
            this.trackBarTrimCT.Maximum = 15;
            this.trackBarTrimCT.Name = "trackBarTrimCT";
            this.trackBarTrimCT.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarTrimCT.Size = new System.Drawing.Size(45, 277);
            this.trackBarTrimCT.TabIndex = 7;
            this.trackBarTrimCT.Scroll += new System.EventHandler(this.trackBarTrimCT_Scroll);
            // 
            // trackBarTrimRR
            // 
            this.trackBarTrimRR.Location = new System.Drawing.Point(159, 42);
            this.trackBarTrimRR.Maximum = 15;
            this.trackBarTrimRR.Name = "trackBarTrimRR";
            this.trackBarTrimRR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarTrimRR.Size = new System.Drawing.Size(45, 277);
            this.trackBarTrimRR.TabIndex = 6;
            this.trackBarTrimRR.Scroll += new System.EventHandler(this.trackBarTrimRR_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "RL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "FR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "FL";
            // 
            // trackBarTrimRL
            // 
            this.trackBarTrimRL.Location = new System.Drawing.Point(108, 42);
            this.trackBarTrimRL.Maximum = 15;
            this.trackBarTrimRL.Name = "trackBarTrimRL";
            this.trackBarTrimRL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarTrimRL.Size = new System.Drawing.Size(45, 277);
            this.trackBarTrimRL.TabIndex = 2;
            this.trackBarTrimRL.Scroll += new System.EventHandler(this.trackBarTrimRL_Scroll);
            // 
            // trackBarTrimFR
            // 
            this.trackBarTrimFR.Location = new System.Drawing.Point(57, 42);
            this.trackBarTrimFR.Maximum = 15;
            this.trackBarTrimFR.Name = "trackBarTrimFR";
            this.trackBarTrimFR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarTrimFR.Size = new System.Drawing.Size(45, 277);
            this.trackBarTrimFR.TabIndex = 1;
            this.trackBarTrimFR.Scroll += new System.EventHandler(this.trackBarTrimFR_Scroll);
            // 
            // trackBarTrimFL
            // 
            this.trackBarTrimFL.Location = new System.Drawing.Point(6, 42);
            this.trackBarTrimFL.Maximum = 15;
            this.trackBarTrimFL.Name = "trackBarTrimFL";
            this.trackBarTrimFL.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarTrimFL.Size = new System.Drawing.Size(45, 277);
            this.trackBarTrimFL.TabIndex = 0;
            this.trackBarTrimFL.Scroll += new System.EventHandler(this.trackBarTrimFL_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxToneDefeat);
            this.groupBox3.Controls.Add(this.checkBoxMute);
            this.groupBox3.Controls.Add(this.checkBoxMixChannels);
            this.groupBox3.Controls.Add(this.checkBox3D);
            this.groupBox3.Controls.Add(this.checkBoxEnchanced);
            this.groupBox3.Location = new System.Drawing.Point(560, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 139);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Functions";
            // 
            // checkBoxToneDefeat
            // 
            this.checkBoxToneDefeat.AutoSize = true;
            this.checkBoxToneDefeat.Location = new System.Drawing.Point(6, 111);
            this.checkBoxToneDefeat.Name = "checkBoxToneDefeat";
            this.checkBoxToneDefeat.Size = new System.Drawing.Size(84, 17);
            this.checkBoxToneDefeat.TabIndex = 4;
            this.checkBoxToneDefeat.Text = "Tone defeat";
            this.checkBoxToneDefeat.UseVisualStyleBackColor = true;
            this.checkBoxToneDefeat.CheckedChanged += new System.EventHandler(this.checkBoxFunction_CheckedChanged);
            // 
            // checkBoxMute
            // 
            this.checkBoxMute.AutoSize = true;
            this.checkBoxMute.Location = new System.Drawing.Point(6, 88);
            this.checkBoxMute.Name = "checkBoxMute";
            this.checkBoxMute.Size = new System.Drawing.Size(50, 17);
            this.checkBoxMute.TabIndex = 3;
            this.checkBoxMute.Text = "Mute";
            this.checkBoxMute.UseVisualStyleBackColor = true;
            this.checkBoxMute.CheckedChanged += new System.EventHandler(this.checkBoxFunction_CheckedChanged);
            // 
            // checkBoxMixChannels
            // 
            this.checkBoxMixChannels.AutoSize = true;
            this.checkBoxMixChannels.Location = new System.Drawing.Point(6, 65);
            this.checkBoxMixChannels.Name = "checkBoxMixChannels";
            this.checkBoxMixChannels.Size = new System.Drawing.Size(88, 17);
            this.checkBoxMixChannels.TabIndex = 2;
            this.checkBoxMixChannels.Text = "Mix channels";
            this.checkBoxMixChannels.UseVisualStyleBackColor = true;
            this.checkBoxMixChannels.CheckedChanged += new System.EventHandler(this.checkBoxFunction_CheckedChanged);
            // 
            // checkBox3D
            // 
            this.checkBox3D.AutoSize = true;
            this.checkBox3D.Location = new System.Drawing.Point(6, 42);
            this.checkBox3D.Name = "checkBox3D";
            this.checkBox3D.Size = new System.Drawing.Size(40, 17);
            this.checkBox3D.TabIndex = 1;
            this.checkBox3D.Text = "3D";
            this.checkBox3D.UseVisualStyleBackColor = true;
            this.checkBox3D.CheckedChanged += new System.EventHandler(this.checkBoxFunction_CheckedChanged);
            // 
            // checkBoxEnchanced
            // 
            this.checkBoxEnchanced.AutoSize = true;
            this.checkBoxEnchanced.Location = new System.Drawing.Point(6, 19);
            this.checkBoxEnchanced.Name = "checkBoxEnchanced";
            this.checkBoxEnchanced.Size = new System.Drawing.Size(125, 17);
            this.checkBoxEnchanced.TabIndex = 0;
            this.checkBoxEnchanced.Text = "Enchanced surround";
            this.checkBoxEnchanced.UseVisualStyleBackColor = true;
            this.checkBoxEnchanced.CheckedChanged += new System.EventHandler(this.checkBoxFunction_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.checkBoxAutorun);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.comboBoxPorts);
            this.groupBox4.Location = new System.Drawing.Point(560, 216);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 121);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Configuration";
            // 
            // checkBoxAutorun
            // 
            this.checkBoxAutorun.AutoSize = true;
            this.checkBoxAutorun.Location = new System.Drawing.Point(6, 19);
            this.checkBoxAutorun.Name = "checkBoxAutorun";
            this.checkBoxAutorun.Size = new System.Drawing.Size(63, 17);
            this.checkBoxAutorun.TabIndex = 3;
            this.checkBoxAutorun.Text = "Autorun";
            this.checkBoxAutorun.UseVisualStyleBackColor = true;
            this.checkBoxAutorun.CheckedChanged += new System.EventHandler(this.checkBoxAutorun_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(6, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Port";
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(6, 64);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(125, 21);
            this.comboBoxPorts.TabIndex = 0;
            this.comboBoxPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxPorts_SelectedIndexChanged);
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Text = "Amplifier";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.DoubleClick += new System.EventHandler(this.notifyIconTray_DoubleClick);
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(98, 26);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // timerInit
            // 
            this.timerInit.Interval = 5000;
            this.timerInit.Tick += new System.EventHandler(this.timerInit_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxInput);
            this.groupBox5.Location = new System.Drawing.Point(560, 157);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(139, 53);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Input";
            // 
            // comboBoxInput
            // 
            this.comboBoxInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInput.FormattingEnabled = true;
            this.comboBoxInput.Items.AddRange(new object[] {
            "Direct",
            "Line 4",
            "Line 3",
            "Line 2",
            "Line 1"});
            this.comboBoxInput.Location = new System.Drawing.Point(6, 19);
            this.comboBoxInput.Name = "comboBoxInput";
            this.comboBoxInput.Size = new System.Drawing.Size(127, 21);
            this.comboBoxInput.TabIndex = 0;
            this.comboBoxInput.SelectedIndexChanged += new System.EventHandler(this.comboBoxInput_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(96, 20);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "About";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Amplifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 349);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxVolume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Amplifier";
            this.Text = "Amplifier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Amplifier_FormClosing);
            this.Shown += new System.EventHandler(this.Amplifier_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.groupBoxVolume.ResumeLayout(false);
            this.groupBoxVolume.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarToneTreble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarToneMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarToneBass)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimSW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimRR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimRL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimFR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrimFL)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.contextMenuStripTray.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.GroupBox groupBoxVolume;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarToneTreble;
        private System.Windows.Forms.TrackBar trackBarToneMiddle;
        private System.Windows.Forms.TrackBar trackBarToneBass;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackBarTrimSW;
        private System.Windows.Forms.TrackBar trackBarTrimCT;
        private System.Windows.Forms.TrackBar trackBarTrimRR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBarTrimRL;
        private System.Windows.Forms.TrackBar trackBarTrimFR;
        private System.Windows.Forms.TrackBar trackBarTrimFL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxMixChannels;
        private System.Windows.Forms.CheckBox checkBox3D;
        private System.Windows.Forms.CheckBox checkBoxEnchanced;
        private System.Windows.Forms.CheckBox checkBoxMute;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxAutorun;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Timer timerInit;
        private System.Windows.Forms.CheckBox checkBoxToneDefeat;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBoxInput;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

