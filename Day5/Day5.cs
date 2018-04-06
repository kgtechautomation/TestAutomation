using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
   class Building
   {
       public int peopleCapacity;
       public int NoOfEntrances;
       public int NoOfRooms;
       public int NoOfDoors;
       protected string address;
       public virtual bool OpenMainDoor()
       {
           //logic to open the main door
           Console.WriteLine("Within OpenMainDoor method");
           return true;//or false if open door operation failed
       }
       
       public bool TurnOnMainPowerSupply()
       {
           //logic to turn on mains
           return true;//or false if failed
       }
   }

   class Home: Building
   {
       #region class details
       public override bool OpenMainDoor()
       {
           //some logic
           Console.WriteLine("Overriden implemnetation of open main door using key for derived class: home");
           return true;
       }

       public void OpenDoor()
       {
           
           //Logic to open the door
       }

       string familyName;
       public void UpdateFamilyName(string name)
       {
           familyName = name;
       }

       public void UpdateAddress(string addr)
       {
           address = addr;
       }

       public string GetAddress()
       {
           return address;
       }
       #endregion
   }

   class Apartment: Building
   {
       int noOfFlats;
       public bool OpenSocietygate()
       {
           return true;
       }
   }

   class Office: Building
   {
       public override bool OpenMainDoor()
       {
           //some logic
           Console.WriteLine("Overriden implemnetation of open main door using security lock for derived class: Office");
           return true;
       }

       int noOfDesk;
       DateTime startTime;
       DateTime endTime;
       public void SetStartTime() {
           startTime = DateTime.Now;
       }
       public void SetEndTime()
       {
           endTime = DateTime.Now;
       }
   }

   class ClassInheritance
   {
       static void Main(string[] args)
       {
           Home h = new Home();
           h.OpenMainDoor();
           h.UpdateFamilyName("abc");
           h.UpdateAddress("My address");

           Building b1 = new Home();
           b1.OpenMainDoor();
           //b1.UpdateFamilyName(); - This is not possible since the Building's reference does not undestand it

           Office o = new Office();
           o.OpenMainDoor();
           Apartment a = new Apartment();
           a.OpenMainDoor();
           Console.WriteLine(h.GetAddress());
           Console.ReadKey();
       }
   }
}