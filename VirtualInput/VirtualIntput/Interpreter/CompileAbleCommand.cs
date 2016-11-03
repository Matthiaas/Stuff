using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIntput.Interpreter
{
    class CompileAbleCommand
    {
        public Command com;
        public string[] info;
        public bool hasPosition = false;

        public CompileAbleCommand(Command com, LinkedList<string> info , bool hasPos)
        {
            this.hasPosition = hasPos;
            this.com = com;
            if (info != null)
                this.info = info.ToArray();

        }

    }
}
