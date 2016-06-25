using delegateEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesVsFields
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Deepa", "Korantak");
            p1.printName += PrintLine;            
            Console.WriteLine("Full Name : " + p1.Name);

            p1.Name = "Gauri Damle";
            //Console.WriteLine("Full Name : " + p1.Name);

            p1.Name = "Sachin  Korantak";
            //Console.WriteLine("Full Name : " + p1.Name);

            p1.Name = null;
            //Console.WriteLine("Full Name : " + p1.Name);
        }

        public static void PrintLine(object sender, PrintDelegateEventArgs arg1)
        {
            Console.WriteLine("Sender Object : "+ sender.ToString());
            Console.WriteLine("Printer O/P : "+arg1.printString );
        }
    }
}
