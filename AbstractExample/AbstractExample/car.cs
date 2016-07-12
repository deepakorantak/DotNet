using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample
{
    class Car : Automobile
    {
        string _transmission;
        public Car(string manf, string color, string trans)
            : base(manf, color)
        {

            _transmission = trans;
            _stdMilage = 13.25;
        }

        

        public override void PrintInfo()
        {           
                Console.WriteLine($"Manufacturer : {_manufacturer}");
                Console.WriteLine($"Color : {_color}");
                Console.WriteLine($"Running in Km : {Running}");
                Console.WriteLine($"Consupmtion in Litre : {Consumption}");
                Console.WriteLine($"Milage in km/ltr : {Milage}");
                Console.WriteLine($"Performance rating : {PerformanceRate}");
                Console.WriteLine($"Transmission : {_transmission}");
        }
    }
}
