using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLambda
{
    class Program
    {
        static void Main(string[] args)
        {



            Person p1 = new Person("John", "Plonski");
            p1.printChange += (s, e) => Console.WriteLine(e.printString);
            p1.printChange += (s, e) => Console.WriteLine("**********");
            p1.printChange += (s, e) =>
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter("D:\\Deepa\\Training\\GitHub\\DotNet\\DelegateLambda\\NameChange.log",true);
                file.WriteLine(DateTime.Now);
                file.WriteLine(e.printString);
                file.WriteLine("************");
                file.Close();
            };

            p1.Name = "Martin Scorsee";
            p1.Name = "Steven Spielberg";
        }
    }
}
