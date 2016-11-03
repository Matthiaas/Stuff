namespace VirtualIntput.ClickBot
{
    partial class ClickBotForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.Speed = new System.Windows.Forms.Label();
            this.lblBnt = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.NotifyClickBotStart = new System.Windows.Forms.NotifyIcon(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(0, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 173);
            this.button1.TabIndex = 0;
            this.button1.Text = "Left";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(96, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 173);
            this.button2.TabIndex = 1;
            this.button2.Text = "M I D";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(138, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 173);
            this.button3.TabIndex = 2;
            this.button3.Text = "Rigth";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(12, 217);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(106, 20);
            this.tbSpeed.TabIndex = 3;
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.BackColor = System.Drawing.Color.Transparent;
            this.Speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed.ForeColor = System.Drawing.Color.Red;
            this.Speed.Location = new System.Drawing.Point(9, 198);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(58, 16);
            this.Speed.TabIndex = 5;
            this.Speed.Text = "Speed:";
            // 
            // lblBnt
            // 
            this.lblBnt.AutoSize = true;
            this.lblBnt.BackColor = System.Drawing.Color.Transparent;
            this.lblBnt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBnt.Location = new System.Drawing.Point(12, 240);
            this.lblBnt.Name = "lblBnt";
            this.lblBnt.Size = new System.Drawing.Size(41, 13);
            this.lblBnt.TabIndex = 7;
            this.lblBnt.Text = "Button:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(12, 294);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 31);
            this.button4.TabIndex = 8;
            this.button4.Text = "Click To Set Hot-Key";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button4_KeyDown);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Location = new System.Drawing.Point(12, 253);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 9;
            // 
            // NotifyClickBotStart
            // 
            this.NotifyClickBotStart.Text = "Stop Clickbot";
            this.NotifyClickBotStart.Visible = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "per Second",
            "per Minute",
            "per Hour",
            "per Day (24h)"});
            this.comboBox1.Location = new System.Drawing.Point(124, 216);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(98, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // ClickBotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VirtualIntput.Properties.Resources.mouse;
            this.ClientSize = new System.Drawing.Size(234, 337);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lblBnt);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "ClickBotForm";
            this.Text = "ClickBot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClickBot_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbSpeed;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.Label lblBnt;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.NotifyIcon NotifyClickBotStart;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}