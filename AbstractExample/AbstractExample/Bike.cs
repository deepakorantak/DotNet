using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample
{
    class Bike :Automobile
    {
        string _engine;

        public Bike(string manf, string color, string iengine)
            : base(manf, color)
        {
            _engine = iengine;
            _stdMilage = 80;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Manufacturer : {_manufacturer}");
            Console.WriteLine($"Color : {_color}");
            Console.WriteLine($"Running in Km : {Running}");
            Console.WriteLine($"Consupmtion in Litre : {Consumption}");
            Console.WriteLine($"Milage in km/ltr : {Milage}");
            Console.WriteLine($"Performance rating : {PerformanceRate}");
            Console.WriteLine($"Engine : {_engine}");
        }
    }
}
