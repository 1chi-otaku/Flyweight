using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight2
{
    abstract class Vehicle
    {
        //Внешнее состояние
        protected string icon;

        //Внутренее состояние
        protected double speed;
        protected double force_factor;
        abstract public void Show(double speed, double force_factor);
    }

    class MilitaryVehicle:Vehicle
    {
        public MilitaryVehicle() {

            icon = "ICON.PNG";
        }
        public override void Show(double speed, double force_factor)
        {
            this.speed = speed;
            this.force_factor = force_factor;
            Console.WriteLine("Icon - " + icon);
            Console.WriteLine("Speed - " + speed);
            Console.WriteLine("Force Factor - " + force_factor);
        }
    }

    class MilitaryBase
    {
        private SortedDictionary<string, Vehicle> vehicles = new SortedDictionary<string, Vehicle>();

        public Vehicle GetVehicle(string icon)
        {
            Vehicle vehicle = null;
            if (vehicles == null)vehicle = vehicles[icon];
            if(vehicle == null)
            {
                switch(icon)
                {
                    case "ICON.PNG":
                        vehicle = new MilitaryVehicle();
                        break;
                }
                vehicles[icon] = vehicle;
            }
            return vehicle;
        }
    }


   
    internal class Program
    {
        static void Main(string[] args)
        {
            double speed = 15.5;
            double force_factor = 9.6;

            MilitaryBase militaryBase = new MilitaryBase();
            Vehicle vehicle = militaryBase.GetVehicle("ICON.PNG");
            vehicle.Show(speed, force_factor);
            Vehicle vehicle2 = militaryBase.GetVehicle("ICON.PNG");
            vehicle.Show(17, 12.5);
        }
    }
}
