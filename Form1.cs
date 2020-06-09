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
        private Timer timerSwitch;
        private int timerCounter = 0;

        public TrafficLights()
        {
            InitializeComponent();
            InitializeTrafficLight();
            InitializeTimerSwitch();
        }

        private void InitializeTimerSwitch()
        {
            timerSwitch = new Timer();
            timerSwitch.Interval = 1000;
            timerSwitch.Tick += new EventHandler(TimerSwitch_Tick);
            timerSwitch.Start();
        }

        private void TimerSwitch_Tick(object sender, EventArgs e)
        {
            if(timerCounter == 0)
            {
                RedLight.BackColor = Color.Red;
            }
            else if(timerCounter == 3)
            {
                RedLight.BackColor = Color.Gray;
                YellowLight.BackColor = Color.Yellow;
            }
            else if (timerCounter == 6)
            {
                YellowLight.BackColor = Color.Gray;
                GreenLight.BackColor = Color.Green;
            }
            else if (timerCounter == 9)
            {
                GreenLight.BackColor = Color.Gray;
                YellowLight.BackColor = Color.Yellow;
            }
            else if (timerCounter == 12)
            {
                YellowLight.BackColor = Color.Gray;
                RedLight.BackColor = Color.Red;
                timerCounter = -1;
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