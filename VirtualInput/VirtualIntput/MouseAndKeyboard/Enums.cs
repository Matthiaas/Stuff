using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIntput
{
    public enum MouseMessages
    {
        LeftMouseButtonDown = 0x0201,
        LedtMouseButtonUp = 0x0202,
        MouseMove = 0x0200,
        MouseWeel = 0x020A,
        RigthMouseButtonDown = 0x0204,
        RigthMouseButtonUp = 0x0205,
        MouseWeelDown = 519,
        MouseWeelUp = 520
    }

    public enum VirtualMouseMessages  
    {
        LeftMouseButtonDown = 0x02,
        LedtMouseButtonUp = 0x04,
        RigthMouseButtonDown = 0x08,
        RigthMouseButtonUp = 0x10,
        MouseWeelDown = 0x20,
        MouseWeelUp = 0x40,
        MouseWeel= 0x800,
        NULL
    }

    public enum VirtualCommand
    {
        KEYDOWN ,
        KEYUP, 
        SLEEP,        
        SETMOUSEPOS ,
        DECLARECAIABLE,
        VARIABLE,
        NULL      
    }

    public enum RecordOption
    {
        MOUSETRACE = 0,
        MOUSE = 1,
        KEYBOARD =2,
        ALLTRACE = 3 ,
        ALL = 4,
        PLAY = 4,
        NULL

    }
}
