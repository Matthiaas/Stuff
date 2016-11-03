namespace VirtualIntput.Editor
{
    partial class VirtualInputEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftMouseButtonDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledtMouseButtonUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rigthMouseButtonDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rigthMouseButtonUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyDownkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyUpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sleeptimeInMIllisecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMousePosxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addCommandToolStripMenuItem,
            this.compileToolStripMenuItem,
            this.runToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(599, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // addCommandToolStripMenuItem
            // 
            this.addCommandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftMouseButtonDownToolStripMenuItem,
            this.ledtMouseButtonUpToolStripMenuItem,
            this.rigthMouseButtonDownToolStripMenuItem,
            this.rigthMouseButtonUpToolStripMenuItem,
            this.keyDownToolStripMenuItem,
            this.keyUpToolStripMenuItem,
            this.keyDownkeyToolStripMenuItem,
            this.keyUpToolStripMenuItem1,
            this.sleeptimeInMIllisecondsToolStripMenuItem,
            this.setMousePosxyToolStripMenuItem});
            this.addCommandToolStripMenuItem.Name = "addCommandToolStripMenuItem";
            this.addCommandToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.addCommandToolStripMenuItem.Text = "Add Command";
            // 
            // leftMouseButtonDownToolStripMenuItem
            // 
            this.leftMouseButtonDownToolStripMenuItem.Name = "leftMouseButtonDownToolStripMenuItem";
            this.leftMouseButtonDownToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.leftMouseButtonDownToolStripMenuItem.Text = "LeftMouseButtonDown();";
            this.leftMouseButtonDownToolStripMenuItem.Click += new System.EventHandler(this.addCommand);
            // 
            // ledtMouseButtonUpToolStripMenuItem
            // 
            this.ledtMouseButtonUpToolStripMenuItem.Name = "ledtMouseButtonUpToolStripMenuItem";
            this.ledtMouseButtonUpToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.ledtMouseButtonUpToolStripMenuItem.Text = "LedtMouseButtonUp();";
            this.ledtMouseButtonUpToolStripMenuItem.Click += new System.EventHandler(this.addCommand);
            // 
            // rigthMouseButtonDownToolStripMenuItem
            // 
            this.rigthMouseButtonDownToolStripMenuItem.Name = "rigthMouseButtonDownToolStripMenuItem";
            this.rigthMouseButtonDownToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.rigthMouseButtonDownToolStripMenuItem.Text = "RigthMouseButtonDown();";
            this.rigthMouseButtonDownToolStripMenuItem.Click += new System.EventHandler(this.addCommand);
            // 
            // rigthMouseButtonUpToolStripMenuItem
            // 
            this.rigthMouseButtonUpToolStripMenuItem.Name = "rigthMouseButtonUpToolStripMenuItem";
            this.rigthMouseButtonUpToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.rigthMouseButtonUpToolStripMenuItem.Text = "RigthMouseButtonUp();";
            this.rigthMouseButtonUpToolStripMenuItem.Click += new System.EventHandler(this.addCommand);
            // 
            // keyDownToolStripMenuItem
            // 
            this.keyDownToolStripMenuItem.Name = "keyDownToolStripMenuItem";
            this.keyDownToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.keyDownToolStripMenuItem.Text = "MouseWeelDown();";
            this.keyDownToolStripMenuItem.Click += new System.EventHandler(this.addCommand);
            // 
            // keyUpToolStripMenuItem
            // 
            this.keyUpToolStripMenuItem.Name = "keyUpToolStripMenuItem";
            this.keyUpToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.keyUpToolStripMenuItem.Text = "MouseWeelUp();";
            this.keyUpToolStripMenuItem.Click += new System.EventHandler(this.addCommand);
            // 
            // keyDownkeyToolStripMenuItem
            // 
            this.keyDownkeyToolStripMenuItem.Name = "keyDownkeyToolStripMenuItem";
            this.keyDownkeyToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.keyDownkeyToolStripMenuItem.Text = "keyDown(key);";
            this.keyDownkeyToolStripMenuItem.Click += new System.EventHandler(this.addCommand);
            // 
            // keyUpToolStripMenuItem1
            // 
            this.keyUpToolStripMenuItem1.Name = "keyUpToolStripMenuItem1";
            this.keyUpToolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.keyUpToolStripMenuItem1.Text = "keyUp(key);";
            this.keyUpToolStripMenuItem1.Click += new System.EventHandler(this.addCommand);
            // 
            // sleeptimeInMIllisecondsToolStripMenuItem
            // 
            this.sleeptimeInMIllisecondsToolStripMenuItem.Name = "sleeptimeInMIllisecondsToolStripMenuItem";
            this.sleeptimeInMIllisecondsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.sleeptimeInMIllisecondsToolStripMenuItem.Text = "Sleep(timeInMIlliseconds);";
            this.sleeptimeInMIllisecondsToolStripMenuItem.Click += new System.EventHandler(this.addCommand);
            // 
            // setMousePosxyToolStripMenuItem
            // 
            this.setMousePosxyToolStripMenuItem.Name = "setMousePosxyToolStripMenuItem";
            this.setMousePosxyToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.setMousePosxyToolStripMenuItem.Text = "setMousePos(x,y);";
            this.setMousePosxyToolStripMenuItem.Click += new System.EventHandler(this.addCommand);
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.compileToolStripMenuItem.Text = "Compile";
            this.compileToolStripMenuItem.Click += new System.EventHandler(this.compileToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // editBox
            // 
            this.editBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editBox.Location = new System.Drawing.Point(0, 24);
            this.editBox.Name = "editBox";
            this.editBox.Size = new System.Drawing.Size(599, 422);
            this.editBox.TabIndex = 1;
            this.editBox.Text = "";
            // 
            // VirtualInputEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 446);
            this.Controls.Add(this.editBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VirtualInputEditor";
            this.Text = "Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VirtualInputEditor_FormClosed);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftMouseButtonDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledtMouseButtonUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rigthMouseButtonDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rigthMouseButtonUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyDownkeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyUpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sleeptimeInMIllisecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setMousePosxyToolStripMenuItem;
        private System.Windows.Forms.RichTextBox editBox;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
    }
}