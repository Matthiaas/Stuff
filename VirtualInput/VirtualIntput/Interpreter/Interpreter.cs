using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VirtualIntput.Recording;

namespace VirtualIntput.Interpreter
{
    static class Interpreter
    {
        public static LinkedList<ClickInfo> interpretFromFile(String path )
        {
            string readText = File.ReadAllText(path);
            return  interpret(readText);
        }
        public static LinkedList<ClickInfo> interpret(string text)
        {
            LinkedList<ClickInfo> res = new LinkedList<ClickInfo>();
            LinkedList<int> lines;
            LinkedList<String> commands = toCommands(text, out lines);
            if (commands.Count == 0) return null;
           
            //
            LinkedList<String>.Enumerator enumerator = commands.GetEnumerator();
            LinkedList<int>.Enumerator linesEnumerator = lines.GetEnumerator();
            enumerator.MoveNext();
            linesEnumerator.MoveNext();

            InputTree commandFinder = new InputTree();

            bool gotAll = false;

            while (!gotAll)
            {
                String actualComand = enumerator.Current;
                int line = linesEnumerator.Current;

                if (!enumerator.MoveNext()) gotAll = true;
                linesEnumerator.MoveNext();

                String nextCommand = enumerator.Current;
                int lineNext = linesEnumerator.Current;

                CompileAbleCommand cmd = commandFinder.findcommand(actualComand);
                CompileAbleCommand cmdNext = null;
                if (nextCommand != null)
                {
                    cmdNext = commandFinder.findcommand(nextCommand);
                    if (cmdNext == null)
                    {
                        MessageBox.Show("Error in Line:" + lineNext + "\n In:  " + nextCommand);
                        return null;
                    }
                }

                if(cmd == null)
                {
                    MessageBox.Show("Error in Line:" + line + "\n Near:" + actualComand);
                    return null;
                }
                int cmd0= 0, cmd1 = 0, cmdNext0 = 0, cmdNext1 = 0;
                if (cmd.info != null && cmd.info.Length >=1 && cmd.com.keyCommand != VirtualCommand.DECLARECAIABLE)
                {
                    if (!int.TryParse(cmd.info[0], out cmd0))
                        if (!commandFinder.findValue(cmd.info[0], out cmd0))
                        {
                            MessageBox.Show("Error 0 in Line:" + line + "\n Near:" + cmd.info[0]);
                            return null;
                        }
                    
                    if (cmd.info.Length >= 2)
                        if (!int.TryParse(cmd.info[1], out cmd1))
                            if (!commandFinder.findValue(cmd.info[1], out cmd1))
                            {
                                MessageBox.Show("Error 1 in Line:" + line + "\n Near:" + cmd.info[1]);
                                return null;
                            }
                }
                if (cmdNext.info != null && cmdNext.info.Length >= 1 && cmdNext.com.keyCommand != VirtualCommand.DECLARECAIABLE)
                {
                    if (!int.TryParse(cmdNext.info[0], out cmdNext0))
                        if (!commandFinder.findValue(cmdNext.info[0], out cmdNext0))
                        {
                            MessageBox.Show("Error 2 in Line:" + line + "\n Near:" + cmdNext.info[0]);
                            return null;
                        }
                    if (cmdNext.info.Length >= 2)
                        if (!int.TryParse(cmdNext.info[1], out cmdNext1))
                            if (!commandFinder.findValue(cmdNext.info[1], out cmdNext1))
                            {
                                MessageBox.Show("Error 3 in Line:" + line + "\n Near:" + cmdNext.info[1]);
                                return null;
                            }
                }
                

                if (cmd.com.keyCommand == VirtualCommand.SLEEP && !gotAll)
                {
                    if (cmdNext != null)
                    {
                        if (cmdNext.com.keyCommand == VirtualCommand.DECLARECAIABLE && cmdNext.info != null)
                        {
                            res.AddLast(new ClickInfo(int.Parse(cmd.info[0])));
                            commandFinder.insertCommand(cmdNext.info[0], new Command(cmdNext.com.keyCommand), cmdNext1);
                        }
                        else if (cmdNext.com.keyCommand == VirtualCommand.SLEEP)
                        {
                            res.AddLast(new ClickInfo(int.Parse(cmd.info[0])));
                        }
                        else if (cmdNext.com.keyCommand == VirtualCommand.KEYDOWN || cmdNext.com.keyCommand == VirtualCommand.KEYUP)
                        {
                            res.AddLast(new ClickInfo(cmdNext0, cmd0, cmdNext.com.keyCommand == VirtualCommand.KEYDOWN));
                            enumerator.MoveNext(); linesEnumerator.MoveNext();
                        }
                        else if (cmdNext.com.keyCommand == VirtualCommand.SETMOUSEPOS)
                        {
                            res.AddLast(new ClickInfo(new Point(cmdNext0, cmdNext1), cmd0));
                            enumerator.MoveNext(); linesEnumerator.MoveNext();

                        }
                        else
                        {
                            if(cmdNext.hasPosition)
                                res.AddLast(new ClickInfo(cmdNext.com.mouseCommand, new Point(cmdNext0, cmdNext1), cmd0));
                            else
                                 res.AddLast(new ClickInfo(cmdNext.com.mouseCommand, cmd0));
                            enumerator.MoveNext();
                        }

                    }
                    else
                    {
                            res.AddLast(new ClickInfo(cmd0));
                    }

                       
                }
                else
                {
                    if (cmd.com.keyCommand == VirtualCommand.DECLARECAIABLE && cmd.info != null )
                    { 
                        commandFinder.insertCommand(cmd.info[0], new Command(cmd.com.keyCommand), int.Parse(cmd.info[1]));
                    }
                    else if (cmd.com.keyCommand == VirtualCommand.KEYDOWN || cmd.com.keyCommand == VirtualCommand.KEYUP)
                    {
                        res.AddLast(new ClickInfo(cmd0, 0, cmd.com.keyCommand == VirtualCommand.KEYDOWN));
                    }
                    else if (cmd.com.keyCommand == VirtualCommand.SETMOUSEPOS)
                    {
                        res.AddLast(new ClickInfo(new Point(cmd0, cmd1), 0));
                    }
                    else
                    {
                        if (cmd.hasPosition)
                            res.AddLast(new ClickInfo(cmd.com.mouseCommand, new Point(cmd0, cmd1), 0));
                        else
                            res.AddLast(new ClickInfo(cmd.com.mouseCommand , 0));
                    }
                }


                

            }

     
            return res;

        }

        private static LinkedList<String> toCommands(string text, out LinkedList<int> lines)
        {
            //System.NullReferenceException
            LinkedList<String> res = new LinkedList<string>();
            lines = new LinkedList<int>();
            int line = 0;
            string tempComand = "";
            while(text.Length != 0)
            {
                string temp;
                if (text.Length == 1)
                {
                    temp = text;
                    text = "";
                }
                else{
                    temp = text.Remove(1);
                    text = text.Substring(1);
                }
                
                if (temp == ";")
                {
                    res.AddLast(tempComand);
                    lines.AddLast(line);
                    tempComand = "";
                }else if(temp != " " && temp != "\n" && temp != "\t")
                {
                    tempComand += temp;
                }else if (temp == "\n")
                {
                    line++;
                }
                
            }

            return res;
        }

    }
}
