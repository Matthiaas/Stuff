using System;
using System.Collections.Generic;
using System.Linq;


namespace VirtualIntput.Interpreter
{
    class InputTree
    {
        public String[] CommandName 
            = new string[] { "LeftMouseButtonDown", "LedtMouseButtonUp", "MouseWeelDown", "MouseWeelUp"
                , "RigthMouseButtonDown", "RigthMouseButtonUp", "keyDown", "keyUp" , "Sleep" , "setMousePos", "var"};

        public Command[] CommandType
            = new Command[] { new Command(VirtualMouseMessages.LeftMouseButtonDown) , new Command(VirtualMouseMessages.LedtMouseButtonUp),
                new Command(VirtualMouseMessages.MouseWeelDown) , new Command(VirtualMouseMessages.MouseWeelUp),
                    new Command(VirtualMouseMessages.RigthMouseButtonDown) , new Command(VirtualMouseMessages.RigthMouseButtonUp),
                        new Command(VirtualCommand.KEYDOWN) , new Command(VirtualCommand.KEYUP),  new Command(VirtualCommand.SLEEP), new Command(VirtualCommand.SETMOUSEPOS), new Command(VirtualCommand.DECLARECAIABLE) };

        Node start = new Node((char)0);

        public InputTree()
        {
            int i = 0;
            foreach(String command in CommandName)
            {
                start.add(command.ToCharArray(), 0 , CommandType[i] , 0);
                i++;
            }
        }

        public void insertCommand(String name , Command c , int value)
        {
           
            start.add(name.ToCharArray(), 0, c , value);
        }

        public CompileAbleCommand findcommand(String command)
        {
            return start.find(command.ToCharArray() ,0);
        }

        public bool findValue(String varName, out int value)
        {
            return start.findValue(varName.ToCharArray(), 0 , out value);
        }

        public bool changeValue(String varName , int value)
        {
            // return start.find(varName, 0);
            return false;
        }







        private class Node
        {
            LinkedList<Node> next;
            char Char;
            Command cmd = null;
            int value;
            public Node(char Char)
            {
                this.Char = Char;
            }

            public void add(Char[] toAdd, int i, Command cmd , int value )
            {
                
                if (i == toAdd.Length)
                {
                   
                    
                    this.value = value;
                    this.cmd = cmd;
                    return;
                }
                if (next == null)
                    next = new LinkedList<Node>();

                this[toAdd[i]] = new Node(toAdd[i ]);
                this[toAdd[i]].add(toAdd, i +1, cmd, value);
            }
            public CompileAbleCommand find(Char[] cmd, int i)
            {
                if (this.cmd != null  && (cmd.Length == i || cmd[i] == '(' || this.cmd.keyCommand == VirtualCommand.DECLARECAIABLE))
                {
                    LinkedList<string> info = new LinkedList<string>();
                    if(this.cmd.keyCommand != VirtualCommand.DECLARECAIABLE)
                        i++;
                    String value = "";
                    bool hasPos = false;
                    while (cmd.Length > i && cmd[i] != ')')
                    {
                        value = "";
                        while (cmd.Length != i && cmd[i] != ')' && cmd[i] != '='  && cmd[i] != ',' && cmd[i] != '+')
                        {
                            value += cmd[i];
                            i++;
                        }
                        info.AddLast(value);
                        i++;
                    }
                    if (info.Count > 0)
                        hasPos = true;
                    
                    return new CompileAbleCommand(this.cmd, info, hasPos);


                }
                Node tmp = this[cmd[i]];
                if (tmp == null) return null;

                return (this[cmd[i]]).find(cmd, i + 1);

            }
            public bool findValue(Char[] cmd, int i , out int value)
            {
                if (i  == cmd.Length && this.cmd != null && this.cmd.keyCommand == VirtualCommand.DECLARECAIABLE)
                {
                    value = this.value;
                    return true;
                }
               
                Node tmp = this[cmd[i]];
                if (tmp == null) { value = 0;  return false; }

                return (this[cmd[i]]).findValue(cmd, i + 1, out value);

            }


            Node this[char index]
            {
                get {
                    foreach (Node n in next) { if (n.Char == index) return n; } return null;
                }
                set
                {
                    if (this[index] == null)
                        next.AddLast(value);
                }
            }
        }
    }
}
