using System;
using System.Threading;
using System.Windows.Forms;
using VirtualIntput.MouseAndKeyboard;

namespace VirtualIntput.ClickBot
{
    public partial class ClickBotForm : Form
    {
        Keys hotKey;
        Button btn;
        StartUp start;
        public ClickBotForm(Button btn , StartUp start)
        {
            start.Hide();
            this.start = start;
            this.btn = btn;
            InitializeComponent();
            KeyBoardHook.keyAction = keyPressed;
        }


        public void keyPressed(int a, bool press)
        {
           
            if (!press && (Keys)a == hotKey && !isRunnig)
            {
                if (mouseKey == VirtualMouseMessages.NULL)
                {
                    lblError.Text = "No mousekey selected";
                    return;
                }
                isRunnig = true;
                double sleep;
                if (double.TryParse(tbSpeed.Text, out sleep))
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0: sleep =  1000 / sleep; break;
                        case 1: sleep =  1000 * 60 / sleep; break;
                        case 2: sleep =  1000 * 60 * 60 / sleep; break;
                        case 3: sleep =  1000 * 60 * 60 * 24 / sleep; break;
                    }
                    startClickBot((int)(sleep));
                    NotifyClickBotStart.Icon = System.Drawing.SystemIcons.Application;
                    NotifyClickBotStart.BalloonTipText = "You can stop the Click-Bot by clicking: \n" + hotKey;
                    NotifyClickBotStart.ShowBalloonTip(2000);
                    startClickBot((int)(sleep * 1000));
                    NotifyClickBotStart.Icon = System.Drawing.SystemIcons.Application;
                    NotifyClickBotStart.BalloonTipText = "You can stop the Click-Bot by clicking: \n" + hotKey;
                    NotifyClickBotStart.ShowBalloonTip(2000);
                }
                else
                    lblError.Text = "No correct INPUT";

            }
            else if (!press && (Keys)a == hotKey)
                isRunnig = false;
        }
        public void startClickBot(int sleep)
        {
            lblError.Text = (sleep/1000.0 ) + " clicks per Second";
            new Thread(() =>
            {
                while (isRunnig)
                {
          ;
                    Mouse.mouse.eventMouse(mouseKey);
                    Mouse.mouse.eventMouse(mouseKeyRelease);
                    Thread.Sleep(sleep);
                    
                }
            }).Start();
        }

        private bool isRunnig;
        private VirtualMouseMessages mouseKey = VirtualMouseMessages.NULL, mouseKeyRelease = VirtualMouseMessages.NULL;
        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            ((Button)sender).Text = "" + e.KeyCode;
            hotKey = e.KeyCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblBnt.Text = "Button: Left";
            mouseKey = VirtualMouseMessages.LeftMouseButtonDown;
            mouseKeyRelease = VirtualMouseMessages.LedtMouseButtonUp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblBnt.Text = "Button: Mid";
            mouseKey = VirtualMouseMessages.MouseWeelDown;
            mouseKeyRelease = VirtualMouseMessages.MouseWeelUp;
        }

        private void ClickBot_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRunnig = false;
            start.Show();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            lblBnt.Text = "Button: Rigth";
            mouseKey = VirtualMouseMessages.RigthMouseButtonDown;
            mouseKeyRelease = VirtualMouseMessages.RigthMouseButtonUp;
        }
    }
}
