using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<Person> sp = new Stack<Person>();
            sp.Push(new Person("John", "Myers"));
            sp.Push(new Person("Sebastian", "Gorjon"));
            sp.Push(new Person("Merry", "Poppins"));

            Console.WriteLine($"2nd Element in the stack : {sp.ElementAt(1).Name}");

            foreach (var _s in sp)
            {
                Console.WriteLine( $"Elements in the Stack : {_s.Name}" );

            }

           while(sp.Count !=0)
            {
                Console.WriteLine(  $"Popping off the elements from stack : {sp.Pop().Name}");
            }
        }
    }
}
