using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    public interface ITrafficLightState
    {
        void Light();

        void Countdown();

        void NextColor(TrafficLight trafficLight);
    }
}
