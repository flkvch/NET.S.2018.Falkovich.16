using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic
{
    internal class YellowLightState : ITrafficLightState
    {
        public void Countdown()
        {
            Thread.Sleep(500);
        }

        public void Light()
        {
            Console.WriteLine("yellow");
        }

        public void NextColor(TrafficLight trafficLight)
        {
            trafficLight.State = new GreenLightState();
        }
    }
}
