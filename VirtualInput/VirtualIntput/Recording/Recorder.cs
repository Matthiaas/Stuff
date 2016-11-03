using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualIntput.Recording
{
    class Recorder
    {

        public bool isRecording { private set; get; } = false;
        Label status;
        long timeOfLastEvent = 0;
        public RecordOption activeOption { private set; get; } = RecordOption.NULL;

        public Recorder(Label status)
        {
            this.status = status;
            

        }
        

        public bool startRecording(RecordOption option)
        {
            if (Player.isPlaying) return false; 
            activeOption = option;
            clicks = new LinkedList<ClickInfo>();
            if (isRecording) return false;
            isRecording = true;
            (new Thread(() => timer())).Start();
            if(option == RecordOption.ALLTRACE || option == RecordOption.MOUSETRACE )
             (new Thread(() => {

                while (isRecording)
                {
                     Thread.Sleep(10);
                     long temp = watch.ElapsedMilliseconds;
                     clicks.AddLast(new ClickInfo(  Cursor.Position,(int) (temp - timeOfLastEvent)));
                     timeOfLastEvent = temp;
                 }

            })).Start();


            return true;
        }



        public LinkedList<ClickInfo> stop()
        {
            isRecording = false;
            Thread.Sleep(15);
            return clicks;
        }


        LinkedList<ClickInfo> clicks;

        
      

        public void keyPressed(int key , bool press)
        {
            if (activeOption == RecordOption.MOUSE || activeOption == RecordOption.MOUSETRACE || activeOption == RecordOption.NULL) return;

            long temp  = watch.ElapsedMilliseconds;
            clicks.AddLast(new ClickInfo( key, Cursor.Position, (int)(temp - timeOfLastEvent), press));
            timeOfLastEvent = temp;

        }
        public void MousePressed(MouseMessages msg)
        {
            if (activeOption == RecordOption.KEYBOARD || activeOption == RecordOption.NULL) return;
            long temp = watch.ElapsedMilliseconds;
            clicks.AddLast(new ClickInfo(msg, Cursor.Position, (int)(temp - timeOfLastEvent)));


            timeOfLastEvent = temp;

        }

        private Stopwatch watch;
        public void timer()
        {
            watch = Stopwatch.StartNew();

            while (isRecording)
            {
                if (status.InvokeRequired)
                {
                    status.BeginInvoke((MethodInvoker)delegate () { status.Text = "" + watch.Elapsed; });
                }
                else
                {
                    status.Text = "" + watch.Elapsed;
                }
                Thread.Sleep(10);
                
            }
        }
    }
}
