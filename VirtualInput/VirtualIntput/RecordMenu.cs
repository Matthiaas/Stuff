using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using VirtualIntput.Recording;
using VirtualIntput.MouseAndKeyboard;

namespace VirtualIntput
{
    public partial class RecordMenu : Form
    {

        Recorder recorder;
        Keys[] hotKeys;
        
        HotKeys hotKeyWindow;
        
        LinkedList<ClickInfo> lastRecord;
        private bool isHotKeyWindowClosed { get { return hotKeyWindow == null || hotKeyWindow.IsDisposed; } }
        StartUp start;
        public RecordMenu(String a , StartUp start)
        {
            this.start = start;
            if(start != null)
                start.Hide();
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            KeyBoardHook.keyAction = keyBoardPressGlobal;
            MouseHook.mouseClicked = mouseClickedGlobal;
            recorder = new Recorder(lblStatus);
            hotKeys = new Keys[7];
            bntStart.Visible = false;
            btnStop.Visible = false;
            btnGetText.Visible = false;
            btnGetKeys.Visible = false;
            
            if (a != "")
            {
                new Thread(() =>
                {
                    lastRecord = Interpreter.Interpreter.interpretFromFile(a);

                }).Start();
                bntStart.Visible = true;
            }

            

        }
        char[] pw;
        int pwIndex = 0;
        bool isHidden = false;
        private void runInBackRound_Click(object sender, EventArgs e)
        {
            if (runInBackRoundPW.Text != "")
            {
                pw = runInBackRoundPW.Text.ToLower().ToCharArray();
                
                pwIndex = 0;
                isHidden = true;
                Hide();
            }
            else
            {
                runInBackRound.Text = "You should set a password";
            }
            
        }


        public void keyBoardPressGlobal(int a , bool press)
        {
           
            lblLastKeyPressed.Text = "Last Key Pressed: \t\t\t " + (Keys)a;
            if (press && isHidden && a != 0)
            {
                if (pw[pwIndex] == ("" + (Keys)a).ToLower()[0])
                {
                    if (pwIndex == pw.Length - 1)
                    {
                        isHidden = false;
                        Show();
                    }
                    else
                        pwIndex++;
                }
                else
                {
                    pwIndex = 0;
                    if (pw[0] == ("" + (Keys)a).ToLower()[0])
                    {
                        pwIndex++;
                    }
                }
            }
            
            if (Player.isPlaying) return;
            for(int i = 0; i < 7; i++)
            {
                if(isHotKeyWindowClosed  && hotKeys[i].Equals((Keys)a ) ){
                    if (!press ) return;
                    else
                    {
                        if (i == 5)
                        {
                            if (lastRecord != null)
                                bntStart_Click(null ,  null);
                        }
                        else if (i == 6)
                        {
                            btnStop.Text = "Stopping Record..";
                            isRunning.Value = false;
                        }
                        else
                        {
                            showButtonsForRecording();
                            recorder.startRecording((RecordOption)i);
                            lblLMBP.Text = "" + (RecordOption)i;
                        }
                        
                        
                    }

                    return;
                }
            }
            
            recorder.keyPressed(a , press);
        }

        public void mouseClickedGlobal(MouseMessages msg, int posx, int posy)
        {
            if (Player.isPlaying) return;
            if (msg == MouseMessages.MouseMove)
            {
                lblMousePosition.Text = "Mouse-Position: \t\t\t\t" + posx + "," + posy;
            }
            else
            {
                lblLMBP.Text = "Last Mouse Button pressed: \t" + msg;
                recorder.MousePressed(msg);
            }

            
        }

        


        private void btnKeyboard_Click(object sender, EventArgs e)      { showButtonsForRecording();  if (isHotKeyWindowClosed && !recorder.isRecording) recorder.startRecording(RecordOption.KEYBOARD);}
        private void btnMouse_Click(object sender, EventArgs e)         { showButtonsForRecording(); if (isHotKeyWindowClosed && !recorder.isRecording) recorder.startRecording(RecordOption.MOUSE); }
        private void btnMouseTrace_Click(object sender, EventArgs e)    { showButtonsForRecording(); if (isHotKeyWindowClosed && !recorder.isRecording) recorder.startRecording(RecordOption.MOUSETRACE); }
        private void btnAll_Click(object sender, EventArgs e)           { showButtonsForRecording(); if (isHotKeyWindowClosed && !recorder.isRecording) recorder.startRecording(RecordOption.ALL); }
        private void btnAllTrace_Click(object sender, EventArgs e)      { showButtonsForRecording(); if (isHotKeyWindowClosed && !recorder.isRecording) recorder.startRecording(RecordOption.ALLTRACE); }
        
