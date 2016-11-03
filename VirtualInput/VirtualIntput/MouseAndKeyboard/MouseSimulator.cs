using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualIntput.MouseAndKeyboard
{
    
    class Mouse
    {
        public static Mouse mouse { private set; get; } = new Mouse();
        private Mouse() { }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, int dwExtraInfo);
       

        public Point Position {
            get { return Cursor.Position; }
            set { Cursor.Position = value; }
        }


        public void eventMouse(VirtualMouseMessages MouseEvent)
        {
            mouse_event((uint)MouseEvent, 50, 50, 0, 0);
        }
        public void eventMouse(VirtualMouseMessages MouseEvent, uint a, uint b)
        {
            mouse_event((uint)MouseEvent, a, b, 0, 0);
        }

    }
}
