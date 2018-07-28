using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic
{
    internal class NonLightState : ITrafficLightState
    {
        public void Countdown()
        {
            Thread.Sleep(500);
        }

        public void Light()
        {
            Console.WriteLine("+++");
        }

        public void NextColor(TrafficLight trafficLight)
        {
            throw new NotImplementedException();
        }
    }
}