        private void showButtonsForRecording()
        {
            btnStop.Visible = true;
            bntStart.Visible = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!isRunning.Value)
            {
                if (recorder != null && isHotKeyWindowClosed)
                    lastRecord = recorder.stop();
                recorder = new Recorder(lblStatus);
                bntStart.Visible = true;
                btnStop.Visible = false;
                btnGetText.Visible = true;
                btnGetKeys.Visible = true;
            }
            else
            {
                btnStop.Text = "Stopping Record..";
                isRunning.Value = false; 
            }
            

        }

        BoolWrapper isRunning = new BoolWrapper(false);
        private void bntStart_Click(object sender, EventArgs e)
        {
            isRunning.Value = true;
            bntStart.Text = "Running...";
            btnStop.Visible = true;
            btnStop.Text = "Stop Playing Record";

            if (lastRecord != null && isHotKeyWindowClosed)
            {

                int mode = speedMode.SelectedIndex;
                double speed = (double) this.speed.Value;
                if(speed == 0)
                {
                    speed = 1;
                }
                int f =(int) times.Value;
                BackgroundWorker playerThread = new BackgroundWorker() ;
                playerThread.DoWork +=  ( x, y) => {
                    ClickInfo[] cl = lastRecord.ToArray();
                    for (int i = 0; i < f && isRunning.Value; i++)
                    {
                        if (mode == 0)
                        {
                            speed = 1 / speed;
                        }
                        Player.play(cl, isRunning, speed);
                    }
                     
                     };
                playerThread.RunWorkerCompleted += (s, args) =>
                {
                    times.Value = times.Value++;
                    bntStart.Text = "Play Record";
                    btnStop.Text = "Stop Recording";
                    isRunning.Value = false;
                    btnStop.Visible = false;
                };

                playerThread.RunWorkerAsync();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (isHotKeyWindowClosed)
            {
                hotKeyWindow = new HotKeys(hotKeys);
                hotKeyWindow.Show();
            }
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            if (lastRecord != null && isHotKeyWindowClosed)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "VirtualInput|*.VirtualInput";
                saveFileDialog1.Title = "Save an VirtualInput File";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    new Thread(() =>
                    {


                        Player.write(lastRecord.ToArray(), saveFileDialog1.FileName);

                    }).Start();
                }   
            }
                

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.Msg == 256)
            {
                if (keyData == (Keys.Control | Keys.S))
                {
                    bntSave_Click(null, null);
                }
                if (keyData == (Keys.Control | Keys.O))
                {
                    bntOpen_Click(null, null);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void bntOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "VirtualInput|*.VirtualInput";
            openFileDialog1.Title = "Select a VirtualInput File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                lastRecord = Interpreter.Interpreter.interpretFromFile(openFileDialog1.FileName);

                if(lastRecord != null)
                    bntStart.Visible = true;
            }
        }

        private void OpenEditor(object sender, EventArgs e)
        {
            if (lastRecord != null)
                new Editor.VirtualInputEditor(Player.write(lastRecord.ToArray()), true, this).Show();
            else
                new Editor.VirtualInputEditor("", true ,this).Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnGetKeys_Click(object sender, EventArgs e)
        {
            if (lastRecord != null)
            {
                string txt = Player.getKeysAsString(lastRecord.ToArray());
                Clipboard.SetText(txt);
                lblTest.Text = "The keys were Copyed to Clipboard";
            }
        }

        private void btnGetText_Click(object sender, EventArgs e)
        {
            if(lastRecord != null)
            {
                Editor.VirtualInputEditor editor = new Editor.VirtualInputEditor("", false, this);
                editor.Show();
                Player.wirteText(lastRecord.ToArray());
                //Clipboard.SetText(editor.getText());
                // lblTest.Text = "The keys were Copyed to Clipboard";
                // editor.Dispose();
            }
        }

        private void RecordMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (start != null)
                start.Show();
        }

    }
}
