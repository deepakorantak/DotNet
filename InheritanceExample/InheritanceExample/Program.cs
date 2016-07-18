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
            Automobile c1 = new Car("Hyundai", "Red", "manual");
            c1._Consumption = 100;
            c1._Running = 2100;

            c1.CalcMilage();
            c1.RatePerformance();
            
            c1.PrintInfo();

            Console.WriteLine( "***************************" );

            Automobile b2 = new Bike("Honda", "Blue", "2-stroke");
            b2._Consumption = 110;
            b2._Running = 9000;

            b2.CalcMilage();
            b2.RatePerformance();

            b2.PrintInfo();         
                
                
         }
    }
}
