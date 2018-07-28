using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic
{
    internal class RedLightState : ITrafficLightState
    {
        public void Countdown()
        {
            Thread.Sleep(3000);
        }

        public void Light()
        {
            Console.WriteLine("red");
        }

        public void NextColor(TrafficLight trafficLight)
        {
            if (trafficLight.Type == TypeOfTrafficLight.ThreeColors)
            {
                trafficLight.State = new YellowLightState();
            }

            if (trafficLight.Type == TypeOfTrafficLight.TwoColors)
            {
                trafficLight.State = new GreenLightState();
            }
        }
    }
}
