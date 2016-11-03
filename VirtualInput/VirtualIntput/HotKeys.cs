using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualIntput
{
    public partial class HotKeys : Form
    {
        Keys[] hotKeys;
        Button[] bnts;
        public HotKeys(Keys[] hotKeys)
        {
            this.hotKeys = hotKeys;
            
            InitializeComponent();
            bnts = new Button[] { button1, button2, button3, button4, button5 , button6  , button7 };
            for (int i = 0; i < hotKeys.Length; i++)
            {
                if (hotKeys[i] != 0)
                {
                    bnts[i].Text = "" + hotKeys[i];
                }
            }
        }
        private void clearALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach(Button b in bnts)
            {
                b.Text =  "Click To Set Hotkey";
                hotKeys[i] = 0;
                i++;
            }
        }
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            ((Button)sender).Text = ""+ e.KeyCode;
            hotKeys[0] = e.KeyCode;
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            ((Button)sender).Text = "" + (Keys)e.KeyCode;
            hotKeys[1] = e.KeyCode;
        }
        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            ((Button)sender).Text = "" + (Keys)e.KeyCode;
            hotKeys[2] = e.KeyCode;
        }
        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            ((Button)sender).Text = "" + (Keys)e.KeyCode;
            hotKeys[3] = e.KeyCode;
        }
        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            ((Button)sender).Text = "" + (Keys)e.KeyCode;
            hotKeys[4] = e.KeyCode;
        }

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            ((Button)sender).Text = "" + (Keys)e.KeyCode;
            hotKeys[5] = e.KeyCode;
        }

        private void button7_KeyDown(object sender, KeyEventArgs e)
        {
            ((Button)sender).Text = "" + (Keys)e.KeyCode;
            hotKeys[6] = e.KeyCode;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            button1.Text = "Click To Set Hotkey";
            hotKeys[0] = 0;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            button2.Text = "Click To Set Hotkey";
            hotKeys[1] = 0;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            button3.Text = "Click To Set Hotkey";
            hotKeys[2] = 0;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            button4.Text = "Click To Set Hotkey";
            hotKeys[3] = 0;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            button5.Text = "Click To Set Hotkey";
            hotKeys[4] = 0;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            button6.Text = "Click To Set Hotkey";
            hotKeys[5] = 0;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            button7.Text = "Click To Set Hotkey";
            hotKeys[6] = 0;
        }
    }
}
