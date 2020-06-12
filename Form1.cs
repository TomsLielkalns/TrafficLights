using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLights
{
    public partial class TrafficLights : Form
    {
        private Timer timerSwitch = null;
        private Timer timerBlink = null;
        private int timerCounter = 0;
        private Label labelTime = null;
        private int hou = 0, min = 0, sec = 0;

        public TrafficLights()
        {
            InitializeComponent();
            InitializeTrafficLight();
            InitializeTimerSwitch();
            InitializeTimerBlink();
            InitializeLabelTime();
        }

        private void InitializeLabelTime()
        {
            labelTime = new Label();
            labelTime.Font = new Font("Tahoma", 18, FontStyle.Bold);
            labelTime.Width = 150;
            labelTime.Height = 50;
            labelTime.Top = 40;
            labelTime.Left = 70;
            labelTime.Text = "00:00:00";
            this.Controls.Add(labelTime);
        }

        private void InitializeTimerSwitch()
        {
            timerSwitch = new Timer();
            timerSwitch.Interval = 1000;
            timerSwitch.Tick += new EventHandler(TimerSwitch_Tick);
            timerSwitch.Start();
        }

        private void InitializeTimerBlink()
        {
            timerBlink = new Timer();
            timerBlink.Interval = 200;
            timerBlink.Tick += new EventHandler(TimerBlink_Tick);
        }

        private void TimerBlink_Tick(object sender, EventArgs e)
        {
            if(GreenLight.BackColor == Color.Gray)
            {
                GreenLight.BackColor = Color.Green;
            }
            else
            {
                GreenLight.BackColor = Color.Gray;
            }
        }

        private void TimerSwitch_Tick(object sender, EventArgs e)
        {
            UpdateClock();
            SwitchLights();
            UpdateLabelTime();
        }

        private void ResetTime()
        {
            sec = 0;
            min = 0;
            hou = 0;
        }

        private void UpdateClock()
        {
            sec++;
            if(sec == 60)
            {
                min++;
                sec = 0;
            }
            if(min == 60)
            {
                hou++;
                min = 0;
            }
            if(hou == 24)
            {
                ResetTime();
            }
        }

        private void UpdateLabelTime()
        {
            labelTime.Text = $"{hou:00}:{min:00}:{sec:00}";
        }

        private void SwitchLights()
        {
            switch (timerCounter)
            {
                case 0:
                    RedLight.BackColor = Color.Red;
                    break;
                case 3:
                    YellowLight.BackColor = Color.Yellow;
                    break;
                case 5:
                    RedLight.BackColor = Color.Gray;
                    YellowLight.BackColor = Color.Gray;
                    GreenLight.BackColor = Color.Green;
                    break;
                case 6:
                    timerBlink.Start();
                    break;
                case 8:
                    timerBlink.Stop();
                    YellowLight.BackColor = Color.Yellow;
                    GreenLight.BackColor = Color.Gray;
                    break;
                case 10:
                    YellowLight.BackColor = Color.Gray;
                    RedLight.BackColor = Color.Red;
                    timerCounter = -1;
                    break;
            }
            timerCounter++;
        }

        private void InitializeTrafficLight()
        {
            RedLight.BackColor = Color.Gray;
            YellowLight.BackColor = Color.Gray;
            GreenLight.BackColor = Color.Gray;
        }
    }
}