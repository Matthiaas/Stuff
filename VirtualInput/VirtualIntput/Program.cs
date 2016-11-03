using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualIntput.MouseAndKeyboard;

namespace VirtualIntput
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

           

            KeyBoardHook.start();
            MouseHook.start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            if (args.Length == 1)
            {
                FileInfo file = new FileInfo(args[0]);
                if (file.Exists)
                {
                    Application.Run(new RecordMenu(args[0], null));

                }
                else
                    Application.Run(new StartUp());
            }
            else
                Application.Run(new StartUp());

            KeyBoardHook.startAfterWindow();
            MouseHook.startAfterWindow();

           
            /*

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HotKeys(null));
            */
        }

    }
}
