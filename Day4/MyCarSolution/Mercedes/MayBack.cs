using Standards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercedesCompany
{
    public class StartupActions
    {
        bool acStarted;
        bool roofTopOpen;
        bool initialDiagnosisComplete;

        public bool StartAC()
        {
            //start ac operation
            Console.WriteLine("Starting AC");
            acStarted = true;
            return acStarted;
        }

        public bool OpenRoofTop()
        {
            //operation to opent the roof top
            Console.WriteLine("Opening Roof top");
            roofTopOpen = true;
            return roofTopOpen;
        }

        public bool CheckInitialDiagnostics()
        {
            //checks for various diagnosis parameters and returns value as expected
            Console.WriteLine("Checking Diagnostics");
            return true;
        }
    }
    public class MayBach:ICar
    {
        int currentGear = 0;
        bool started;
        StartupActions startup = new StartupActions();

        public void Start()
        {
            if (startup.CheckInitialDiagnostics() && startup.StartAC() && startup.OpenRoofTop())
            {
                Console.WriteLine("Starting Car");
                //process starting of the car
                started = true;               
            }
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
