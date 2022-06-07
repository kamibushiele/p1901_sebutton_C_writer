namespace PCMChipWriter2
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialogSounds = new System.Windows.Forms.OpenFileDialog();
            this.audioFileList = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soundFileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSoundFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSoundFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSdoundFileEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.eepromUsageText = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.eepromUsage = new System.Windows.Forms.ProgressBar();
            this.buttonFlush = new System.Windows.Forms.Button();
            this.listPorts = new System.Windows.Forms.ListBox();
            this.progressBarFlush = new System.Windows.Forms.ProgressBar();
            this.buttonReload = new System.Windows.Forms.Button();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelProgressFlush = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelModelName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMaxTime = new System.Windows.Forms.Label();
            this.labelMaxSingleTime = new System.Windows.Forms.Label();
            this.labelSamapleRate = new System.Windows.Forms.Label();
            this.labelBitPerSample = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelChannel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSondsNum = new System.Windows.Forms.Label();
            this.saveFileDialogDump = new System.Windows.Forms.SaveFileDialog();
            this.soundFileMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialogSounds
            // 
            this.openFileDialogSounds.Filter = "|*.wav;*.mp3";
            this.openFileDialogSounds.Multiselect = true;
            this.openFileDialogSounds.RestoreDirectory = true;
            this.openFileDialogSounds.SupportMultiDottedExtensions = true;
            // 
            // audioFileList
            // 
            this.audioFileList.AllowDrop = true;
            this.audioFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnSize,
            this.columnWeight,
            this.columnPath});
            this.audioFileList.ContextMenuStrip = this.soundFileMenu;
            this.audioFileList.HideSelection = false;
            this.audioFileList.Location = new System.Drawing.Point(12, 108);
            this.audioFileList.Name = "audioFileList";
            this.audioFileList.Size = new System.Drawing.Size(292, 130);
            this.audioFileList.TabIndex = 0;
            this.audioFileList.UseCompatibleStateImageBehavior = false;
            this.audioFileList.View = System.Windows.Forms.View.Details;
            this.audioFileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.audioFileList_DragDrop);
            this.audioFileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.audioFileList_DragEnter);
            this.audioFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.audioFileList_KeyDown);
            this.audioFileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.audioFileList_MouseDoubleClick);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 130;
            // 
            // columnSize
            // 
            this.columnSize.DisplayIndex = 2;
            this.columnSize.Text = "Size";
            this.columnSize.Width = 57;
            // 
            // columnWeight
            // 
            this.columnWeight.DisplayIndex = 1;
            this.columnWeight.Text = "Weight";
            // 
            // columnPath
            // 
            this.columnPath.Text = "Path";
            this.columnPath.Width = 500;
            // 
            // soundFileMenu
            // 
            this.soundFileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSoundFilesToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteSoundFileToolStripMenuItem,
            this.editSdoundFileEToolStripMenuItem});
            this.soundFileMenu.Name = "soundFileMenu";
            this.soundFileMenu.Size = new System.Drawing.Size(179, 76);
            this.soundFileMenu.Opening += new System.ComponentModel.CancelEventHandler(this.soundFileMenu_Opening);
            // 
            // addSoundFilesToolStripMenuItem
            // 
            this.addSoundFilesToolStripMenuItem.Name = "addSoundFilesToolStripMenuItem";
            this.addSoundFilesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.addSoundFilesToolStripMenuItem.Text = "Add sound files(&O)";
            this.addSoundFilesToolStripMenuItem.Click += new System.EventHandler(this.addSoundFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // deleteSoundFileToolStripMenuItem
            // 
            this.deleteSoundFileToolStripMenuItem.Name = "deleteSoundFileToolStripMenuItem";
            this.deleteSoundFileToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.deleteSoundFileToolStripMenuItem.Tag = "del";
            this.deleteSoundFileToolStripMenuItem.Text = "Delete sound file(&D)";
            this.deleteSoundFileToolStripMenuItem.Click += new System.EventHandler(this.deleteSoundFileToolStripMenuItem_Click);
            // 
            // editSdoundFileEToolStripMenuItem
            // 
            this.editSdoundFileEToolStripMenuItem.Name = "editSdoundFileEToolStripMenuItem";
            this.editSdoundFileEToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.editSdoundFileEToolStripMenuItem.Tag = "edit";
            this.editSdoundFileEToolStripMenuItem.Text = "Edit sdound file(&E)";
            this.editSdoundFileEToolStripMenuItem.Click += new System.EventHandler(this.editSdoundFileEToolStripMenuItem_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(321, 183);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(292, 92);
            this.textBoxLog.TabIndex = 1;
            this.textBoxLog.TabStop = false;
            // 
            // eepromUsageText
            // 
            this.eepromUsageText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eepromUsageText.Location = new System.Drawing.Point(119, 284);
            this.eepromUsageText.Name = "eepromUsageText";
            this.eepromUsageText.Size = new System.Drawing.Size(185, 18);
            this.eepromUsageText.TabIndex = 2;
            this.eepromUsageText.Text = "ROMUSAGE";
            this.eepromUsageText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "SerialPorts";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "Target Model";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // eepromUsage
            // 
            this.eepromUsage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eepromUsage.Enabled = false;
            this.eepromUsage.Location = new System.Drawing.Point(17, 256);
            this.eepromUsage.MarqueeAnimationSpeed = 1;
            this.eepromUsage.Name = "eepromUsage";
            this.eepromUsage.Size = new System.Drawing.Size(287, 19);
            this.eepromUsage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.eepromUsage.TabIndex = 3;
            // 
            // buttonFlush
            // 
            this.buttonFlush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFlush.Location = new System.Drawing.Point(321, 125);
            this.buttonFlush.Name = "buttonFlush";
            this.buttonFlush.Size = new System.Drawing.Size(75, 23);
            this.buttonFlush.TabIndex = 3;
            this.buttonFlush.Text = "Flush";
            this.buttonFlush.UseVisualStyleBackColor = true;
            this.buttonFlush.Click += new System.EventHandler(this.buttonFlush_Click);
            // 
            // listPorts
            // 
            this.listPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPorts.FormattingEnabled = true;
            this.listPorts.HorizontalScrollbar = true;
            this.listPorts.ItemHeight = 12;
            this.listPorts.Location = new System.Drawing.Point(321, 56);
            this.listPorts.Name = "listPorts";
            this.listPorts.Size = new System.Drawing.Size(292, 64);
            this.listPorts.TabIndex = 2;
            this.listPorts.SelectedIndexChanged += new System.EventHandler(this.listPorts_SelectedIndexChanged);
            // 
            // progressBarFlush
            // 
            this.progressBarFlush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarFlush.Location = new System.Drawing.Point(321, 154);
            this.progressBarFlush.MarqueeAnimationSpeed = 1;
            this.progressBarFlush.Name = "progressBarFlush";
            this.progressBarFlush.Size = new System.Drawing.Size(257, 23);
            this.progressBarFlush.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarFlush.TabIndex = 3;
            // 
            // buttonReload
            // 
            this.buttonReload.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.buttonReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReload.Location = new System.Drawing.Point(538, 27);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(75, 23);
            this.buttonReload.TabIndex = 1;
            this.buttonReload.Text = "Reload";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearLog.Location = new System.Drawing.Point(538, 276);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 23);
            this.buttonClearLog.TabIndex = 4;
            this.buttonClearLog.Text = "Clear Log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "ROM Usage";
            // 
            // labelProgressFlush
            // 
            this.labelProgressFlush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProgressFlush.Location = new System.Drawing.Point(584, 152);
            this.labelProgressFlush.Name = "labelProgressFlush";
            this.labelProgressFlush.Size = new System.Drawing.Size(29, 23);
            this.labelProgressFlush.TabIndex = 2;
            this.labelProgressFlush.Text = "100%";
            this.labelProgressFlush.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.52055F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.47945F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelModelName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelMaxTime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelMaxSingleTime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelSamapleRate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelBitPerSample, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelChannel, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 75);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // labelModelName
            // 
            this.labelModelName.AutoSize = true;
            this.labelModelName.Location = new System.Drawing.Point(133, 0);
            this.labelModelName.Name = "labelModelName";
            this.labelModelName.Size = new System.Drawing.Size(75, 12);
            this.labelModelName.TabIndex = 2;
            this.labelModelName.Text = "MODELNAME";
            this.labelModelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max total sound time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max single sound time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sound sample rate";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sound bit per sample";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelMaxTime
            // 
            this.labelMaxTime.AutoSize = true;
            this.labelMaxTime.Location = new System.Drawing.Point(133, 12);
            this.labelMaxTime.Name = "labelMaxTime";
            this.labelMaxTime.Size = new System.Drawing.Size(21, 12);
            this.labelMaxTime.TabIndex = 2;
            this.labelMaxTime.Text = "0 s";
            this.labelMaxTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelMaxSingleTime
            // 
            this.labelMaxSingleTime.AutoSize = true;
            this.labelMaxSingleTime.Location = new System.Drawing.Point(133, 24);
            this.labelMaxSingleTime.Name = "labelMaxSingleTime";
            this.labelMaxSingleTime.Size = new System.Drawing.Size(21, 12);
            this.labelMaxSingleTime.TabIndex = 2;
            this.labelMaxSingleTime.Text = "0 s";
            this.labelMaxSingleTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSamapleRate
            // 
            this.labelSamapleRate.AutoSize = true;
            this.labelSamapleRate.Location = new System.Drawing.Point(133, 36);
            this.labelSamapleRate.Name = "labelSamapleRate";
            this.labelSamapleRate.Size = new System.Drawing.Size(28, 12);
            this.labelSamapleRate.TabIndex = 2;
            this.labelSamapleRate.Text = "0 Hz";
            this.labelSamapleRate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelBitPerSample
            // 
            this.labelBitPerSample.AutoSize = true;
            this.labelBitPerSample.Location = new System.Drawing.Point(133, 48);
            this.labelBitPerSample.Name = "labelBitPerSample";
            this.labelBitPerSample.Size = new System.Drawing.Size(28, 12);
            this.labelBitPerSample.TabIndex = 2;
            this.labelBitPerSample.Text = "0 bit";
            this.labelBitPerSample.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "Sound channels";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.Location = new System.Drawing.Point(133, 60);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(11, 12);
            this.labelChannel.TabIndex = 2;
            this.labelChannel.Text = "0";
            this.labelChannel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.helpHToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitXToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.filesToolStripMenuItem.Text = "Files(&F)";
            // 
            // exitXToolStripMenuItem
            // 
            this.exitXToolStripMenuItem.Name = "exitXToolStripMenuItem";
            this.exitXToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitXToolStripMenuItem.Text = "Exit(&X)";
            this.exitXToolStripMenuItem.Click += new System.EventHandler(this.exitXToolStripMenuItem_Click);
            // 
            // helpHToolStripMenuItem
            // 
            this.helpHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutAToolStripMenuItem});
            this.helpHToolStripMenuItem.Name = "helpHToolStripMenuItem";
            this.helpHToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.helpHToolStripMenuItem.Text = "Help(&H)";
            // 
            // aboutAToolStripMenuItem
            // 
            this.aboutAToolStripMenuItem.Name = "aboutAToolStripMenuItem";
            this.aboutAToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.aboutAToolStripMenuItem.Text = "About(&A)";
            this.aboutAToolStripMenuItem.Click += new System.EventHandler(this.aboutAToolStripMenuItem_Click);
            // 
            // labelSondsNum
            // 
            this.labelSondsNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSondsNum.AutoSize = true;
            this.labelSondsNum.Location = new System.Drawing.Point(15, 287);
            this.labelSondsNum.Name = "labelSondsNum";
            this.labelSondsNum.Size = new System.Drawing.Size(72, 12);
            this.labelSondsNum.TabIndex = 2;
            this.labelSondsNum.Text = "0/0 Sound(s)";
            // 
            // saveFileDialogDump
            // 
            this.saveFileDialogDump.Filter = "|*.bin";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.progressBarFlush);
            this.Controls.Add(this.eepromUsage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelProgressFlush);
            this.Controls.Add(this.labelSondsNum);
            this.Controls.Add(this.eepromUsageText);
            this.Controls.Add(this.listPorts);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.buttonFlush);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.audioFileList);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "PCM Chip Writer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.soundFileMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogSounds;
        private System.Windows.Forms.ListView audioFileList;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnWeight;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label eepromUsageText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar eepromUsage;
        private System.Windows.Forms.Button buttonFlush;
        private System.Windows.Forms.ListBox listPorts;
        private System.Windows.Forms.ProgressBar progressBarFlush;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelProgressFlush;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelModelName;
        private System.Windows.Forms.Label labelMaxTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMaxSingleTime;
        private System.Windows.Forms.Label labelSondsNum;
        private System.Windows.Forms.ColumnHeader columnPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSamapleRate;
        private System.Windows.Forms.Label labelBitPerSample;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelChannel;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip soundFileMenu;
        private System.Windows.Forms.ToolStripMenuItem addSoundFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteSoundFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSdoundFileEToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogDump;
    }
}

