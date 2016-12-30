using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateVariations
{
    class EventHandlerDelgate
    {

        private event EventHandler<MathOperationArgs> Operation;

        private void SubscribeMathOperationEvent()
        {

            Console.WriteLine("In class EventHandlerDelgate");

            Operation +=Add; // inference
            Operation += Substract;
            Operation += Multiply;
            Operation += Divide;

        }


        public void DoWork(object s, MathOperationArgs e)
        {
            Operation(s,e);
        }

        private void Add(object s, MathOperationArgs e)
        {
            Console.WriteLine($"Addition {e.x} + {e.y} = { e.x + e.y } ");

        }

        private void Substract(object s, MathOperationArgs e)
        {
            Console.WriteLine($"Substraction {e.x} - {e.y} = { e.x - e.y } ");

        }

        private void Multiply(object s, MathOperationArgs e)
        {
            Console.WriteLine($"Multiplication {e.x} * {e.y} = { e.x * e.y } ");

        }

        private void Divide(object s, MathOperationArgs e)
        {
            Console.WriteLine($"Division {e.x} / {e.y} = { e.x / e.y } ");

        }

        public EventHandlerDelgate()
        {
            SubscribeMathOperationEvent();
        }

    }
}
