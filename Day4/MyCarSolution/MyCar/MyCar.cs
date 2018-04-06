using Standards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarNS
{
    public class MyCar:ICar
    {
        #region COnstructors
        public MyCar() { }

        public MyCar(int doors, int seats, int fuelCap)
        {
            noOfDoors = doors;
            noOfSeats = seats;
            FuelCapacity = fuelCap;
            currentGear = 0;
            model = "defaultModel";
        }

        public MyCar(string model, int doors, int seats, int fuelCap)
        {
            this.model = model;//mandatory to provide this pointer
            this.noOfDoors = doors;
            this.noOfSeats = seats;            
            FuelCapacity = fuelCap;
            currentGear = 0;
        }
        #endregion

        #region Data Members - xyz
        string model;
        int noOfDoors;
        int noOfSeats;
        readonly int noOfGears;
        int currentGear;
        int FuelCapacity;
        bool started;
        #endregion

        #region Public Methods
        public void Start()
        {
            //perform opertations to start car
            Console.WriteLine("Simple start");
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

        public void DisplayCarDetails()
        {
            Console.WriteLine($"Model: {model}");
            Console.WriteLine($"Door#: {noOfDoors}");
            Console.WriteLine($"Seat#: {noOfSeats}");
            Console.WriteLine($"Current Gear#: {currentGear}");
            Console.WriteLine($"Fuel Capacity: {FuelCapacity}");
        }
        #endregion
    }


}

