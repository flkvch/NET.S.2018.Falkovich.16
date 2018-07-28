using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    /// <summary>
    /// Traffic Light class
    /// </summary>
    public class TrafficLight
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrafficLight"/> class.
        /// </summary>
        public TrafficLight()
        {
            State = new RedLightState();
            Type = TypeOfTrafficLight.ThreeColors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrafficLight"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public TrafficLight(TypeOfTrafficLight type) : this()
        {
            Type = type;
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public ITrafficLightState State { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public TypeOfTrafficLight Type { get; set; }

        /// <summary>
        /// Turns the traffic light on.
        /// </summary>
        public void TurnOn()
        {
            while (true)
            {
                State.Light();
                State.Countdown();
                State.NextColor(this);
            }
        }

        /// <summary>
        /// Turns the traffic light off.
        /// </summary>
        public void TurnOff()
        {
            while (true)
            {
                if (Type == TypeOfTrafficLight.ThreeColors)
                {
                    State = new YellowLightState();
                    State.Light();
                    State.Countdown();
                    State.NextColor(this);
                    State = new NonLightState();
                    State.Light();
                    State.Countdown();                   
                }

                if (Type == TypeOfTrafficLight.TwoColors)
                {
                    State = new NonLightState();
                    State.Light();
                    State.Countdown();
                }
            }
        }
    }
}