using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarNS;
using MyCarPremium;

namespace CarDriverApp
{
    class CarDriver
    {
        static void Main(string[] args)
        {
            MyCar car1 = new MyCar();
            MyPremiumCars pc = new MyPremiumCars();
            car1.DisplayCarDetails();
            MyCar car2 = new MyCar("model1", 5, 4, 200);
            car2.DisplayCarDetails();
            Console.ReadKey();
        }

        public void MyCarCreation()
        {
            MyCar car1 = new MyCar("model1", 5, 4, 200);
            MyCar car2 = new MyCar("model2", 2, 2, 400);
            MyCar car3 = new MyCar(5, 4, 200);
        }
    }
}
