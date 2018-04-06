using Standards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarPremium
{
    public class MyPremiumCar:ICar
    {
        int currentGear = 0;
        bool acStarted;
        bool started;

        public void Start()
        {
            //Perform operations to start AC and then set ac start to true
            Console.WriteLine("Starting AC");
            acStarted = true;
            Console.WriteLine("Starting Car");
            //perform operations to start car and set started to true
            started = true;
        }

        public bool IsCarStarted()
        {
            return started;
        }

        public int GetCurrentSpeed()
        {
            int currentSpeed = 0;
            //logic to fetch the current speed
            currentSpeed = 90;
            return currentSpeed;
        }

        public int GetCurrentGear()
        {
            return currentGear;
        }
    }
}
