using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateEvent
{
    class Program
    {
        static void Main(string[] args)
        {
           
           PrintDelegate printer = new PrintDelegate(Print);
           printer += Print2;

            PrintDelegateEventArgs printArg = new PrintDelegateEventArgs();
            printArg.printString = "Hello World !!";

            printer("String", printArg);
                                 
        }

        static void Print(object sender,PrintDelegateEventArgs iarg)
        {
                        Console.WriteLine($"Print requested for {iarg.printString}");
        }

        static void Print2(object sender, PrintDelegateEventArgs iarg)
        {

            Console.WriteLine("*****");
        }

    }
}
