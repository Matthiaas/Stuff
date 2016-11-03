namespace VirtualIntput
{
    partial class RecordMenu
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
            this.btnMouse = new System.Windows.Forms.Button();
            this.lblMousePosition = new System.Windows.Forms.Label();
            this.lblLastKeyPressed = new System.Windows.Forms.Label();
            this.lblLMBP = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnMouseTrace = new System.Windows.Forms.Button();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.btnAllTrace = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.bntStart = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetKeys = new System.Windows.Forms.Button();
            this.lblTest = new System.Windows.Forms.Label();
            this.btnGetText = new System.Windows.Forms.Button();
            this.runInBackRoundPW = new System.Windows.Forms.TextBox();
            this.runInBackRound = new System.Windows.Forms.Button();
            this.times = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.NumericUpDown();
            this.speedMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.times)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMouse
            // 
            this.btnMouse.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnMouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMouse.Location = new System.Drawing.Point(14, 190);
            this.btnMouse.Name = "btnMouse";
            this.btnMouse.Size = new System.Drawing.Size(77, 42);
            this.btnMouse.TabIndex = 0;
            this.btnMouse.Text = "Record Mouse";
            this.btnMouse.UseVisualStyleBackColor = false;
            this.btnMouse.Click += new System.EventHandler(this.btnMouse_Click);
            // 
            // lblMousePosition
            // 
            this.lblMousePosition.AutoSize = true;
            this.lblMousePosition.Location = new System.Drawing.Point(12, 24);
            this.lblMousePosition.Name = "lblMousePosition";
            this.lblMousePosition.Size = new System.Drawing.Size(80, 13);
            this.lblMousePosition.TabIndex = 1;
            this.lblMousePosition.Text = "Mouse-Postion:";
            // 
            // lblLastKeyPressed
            // 
            this.lblLastKeyPressed.AutoSize = true;
            this.lblLastKeyPressed.Location = new System.Drawing.Point(12, 50);
            this.lblLastKeyPressed.Name = "lblLastKeyPressed";
            this.lblLastKeyPressed.Size = new System.Drawing.Size(92, 13);
            this.lblLastKeyPressed.TabIndex = 2;
            this.lblLastKeyPressed.Text = "Last Key Pressed:";
            // 
            // lblLMBP
            // 
            this.lblLMBP.AutoSize = true;
            this.lblLMBP.Location = new System.Drawing.Point(11, 37);
            this.lblLMBP.Name = "lblLMBP";
            this.lblLMBP.Size = new System.Drawing.Size(139, 13);
            this.lblLMBP.TabIndex = 3;
            this.lblLMBP.Text = "Last Mouse Button pressed:";
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Location = new System.Drawing.Point(182, 190);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(79, 42);
            this.btnAll.TabIndex = 5;
            this.btnAll.Text = "Record All";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnMouseTrace
            // 
            this.btnMouseTrace.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnMouseTrace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMouseTrace.Location = new System.Drawing.Point(12, 142);
            this.btnMouseTrace.Name = "btnMouseTrace";
            this.btnMouseTrace.Size = new System.Drawing.Size(79, 42);
            this.btnMouseTrace.TabIndex = 6;
            this.btnMouseTrace.Text = "Record MouseTraced";
            this.btnMouseTrace.UseVisualStyleBackColor = false;
            this.btnMouseTrace.Click += new System.EventHandler(this.btnMouseTrace_Click);
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyboard.Location = new System.Drawing.Point(97, 190);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(79, 42);
            this.btnKeyboard.TabIndex = 7;
            this.btnKeyboard.Text = "Record Keyboard";
            this.btnKeyboard.UseVisualStyleBackColor = false;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // btnAllTrace
            // 
            this.btnAllTrace.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAllTrace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllTrace.Location = new System.Drawing.Point(182, 142);
            this.btnAllTrace.Name = "btnAllTrace";
            this.btnAllTrace.Size = new System.Drawing.Size(79, 42);
            this.btnAllTrace.TabIndex = 8;
            this.btnAllTrace.Text = "Record All  (Trace)";
            this.btnAllTrace.UseVisualStyleBackColor = false;
            this.btnAllTrace.Click += new System.EventHandler(this.btnAllTrace_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Maroon;
            this.btnStop.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStop.Location = new System.Drawing.Point(424, 190);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(159, 42);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop Recording";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblStatus.Location = new System.Drawing.Point(420, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(201, 25);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "                           ";
            // 
            // bntStart
            // 
            this.bntStart.BackColor = System.Drawing.Color.Lime;
            this.bntStart.Location = new System.Drawing.Point(425, 142);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(158, 42);
            this.bntStart.TabIndex = 11;
            this.bntStart.Text = "Play Record";
            this.bntStart.UseVisualStyleBackColor = false;
            this.bntStart.Click += new System.EventHandler(this.bntStart_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editorToolStripMenuItem,
            this.hotKeysToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(595, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.bntOpen_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.editorToolStripMenuItem.Text = "Editor";
            this.editorToolStripMenuItem.Click += new System.EventHandler(this.OpenEditor);
            // 
            // hotKeysToolStripMenuItem
            // 
            this.hotKeysToolStripMenuItem.Name = "hotKeysToolStripMenuItem";
            this.hotKeysToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.hotKeysToolStripMenuItem.Text = "Hot-Keys";
            this.hotKeysToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGetKeys
            // 
            this.btnGetKeys.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGetKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetKeys.Location = new System.Drawing.Point(338, 142);
            this.btnGetKeys.Name = "btnGetKeys";
            this.btnGetKeys.Size = new System.Drawing.Size(80, 42);
            this.btnGetKeys.TabIndex = 14;
            this.btnGetKeys.Text = "Get Keys of Record";
            this.btnGetKeys.UseVisualStyleBackColor = false;
            this.btnGetKeys.Click += new System.EventHandler(this.btnGetKeys_Click);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(12, 63);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(10, 13);
            this.lblTest.TabIndex = 15;
            this.lblTest.Text = " ";
            // 
            // btnGetText
            // 
            this.btnGetText.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGetText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetText.Location = new System.Drawing.Point(267, 142);
            this.btnGetText.Name = "btnGetText";
            this.btnGetText.Size = new System.Drawing.Size(65, 42);
            this.btnGetText.TabIndex = 16;
            this.btnGetText.Text = "Get Text of Record";
            this.btnGetText.UseVisualStyleBackColor = false;
            this.btnGetText.Click += new System.EventHandler(this.btnGetText_Click);
            // 
            // runInBackRoundPW
            // 
            this.runInBackRoundPW.Location = new System.Drawing.Point(267, 212);
            this.runInBackRoundPW.Name = "runInBackRoundPW";
            this.runInBackRoundPW.Size = new System.Drawing.Size(151, 20);
            this.runInBackRoundPW.TabIndex = 17;
            // 
            // runInBackRound
            // 
            this.runInBackRound.Location = new System.Drawing.Point(267, 190);
            this.runInBackRound.Name = "runInBackRound";
            this.runInBackRound.Size = new System.Drawing.Size(151, 23);
            this.runInBackRound.TabIndex = 18;
            this.runInBackRound.Text = "Run in Backround";
            this.runInBackRound.UseVisualStyleBackColor = true;
            this.runInBackRound.Click += new System.EventHandler(this.runInBackRound_Click);
            // 
            // times
            // 
            this.times.Location = new System.Drawing.Point(425, 116);
            this.times.Name = "times";
            this.times.Size = new System.Drawing.Size(115, 20);
            this.times.TabIndex = 19;
            this.times.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(546, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "time(s)";
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(425, 90);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(47, 20);
            this.speed.TabIndex = 21;
            // 
            // speedMode
            // 
            this.speedMode.FormattingEnabled = true;
            this.speedMode.Items.AddRange(new object[] {
            "faster",
            "slower"});
            this.speedMode.Location = new System.Drawing.Point(516, 90);
            this.speedMode.Name = "speedMode";
            this.speedMode.Size = new System.Drawing.Size(67, 21);
            this.speedMode.TabIndex = 22;
            this.speedMode.Text = "slower";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(473, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "time(s)";
            // 
            // RecordMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(595, 244);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.speedMode);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.times);
            this.Controls.Add(this.runInBackRound);
            this.Controls.Add(this.runInBackRoundPW);
            this.Controls.Add(this.btnGetText);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnGetKeys);
            this.Controls.Add(this.bntStart);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnAllTrace);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.btnMouseTrace);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.lblLMBP);
            this.Controls.Add(this.lblLastKeyPressed);
            this.Controls.Add(this.lblMousePosition);
            this.Controls.Add(this.btnMouse);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RecordMenu";
            this.Text = "RecordMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecordMenu_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.times)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMouse;
        private System.Windows.Forms.Label lblMousePosition;
        private System.Windows.Forms.Label lblLastKeyPressed;
        private System.Windows.Forms.Label lblLMBP;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnMouseTrace;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.Button btnAllTrace;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button bntStart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnGetKeys;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Button btnGetText;
        private System.Windows.Forms.TextBox runInBackRoundPW;
        private System.Windows.Forms.Button runInBackRound;
        private System.Windows.Forms.NumericUpDown times;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown speed;
        private System.Windows.Forms.ComboBox speedMode;
        private System.Windows.Forms.Label label2;
    }
}

