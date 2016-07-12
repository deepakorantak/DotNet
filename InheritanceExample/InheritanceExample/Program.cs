using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("Hyundai", "Red", "manual");
            c1._Consumption = 100;
            c1._Running = 2100;

            c1.CalcMilage();
            c1.RatePerformance();

            Console.WriteLine($"Milage of Car - {c1._Milage}");
            Console.WriteLine($"Performance rating of the Car - {c1._performance}");

        }
    }
}
