using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualIntput.MouseAndKeyboard;

namespace VirtualIntput.Recording
{
    class Player
    {
        public static bool isPlaying {private set; get;} = false;

        public static string getKeysAsString(ClickInfo[] record)
        {
            isPlaying = true;
            string res = "";
            // int a = record.Count;
            foreach (ClickInfo rec in record)
            {
                if (rec.info == ClickInfo.InputStates.KEY && rec.press)
                {
                    res += (Keys)rec.msg;
                }
            }
            isPlaying = false;
            return res;
        }
        public static void wirteText(ClickInfo[] record)
        {
            isPlaying = true;
            foreach (ClickInfo rec in record)
            {
                if (rec.info == ClickInfo.InputStates.KEY)
                {
                    KeyBoardSimulator.keyBoard.eventKeyBoard((Keys)rec.msg, rec.press);
                }
            }
            isPlaying = false;
        }

        public static void play(ClickInfo[] record, BoolWrapper running , double sleepFactor)
        {
            isPlaying = true;

            foreach (ClickInfo rec in record)
            {
                if (!running.Value) return;
                Thread.Sleep((int)(rec.timeSinceLast * sleepFactor));
                if (!running.Value) return;
                
                if (rec.info == ClickInfo.InputStates.VIRTUALMOUSE)
                {
                    Mouse.mouse.eventMouse((VirtualMouseMessages)rec.msg);
                    
                    if (rec.hasPosition)
                        Cursor.Position = rec.position;
                }
                else if (rec.info == ClickInfo.InputStates.MOUSECLICK)
                {
                    VirtualMouseMessages msg = 0;
                    switch ((MouseMessages)rec.msg)
                    {
                        case MouseMessages.LeftMouseButtonDown: msg = VirtualMouseMessages.LeftMouseButtonDown; break;
                        case MouseMessages.LedtMouseButtonUp: msg = VirtualMouseMessages.LedtMouseButtonUp; break;
                        case MouseMessages.MouseWeel: msg = VirtualMouseMessages.MouseWeel; break;
                        case MouseMessages.RigthMouseButtonDown: msg = VirtualMouseMessages.RigthMouseButtonDown; break;
                        case MouseMessages.RigthMouseButtonUp: msg = VirtualMouseMessages.RigthMouseButtonUp; break;
                        case MouseMessages.MouseWeelDown: msg = VirtualMouseMessages.MouseWeelDown; break;
                        case MouseMessages.MouseWeelUp: msg = VirtualMouseMessages.MouseWeelUp; break;
                    }
                    Mouse.mouse.eventMouse(msg);
                    if (rec.hasPosition)
                        Cursor.Position = rec.position;
                }
                else if (rec.info == ClickInfo.InputStates.KEY)
                {
                    KeyBoardSimulator.keyBoard.eventKeyBoard((Keys)rec.msg, rec.press);
                }
                else if (rec.info == ClickInfo.InputStates.MOUSEMOVE)
                {
                    if (rec.hasPosition)
                        Cursor.Position = rec.position;
                }



            }
            isPlaying = false;
        }
        public static void write(ClickInfo[] record, string path)
        {
            File.WriteAllText(path, write(record));
        }
        public static string write(ClickInfo[] record)
        {
            String textToWrite = "";

            

            isPlaying = true;
            // int a = record.Count;
            foreach (ClickInfo rec in record)
            {
                if(rec.timeSinceLast != 0)
                    textToWrite += "Sleep(" + rec.timeSinceLast + ");\t";

                if (rec.info == ClickInfo.InputStates.VIRTUALMOUSE)
                { 
                    textToWrite += "" + (VirtualMouseMessages)rec.msg + "(" + rec.position.X + " , " + rec.position.Y + ");";
                }
                else if (rec.info == ClickInfo.InputStates.MOUSECLICK)
                {
                    VirtualMouseMessages msg = 0;
                    switch ((MouseMessages)rec.msg)
                    {
                        case MouseMessages.LeftMouseButtonDown: msg = VirtualMouseMessages.LeftMouseButtonDown; break;
                        case MouseMessages.LedtMouseButtonUp: msg = VirtualMouseMessages.LedtMouseButtonUp; break;
                        case MouseMessages.MouseWeel: msg = VirtualMouseMessages.MouseWeel; break;
                        case MouseMessages.RigthMouseButtonDown: msg = VirtualMouseMessages.RigthMouseButtonDown; break;
                        case MouseMessages.RigthMouseButtonUp: msg = VirtualMouseMessages.RigthMouseButtonUp; break;
                        case MouseMessages.MouseWeelDown: msg = VirtualMouseMessages.MouseWeelDown; break;
                        case MouseMessages.MouseWeelUp: msg = VirtualMouseMessages.MouseWeelUp; break;
                        case 0: textToWrite += "setMousePos(" + rec.position.X + " , " + rec.position.Y + ");"; break;
                    }

                    
                    // Mouse.mouse.eventMouse(msg);
                    if (msg != 0)
                        textToWrite += "" + msg + "(" +rec.position.X + " , " + rec.position.Y + ");";
                }
                else if (rec.info == ClickInfo.InputStates.KEY)
                {
                    textToWrite += ""+ (rec.press ? "keyDown(":"keyUp(" )+ ((int) rec.msg) +");" ;
                }
                else if (rec.info == ClickInfo.InputStates.MOUSEMOVE)
                {
                    textToWrite += "setMousePos(" + rec.position.X + " , " + rec.position.Y + ");";
                }

                //Thread.Sleep(rec.timeSinceLast);

                textToWrite += "\n";
            }
            




             //.VirtualInput

            isPlaying = false;
            return textToWrite;
        }
    }
}
