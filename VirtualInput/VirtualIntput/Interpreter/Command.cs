using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIntput.Interpreter
{
    public class Command
    {
        public VirtualCommand keyCommand { get; private set; } = VirtualCommand.NULL;
        public VirtualMouseMessages mouseCommand { get; private set; } = VirtualMouseMessages.NULL ;

        public Command(VirtualCommand keyCommand)
        {
            this.keyCommand = keyCommand;
        }
        public Command(VirtualMouseMessages mouseCommand)
        {
            this.mouseCommand = mouseCommand;
        }
    }
}
