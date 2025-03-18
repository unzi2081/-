using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ___
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer checkProcessTimer = new System.Windows.Forms.Timer();
        private List<string> monitoredProcesses = new List<string> { "taskmgr", "notepad", "calc", "explorer", "chrome", "cmd" };
        public Form1()
        {
            InitializeComponent();
            checkProcessTimer.Interval = 10; // 10ms마다 체크
            checkProcessTimer.Tick += CheckProcessTimer_Tick;
            checkProcessTimer.Start();
            this.TopMost = true;
        }
        private void CheckProcessTimer_Tick(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcesses())
            {
                if (monitoredProcesses.Contains(process.ProcessName.ToLower()))
                {
                    try
                    {
                        process.Kill(); // 해당 프로세스 종료
                    }
                    catch
                    {
                        // 예외 처리
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
