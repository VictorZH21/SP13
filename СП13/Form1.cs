using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace СП13
{
    public partial class Form1 : Form
    {
        DateTime mShutdownTime;
        bool isTimerRunning = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "shutdown.exe";
            process.StartInfo.Arguments = "/s /t 0";
            process.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "shutdown.exe";
            process.StartInfo.Arguments = "/r /t 0";
            process.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "shutdown.exe";
            process.StartInfo.Arguments = $"/s /t 180";
            process.Start();
            mShutdownTime = DateTime.Now.AddSeconds(180);
            StartTimer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "shutdown.exe";
            process.StartInfo.Arguments = $"/r /t 90";
            process.Start();
            mShutdownTime = DateTime.Now.AddSeconds(90);
            StartTimer();
        }
        private void StartTimer()
        {
            if (!isTimerRunning)
            {
                label2.Visible = true;
                label2.Text = "";
                timer1.Start();
                isTimerRunning = true;
            }
        }

        private void StopTimer()
        {
            timer1.Stop();
            isTimerRunning = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now < mShutdownTime)
            {
                TimeSpan ts = mShutdownTime - DateTime.Now;
                label2.Text = $"{ts.Hours} часов {ts.Minutes} минут {ts.Seconds} секунд";
            }
            else
            {
                StopTimer();
                Application.Exit();
            }
        }
    }
}
