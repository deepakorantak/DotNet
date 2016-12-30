using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateVariations
{

 
    public delegate void MathOperationPerformEventArgs(object s, MathOperationArgs e);

    class CustomDelegateEventArgs
    {
        private event MathOperationPerformEventArgs Operation;

        private void SubscribeMathOperationEvent()
        {

            Console.WriteLine("In class CustomDelegateEventArgs");

            Operation = new MathOperationPerformEventArgs(Add);
            Operation += Substract;
            Operation += Multiply;
            Operation += Divide;

        }


        public void DoWork(object a, MathOperationArgs e)
        {
            Operation(a,e);
        }

        private void Add(object a,  MathOperationArgs e)
        {
            Console.WriteLine($"Addition {e.x} + {e.y} = { e.x + e.y } ");

        }

        private void Substract(object a, MathOperationArgs e)
        {
            Console.WriteLine($"Substraction {e.x} - {e.y} = { e.x - e.y } ");

        }

        private void Multiply(object a, MathOperationArgs e)
        {
            Console.WriteLine($"Multiplication {e.x} * {e.y} = { e.x * e.y } ");

        }

        private void Divide(object a, MathOperationArgs e)
        {
            Console.WriteLine($"Division {e.x} / {e.y} = { e.x / e.y } ");

        }

        public CustomDelegateEventArgs()
        {
            SubscribeMathOperationEvent();
        }

    }
}
