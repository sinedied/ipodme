namespace iPodME
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showOptions = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.fixAspectCheck = new System.Windows.Forms.CheckBox();
            this.browse = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.outputDirBox = new System.Windows.Forms.TextBox();
            this.shutdownCheck = new System.Windows.Forms.CheckBox();
            this.prioSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stretchCheck = new System.Windows.Forms.CheckBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.helpLink = new System.Windows.Forms.LinkLabel();
            this.donateLink = new System.Windows.Forms.LinkLabel();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.sizeSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.showConsole = new System.Windows.Forms.CheckBox();
            this.clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.profileSelect = new System.Windows.Forms.ComboBox();
            this.convert = new System.Windows.Forms.Button();
            this.addFiles = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.consoleTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.aspectSelect = new System.Windows.Forms.ComboBox();
            this.rateControlLabel = new System.Windows.Forms.Label();
            this.aspectLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rateBox = new System.Windows.Forms.TextBox();
            this.deinterlaceCheck = new System.Windows.Forms.CheckBox();
            this.encModeSelect = new System.Windows.Forms.ComboBox();
            this.encProfSelect = new System.Windows.Forms.ComboBox();
            this.encoderSelect = new System.Windows.Forms.ComboBox();
            this.audFreqSelect = new System.Windows.Forms.ComboBox();
            this.audRateSelect = new System.Windows.Forms.ComboBox();
            this.resampleCheck = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.audFreqLabel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.addParamBox = new System.Windows.Forms.TextBox();
            this.outputFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showOptions);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.helpLink);
            this.groupBox1.Controls.Add(this.donateLink);
            this.groupBox1.Controls.Add(this.infoBox);
            this.groupBox1.Controls.Add(this.sizeSelect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.showConsole);
            this.groupBox1.Controls.Add(this.clear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.profileSelect);
            this.groupBox1.Controls.Add(this.convert);
            this.groupBox1.Controls.Add(this.addFiles);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video files to convert";
            // 
            // showOptions
            // 
            this.showOptions.Appearance = System.Windows.Forms.Appearance.Button;
            this.showOptions.Location = new System.Drawing.Point(193, 254);
            this.showOptions.Name = "showOptions";
            this.showOptions.Size = new System.Drawing.Size(89, 23);
            this.showOptions.TabIndex = 6;
            this.showOptions.Text = "More options";
            this.showOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showOptions.UseVisualStyleBackColor = true;
            this.showOptions.CheckedChanged += new System.EventHandler(this.showOptions_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.listBox);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 202);
            this.panel1.TabIndex = 9;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.fixAspectCheck);
            this.groupBox6.Controls.Add(this.browse);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.outputDirBox);
            this.groupBox6.Controls.Add(this.shutdownCheck);
            this.groupBox6.Controls.Add(this.prioSelect);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.stretchCheck);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 88);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(276, 114);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Advanced options";
            this.groupBox6.Visible = false;
            // 
            // fixAspectCheck
            // 
            this.fixAspectCheck.AutoSize = true;
            this.fixAspectCheck.Location = new System.Drawing.Point(6, 65);
            this.fixAspectCheck.Name = "fixAspectCheck";
            this.fixAspectCheck.Size = new System.Drawing.Size(97, 17);
            this.fixAspectCheck.TabIndex = 24;
            this.fixAspectCheck.Text = "Fix aspect ratio";
            this.fixAspectCheck.UseVisualStyleBackColor = true;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(246, 88);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(24, 20);
            this.browse.TabIndex = 25;
            this.browse.Text = "...";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Output folder :";
            // 
            // outputDirBox
            // 
            this.outputDirBox.Location = new System.Drawing.Point(86, 88);
            this.outputDirBox.Name = "outputDirBox";
            this.outputDirBox.ReadOnly = true;
            this.outputDirBox.Size = new System.Drawing.Size(154, 20);
            this.outputDirBox.TabIndex = 9;
            // 
            // shutdownCheck
            // 
            this.shutdownCheck.AutoSize = true;
            this.shutdownCheck.Location = new System.Drawing.Point(6, 21);
            this.shutdownCheck.Name = "shutdownCheck";
            this.shutdownCheck.Size = new System.Drawing.Size(142, 17);
            this.shutdownCheck.TabIndex = 21;
            this.shutdownCheck.Text = "Shutdown when finished";
            this.shutdownCheck.UseVisualStyleBackColor = true;
            // 
            // prioSelect
            // 
            this.prioSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prioSelect.FormattingEnabled = true;
            this.prioSelect.Location = new System.Drawing.Point(181, 40);
            this.prioSelect.Name = "prioSelect";
            this.prioSelect.Size = new System.Drawing.Size(89, 21);
            this.prioSelect.TabIndex = 23;
            this.prioSelect.SelectedIndexChanged += new System.EventHandler(this.prioSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Process priority :";
            // 
            // stretchCheck
            // 
            this.stretchCheck.AutoSize = true;
            this.stretchCheck.Location = new System.Drawing.Point(6, 43);
            this.stretchCheck.Name = "stretchCheck";
            this.stretchCheck.Size = new System.Drawing.Size(133, 17);
            this.stretchCheck.TabIndex = 22;
            this.stretchCheck.Text = "Stretch video to fit size";
            this.stretchCheck.UseVisualStyleBackColor = true;
            this.stretchCheck.CheckedChanged += new System.EventHandler(this.stretchCheck_CheckedChanged);
            // 
            // listBox
            // 
            this.listBox.AllowDrop = true;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(276, 82);
            this.listBox.TabIndex = 1;
            this.listBox.DataSourceChanged += new System.EventHandler(this.listBox_DataSourceChanged);
            this.listBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.listBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            // 
            // helpLink
            // 
            this.helpLink.AutoSize = true;
            this.helpLink.Location = new System.Drawing.Point(9, 259);
            this.helpLink.Name = "helpLink";
            this.helpLink.Size = new System.Drawing.Size(29, 13);
            this.helpLink.TabIndex = 4;
            this.helpLink.TabStop = true;
            this.helpLink.Text = "Help";
            this.helpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.helpLink_LinkClicked);
            // 
            // donateLink
            // 
            this.donateLink.AutoSize = true;
            this.donateLink.Location = new System.Drawing.Point(44, 259);
            this.donateLink.Name = "donateLink";
            this.donateLink.Size = new System.Drawing.Size(42, 13);
            this.donateLink.TabIndex = 5;
            this.donateLink.TabStop = true;
            this.donateLink.Text = "Donate";
            this.donateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.donateLink_LinkClicked);
            // 
            // infoBox
            // 
            this.infoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.infoBox.Location = new System.Drawing.Point(6, 283);
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.Size = new System.Drawing.Size(276, 20);
            this.infoBox.TabIndex = 100;
            this.infoBox.TabStop = false;
            this.infoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sizeSelect
            // 
            this.sizeSelect.FormattingEnabled = true;
            this.sizeSelect.Location = new System.Drawing.Point(66, 227);
            this.sizeSelect.Name = "sizeSelect";
            this.sizeSelect.Size = new System.Drawing.Size(70, 21);
            this.sizeSelect.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Max size :";
            // 
            // showConsole
            // 
            this.showConsole.Appearance = System.Windows.Forms.Appearance.Button;
            this.showConsole.Location = new System.Drawing.Point(168, 313);
            this.showConsole.Name = "showConsole";
            this.showConsole.Size = new System.Drawing.Size(33, 19);
            this.showConsole.TabIndex = 9;
            this.showConsole.Text = "v";
            this.showConsole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showConsole.UseVisualStyleBackColor = true;
            this.showConsole.CheckedChanged += new System.EventHandler(this.showConsole_CheckedChanged);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(87, 309);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 8;
            this.clear.Text = "Clear list";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Profile :";
            // 
            // profileSelect
            // 
            this.profileSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileSelect.FormattingEnabled = true;
            this.profileSelect.Location = new System.Drawing.Point(193, 227);
            this.profileSelect.Name = "profileSelect";
            this.profileSelect.Size = new System.Drawing.Size(89, 21);
            this.profileSelect.TabIndex = 3;
            this.profileSelect.SelectedIndexChanged += new System.EventHandler(this.profileSelect_SelectedIndexChanged);
            // 
            // convert
            // 
            this.convert.Enabled = false;
            this.convert.Location = new System.Drawing.Point(207, 309);
            this.convert.Name = "convert";
            this.convert.Size = new System.Drawing.Size(75, 23);
            this.convert.TabIndex = 10;
            this.convert.Text = "Convert";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // addFiles
            // 
            this.addFiles.Location = new System.Drawing.Point(6, 309);
            this.addFiles.Name = "addFiles";
            this.addFiles.Size = new System.Drawing.Size(75, 23);
            this.addFiles.TabIndex = 7;
            this.addFiles.Text = "Add files";
            this.addFiles.UseVisualStyleBackColor = true;
            this.addFiles.Click += new System.EventHandler(this.addFiles_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Video files|*.avi;*.mpg;*.mpeg;*.mp4;*.flv;*.mkv;*.ogm;*.wmv;*.rm;*.rmvb;*.divx;*" +
                ".3gp;*.3g2;*.vob|All files|*.*";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Add video files to convert";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.BackColor = System.Drawing.Color.Black;
            this.consoleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleTextBox.Font = new System.Drawing.Font("Lucida Console", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleTextBox.ForeColor = System.Drawing.Color.White;
            this.consoleTextBox.Location = new System.Drawing.Point(3, 16);
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.Size = new System.Drawing.Size(282, 101);
            this.consoleTextBox.TabIndex = 200;
            this.consoleTextBox.Text = "Ready.";
            this.consoleTextBox.WordWrap = false;
            this.consoleTextBox.TextChanged += new System.EventHandler(this.consoleTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.consoleTextBox);
            this.groupBox2.Location = new System.Drawing.Point(5, 350);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 120);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console Output";
            this.groupBox2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.aspectSelect);
            this.groupBox3.Controls.Add(this.rateControlLabel);
            this.groupBox3.Controls.Add(this.aspectLabel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.rateBox);
            this.groupBox3.Controls.Add(this.deinterlaceCheck);
            this.groupBox3.Controls.Add(this.encModeSelect);
            this.groupBox3.Controls.Add(this.encProfSelect);
            this.groupBox3.Controls.Add(this.encoderSelect);
            this.groupBox3.Location = new System.Drawing.Point(302, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(186, 182);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Video options";
            this.groupBox3.Visible = false;
            // 
            // aspectSelect
            // 
            this.aspectSelect.Location = new System.Drawing.Point(84, 126);
            this.aspectSelect.Name = "aspectSelect";
            this.aspectSelect.Size = new System.Drawing.Size(72, 21);
            this.aspectSelect.TabIndex = 34;
            this.aspectSelect.Validated += new System.EventHandler(this.aspectSelect_Validated);
            // 
            // rateControlLabel
            // 
            this.rateControlLabel.AutoSize = true;
            this.rateControlLabel.Location = new System.Drawing.Point(6, 103);
            this.rateControlLabel.Name = "rateControlLabel";
            this.rateControlLabel.Size = new System.Drawing.Size(58, 13);
            this.rateControlLabel.TabIndex = 4;
            this.rateControlLabel.Text = "Quantizer :";
            // 
            // aspectLabel
            // 
            this.aspectLabel.AutoSize = true;
            this.aspectLabel.Location = new System.Drawing.Point(6, 129);
            this.aspectLabel.Name = "aspectLabel";
            this.aspectLabel.Size = new System.Drawing.Size(46, 13);
            this.aspectLabel.TabIndex = 4;
            this.aspectLabel.Text = "Aspect :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Mode :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Profile :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Encoder :";
            // 
            // rateBox
            // 
            this.rateBox.Location = new System.Drawing.Point(84, 100);
            this.rateBox.Name = "rateBox";
            this.rateBox.Size = new System.Drawing.Size(72, 20);
            this.rateBox.TabIndex = 33;
            this.rateBox.Text = "21";
            this.rateBox.Validated += new System.EventHandler(this.rateBox_Validated);
            // 
            // deinterlaceCheck
            // 
            this.deinterlaceCheck.AutoSize = true;
            this.deinterlaceCheck.Location = new System.Drawing.Point(6, 159);
            this.deinterlaceCheck.Name = "deinterlaceCheck";
            this.deinterlaceCheck.Size = new System.Drawing.Size(80, 17);
            this.deinterlaceCheck.TabIndex = 35;
            this.deinterlaceCheck.Text = "Deinterlace";
            this.deinterlaceCheck.UseVisualStyleBackColor = true;
            // 
            // encModeSelect
            // 
            this.encModeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encModeSelect.FormattingEnabled = true;
            this.encModeSelect.Location = new System.Drawing.Point(65, 73);
            this.encModeSelect.Name = "encModeSelect";
            this.encModeSelect.Size = new System.Drawing.Size(115, 21);
            this.encModeSelect.TabIndex = 32;
            this.encModeSelect.SelectedIndexChanged += new System.EventHandler(this.encModeSelect_SelectedIndexChanged);
            // 
            // encProfSelect
            // 
            this.encProfSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encProfSelect.FormattingEnabled = true;
            this.encProfSelect.Location = new System.Drawing.Point(65, 46);
            this.encProfSelect.Name = "encProfSelect";
            this.encProfSelect.Size = new System.Drawing.Size(115, 21);
            this.encProfSelect.TabIndex = 31;
            // 
            // encoderSelect
            // 
            this.encoderSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encoderSelect.FormattingEnabled = true;
            this.encoderSelect.Location = new System.Drawing.Point(65, 19);
            this.encoderSelect.Name = "encoderSelect";
            this.encoderSelect.Size = new System.Drawing.Size(115, 21);
            this.encoderSelect.TabIndex = 30;
            this.encoderSelect.SelectedIndexChanged += new System.EventHandler(this.encoderSelect_SelectedIndexChanged);
            // 
            // audFreqSelect
            // 
            this.audFreqSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audFreqSelect.FormattingEnabled = true;
            this.audFreqSelect.Location = new System.Drawing.Point(84, 42);
            this.audFreqSelect.Name = "audFreqSelect";
            this.audFreqSelect.Size = new System.Drawing.Size(96, 21);
            this.audFreqSelect.TabIndex = 37;
            // 
            // audRateSelect
            // 
            this.audRateSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audRateSelect.FormattingEnabled = true;
            this.audRateSelect.Location = new System.Drawing.Point(84, 69);
            this.audRateSelect.Name = "audRateSelect";
            this.audRateSelect.Size = new System.Drawing.Size(96, 21);
            this.audRateSelect.TabIndex = 38;
            // 
            // resampleCheck
            // 
            this.resampleCheck.AutoSize = true;
            this.resampleCheck.Checked = true;
            this.resampleCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.resampleCheck.Location = new System.Drawing.Point(6, 19);
            this.resampleCheck.Name = "resampleCheck";
            this.resampleCheck.Size = new System.Drawing.Size(132, 17);
            this.resampleCheck.TabIndex = 36;
            this.resampleCheck.Text = "Resample audio track ";
            this.resampleCheck.UseVisualStyleBackColor = true;
            this.resampleCheck.CheckedChanged += new System.EventHandler(this.resampleCheck_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.audFreqLabel);
            this.groupBox4.Controls.Add(this.audRateSelect);
            this.groupBox4.Controls.Add(this.audFreqSelect);
            this.groupBox4.Controls.Add(this.resampleCheck);
            this.groupBox4.Location = new System.Drawing.Point(302, 193);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(186, 98);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Audio options";
            this.groupBox4.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Bitrate (kbps):";
            // 
            // audFreqLabel
            // 
            this.audFreqLabel.AutoSize = true;
            this.audFreqLabel.Location = new System.Drawing.Point(6, 45);
            this.audFreqLabel.Name = "audFreqLabel";
            this.audFreqLabel.Size = new System.Drawing.Size(63, 13);
            this.audFreqLabel.TabIndex = 4;
            this.audFreqLabel.Text = "Frequency :";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.addParamBox);
            this.groupBox5.Location = new System.Drawing.Point(302, 297);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(186, 46);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Additional parameters";
            this.groupBox5.Visible = false;
            // 
            // addParamBox
            // 
            this.addParamBox.Location = new System.Drawing.Point(6, 19);
            this.addParamBox.Name = "addParamBox";
            this.addParamBox.Size = new System.Drawing.Size(174, 20);
            this.addParamBox.TabIndex = 39;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(494, 475);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iPodME";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addFiles;
        private System.Windows.Forms.Button convert;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.RichTextBox consoleTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ComboBox profileSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox prioSelect;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.CheckBox stretchCheck;
        private System.Windows.Forms.CheckBox showConsole;
        private System.Windows.Forms.ComboBox sizeSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox resampleCheck;
        private System.Windows.Forms.ComboBox audRateSelect;
        private System.Windows.Forms.ComboBox audFreqSelect;
        private System.Windows.Forms.ComboBox encProfSelect;
        private System.Windows.Forms.ComboBox encoderSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rateBox;
        private System.Windows.Forms.ComboBox encModeSelect;
        private System.Windows.Forms.Label rateControlLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label audFreqLabel;
        private System.Windows.Forms.CheckBox deinterlaceCheck;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox addParamBox;
        private System.Windows.Forms.LinkLabel helpLink;
        private System.Windows.Forms.LinkLabel donateLink;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox shutdownCheck;
        private System.Windows.Forms.CheckBox showOptions;
        private System.Windows.Forms.TextBox outputDirBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.FolderBrowserDialog outputFolderDialog;
        private System.Windows.Forms.CheckBox fixAspectCheck;
        private System.Windows.Forms.ComboBox aspectSelect;
        private System.Windows.Forms.Label aspectLabel;
    }
}

