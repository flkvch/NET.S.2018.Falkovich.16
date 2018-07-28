using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Traffic;

namespace TrafficLightConsole
{
    class Program
    {
        static TrafficLight trafficLight = new TrafficLight();
        static TrafficLight trafficLight2 = new TrafficLight(TypeOfTrafficLight.TwoColors);

        static void Main(string[] args)
        {
            Console.WriteLine("Traffic Light with 3 colors.");
            Thread threadOn = new Thread(new ThreadStart(trafficLight.TurnOn));
            threadOn.Start();
            Thread.Sleep(20_000);
            threadOn.Abort();
            Thread threadOff = new Thread(new ThreadStart(trafficLight.TurnOff));
            threadOff.Start();
            Thread.Sleep(10_000);
            threadOff.Abort();


            Console.WriteLine("Traffic Light with 2 colors.");
            threadOn = new Thread(new ThreadStart(trafficLight2.TurnOn));
            threadOff = new Thread(new ThreadStart(trafficLight2.TurnOff));
            threadOn.Start();
            Thread.Sleep(20_000);
            threadOn.Abort();
            threadOff.Start();
            Thread.Sleep(10_000);
            threadOff.Abort();
        }

    }
}
