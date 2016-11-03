using System;
using System.Linq;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using VirtualIntput.Recording;
using System.Collections.Generic;

namespace VirtualIntput.Editor
{
    public partial class VirtualInputEditor : Form
    {
        Form toHide;
        public VirtualInputEditor(String txt, bool isCompiler , Form parent)
        {
            InitializeComponent();
            toHide = parent;
            toHide.Hide();
            editBox.AcceptsTab = true;
            editBox.Text = txt;
            if (!isCompiler)
            {
                this.Text = "Text Editor";
                addCommandToolStripMenuItem.Visible = false;
                compileToolStripMenuItem.Visible = false;
                runToolStripMenuItem.Visible = false;
                fileType = "TextFile";
                fileEnding = "TextFile|*.txt";
            }
            else
            {
                fileType = "VirtualInput";
                fileEnding = "VirtualInput|*.VirtualInput";
            }
        }
        String fileType, fileEnding;

        public string getText()
        {
            return editBox.Text;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
          //  editBox.Size = new Size(this.Width, this.Height);
        }

        private void addCommand(object sender, EventArgs e)
        {
            int i = editBox.SelectionStart;
            editBox.Text = editBox.Text.Insert(i, ((ToolStripMenuItem)sender).Text + "\n");
            editBox.SelectionStart = i + ((ToolStripMenuItem)sender).Text.Length +1;
        }
        private string lasFileName = null;
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = fileEnding;
            saveFileDialog1.Title = "Save an  " + fileType + " File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName  != "")
            {
                lasFileName = saveFileDialog1.FileName;
                File.WriteAllText(lasFileName, editBox.Text);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lasFileName != null)
                File.WriteAllText(lasFileName, editBox.Text);
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.Msg == 256)
            {
                if (keyData == (Keys.Control | Keys.S))
                {
                    saveToolStripMenuItem_Click(null, null);
                }
                if (keyData == (Keys.Control | Keys.O))
                {
                    openToolStripMenuItem_Click(null, null);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter =  fileEnding;
            openFileDialog1.Title = "Select a "+ fileType +" File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lasFileName = openFileDialog1.FileName;
                editBox.Text = File.ReadAllText(lasFileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Interpreter.Interpreter.interpret(editBox.Text) != null)
            {
                compileToolStripMenuItem.BackColor = System.Drawing.Color.FromName("LawnGreen");
            }
            else
            {
                compileToolStripMenuItem.BackColor = System.Drawing.Color.FromName("LightCoral");
            }
        }

        private void VirtualInputEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            toHide.Show();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String txt = editBox.Text;
            new Thread(() => {
                LinkedList<ClickInfo> rec = Interpreter.Interpreter.interpret(txt);
            if (rec != null)
                Recording.Player.play(rec.ToArray(), new BoolWrapper(true), 1);
            }).Start();
        }
    }
}
