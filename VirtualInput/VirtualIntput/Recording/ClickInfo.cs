using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIntput.Recording
{
    public class ClickInfo
    {
        public InputStates info; 
        public enum InputStates { KEY = 0, MOUSECLICK = 1, VIRTUALMOUSE = 2, MOUSEMOVE = 3, SLEEP = 4 }
        public Object msg;
        public Point position;
        public bool hasPosition = false;
        public int timeSinceLast;
        public bool press;
        // Mouse
        public ClickInfo( MouseMessages input, Point pos, int timeSinceLast)
        {
            hasPosition = true;
            this.info = InputStates.MOUSECLICK;
            msg = input;
            position = pos;
            this.timeSinceLast = timeSinceLast;
        }
        //Mouse Move
        public ClickInfo( Point pos, int timeSinceLast)
        {
            hasPosition = true;
            this.info = InputStates.MOUSEMOVE;
            position = pos;
            this.timeSinceLast = timeSinceLast;
        }
        // Mouse from Code
        public ClickInfo( VirtualMouseMessages input, int timeSinceLast)
        {
            this.info = InputStates.VIRTUALMOUSE;
            msg = input;
            this.timeSinceLast = timeSinceLast;
        }
        // Mouse from Code
        public ClickInfo(VirtualMouseMessages input, Point pos, int timeSinceLast)
        {
            hasPosition = true;
            position = pos;
            this.info = InputStates.VIRTUALMOUSE;
            msg = input;
            this.timeSinceLast = timeSinceLast;
        }
        // KEY
        public ClickInfo( int key, Point pos, int timeSinceLast, bool press)
        {
            hasPosition = true;
            info = InputStates.KEY;
            msg = key;
            position = pos;
            this.press = press;
            this.timeSinceLast = timeSinceLast;
        }
        // KEY from Code
        public ClickInfo( int key, int timeSinceLast, bool press)
        {
            info = InputStates.KEY;
            msg = key;
            this.press = press;
            this.timeSinceLast = timeSinceLast;
        }
        // Sleep
        public ClickInfo(int timeSinceLast)
        {
            info = InputStates.SLEEP;
            this.timeSinceLast = timeSinceLast;
        }
    }

}
