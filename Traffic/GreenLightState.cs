using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic
{
    internal class GreenLightState : ITrafficLightState
    {
        public void Countdown()
        {
            Thread.Sleep(4_000);
        }

        public void Light()
        {
            Console.WriteLine("green");
        }

        public void NextColor(TrafficLight trafficLight)
        {
            TwinkleGreen(trafficLight);
            trafficLight.State = new RedLightState();
        }

        private void TwinkleGreen(TrafficLight trafficLight)
        {
            for (int i = 0; i < 3; i++)
            {
                trafficLight.State = new NonLightState();
                trafficLight.State.Light();
                trafficLight.State.Countdown();
                trafficLight.State = new GreenLightState();
                trafficLight.State.Light();
                Thread.Sleep(500);
            }
        }
    }
}
