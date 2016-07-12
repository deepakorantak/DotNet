using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLogger log = new FileLogger("log.txt");
            bool result = log.logEvent("Error ocuured in interface", "E", "Deepa");
            if (result == true)
                Console.WriteLine(" Event logged succesfully ");
            else
                Console.WriteLine("Error in event logging");

            CommandLineLogger log1 = new CommandLineLogger();
            bool result1 = log1.logEvent("Error ocuured in interface", "E", "Deepa");
            if (result1 == true)
                Console.WriteLine(" Event displayed on command line succesfully ");
            else
                Console.WriteLine("Error in command line display");
            
        }
    }
}
