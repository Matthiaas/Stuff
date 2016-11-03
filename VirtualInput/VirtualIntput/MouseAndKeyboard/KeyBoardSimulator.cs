using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIntput.MouseAndKeyboard
{
    class KeyBoardSimulator
    {
        public static KeyBoardSimulator keyBoard { private set; get; } = new KeyBoardSimulator();
        private KeyBoardSimulator() { }


        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        const uint KEYEVENTF_KEYUP = 0x0002;

        public void eventKeyBoard(System.Windows.Forms.Keys key, bool press)
        {
            if(press)
                keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            else
                keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }   
    }
}
