using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample
{
    class Program
    {
        static void Main(string[] args)
        {

            Automobile a1 = new Car("VW", "Grey","automatic");

            a1.CalcMilage();
            a1.RatePerformance();

            a1.PrintInfo();
            
            Console.WriteLine("*******************");

            Automobile a2 = new Car("Bajaj", "Green", "4-Stroke");

            a2.CalcMilage();
            a2.RatePerformance();

            a2.PrintInfo();




        }
    }
}
