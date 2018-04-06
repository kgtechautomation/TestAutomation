using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarNS;
using MyCarPremium;
using MercedesCompany;
using Standards;

namespace CarDriverApp
{
    class CarDriver
    {
        static void Main(string[] args)
        {
            MyCar[] myCars;
            List<MyPremiumCar> myPremiumCars = new List<MyPremiumCar>();
            List<MayBach> maybachs = new List<MayBach>();

            List<ICar> cars = new List<ICar>();
            
            cars.Add(new MyCar());
            cars.Add(new MyCar(5,5,200));
            cars.Add(new MyCar(2, 2, 400));
            cars.Add(new MyCar());
            cars.Add(new MyPremiumCar());
            cars.Add(new MyPremiumCar());
            cars.Add(new MayBach());
            cars.Add(new MayBach());
            cars.Add(new MayBach());
            
            //Test for MyCars
            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].Start();
                if (cars[i].IsCarStarted())
                    Console.WriteLine($"myCar{i} started successfully");
                else
                    Console.WriteLine($"myCar{i} failed to start");
            }            
        }

        public void MyCarCreation()
        {
            MyCar car1 = new MyCar("model1", 5, 4, 200);
            MyCar car2 = new MyCar("model2", 2, 2, 400);
            MyCar car3 = new MyCar(5, 4, 200);
        }
    }
}
