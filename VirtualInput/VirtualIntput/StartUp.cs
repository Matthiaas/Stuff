using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualIntput.MouseAndKeyboard;
using VirtualIntput.ClickBot;
using VirtualIntput.Editor;


namespace VirtualIntput
{
    public partial class StartUp : Form
    {
        ClickBotForm clickBot;
        RecordMenu recorder;
        VirtualInputEditor editor;
        private bool isClickBotWindowClosed { get { return clickBot == null || clickBot.IsDisposed; } }

        public StartUp()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            KeyBoardHook.keyAction = keyPress;
            MouseHook.mouseClicked = mousePress;
        }
        public void keyPress(int a, bool press) { }
        private void mousePress(MouseMessages msg, int posx, int posy) { }

        private void button1_Click(object sender, EventArgs e)
        {
            recorder = new RecordMenu("" , this);
            recorder.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clickBot = new ClickBotForm(button2 , this);
            clickBot.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new VirtualInputEditor("" , true ,this).Show();
        }
    }
}
