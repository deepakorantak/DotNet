using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateVariations
{
    class EventHandlerUsingLambda
    {
        private event EventHandler<MathOperationArgs> Operation;

        private void SubscribeMathOperationEvent()
        {
            Console.WriteLine("In class EventHandlerUsingLambda");

            Operation += (s, e) => Console.WriteLine($"Addition {e.x} + {e.y} = { e.x + e.y } ");
            Operation += (s, e) => Console.WriteLine($"Substraction {e.x} - {e.y} = { e.x - e.y } ");
            Operation += (s, e) => Console.WriteLine($"Multiplication {e.x} * {e.y} = { e.x * e.y } ");
            Operation += (s, e) => Console.WriteLine($"Division {e.x} / {e.y} = { e.x / e.y } ");
        }


        public void DoWork(object s, MathOperationArgs e)
        {
            Operation(s, e);
        }


        public EventHandlerUsingLambda()
        {
            SubscribeMathOperationEvent();
        }
    }
}
