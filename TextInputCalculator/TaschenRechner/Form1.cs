using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interpreter;


namespace TaschenRechner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
              //  MessageBox.Show(Hi.Text);
                Hi.Text = "" + Interpreter.Interpreter.rechne(textBox2.Text);
               // Hi.Text = "" + Interpreter.Interpreter.solveLinear(textBox2.Text);
            }
            catch (System.FormatException ex) { Hi.Text = "Ungültige Zeichen"; }
            catch (System.StackOverflowException ex) { Hi.Text = "Ungültige Zeichen";  }
            catch (System.ArgumentException ex) { Hi.Text = ex.Message; }
           
        }


        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hi.Text = "" + Interpreter.Interpreter.rechne(textBox2.Text);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            textBox2.Width = this.Width - 40;
            button1.Location = new Point(this.Width - 30 - button1.Width , button1.Location.Y);
        }
    }
}
