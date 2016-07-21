using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<Person> pq = new Queue<Person>();
            pq.Enqueue(new Person("Deepa", "Korantak"));
            pq.Enqueue(new Person("Gauri", "Korantak"));
            pq.Enqueue(new Person("Sachin", "Korantak"));

            Console.WriteLine($"2nd Person in the queue : {pq.ElementAt(1).Name}");
            Console.WriteLine($"Last person in the queue : {pq.Last().Name}");
           
            foreach (var _q in pq)
            {
                Console.WriteLine(_q.Name); 
            }

            Console.WriteLine($"Dqueue the queue : {pq.Dequeue().Name}");

        }
    }
}
