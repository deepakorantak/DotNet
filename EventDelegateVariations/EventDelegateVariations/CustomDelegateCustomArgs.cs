using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateVariations
{

    public  delegate void MathOperationPerform(double val1, double val2);
    class CustomDelegateCustomArgs
    {

        private event MathOperationPerform Operation;

        private void SubscribeMathOperationEvent()
        {
            
            Console.WriteLine("In class CustomDelegateCustomArgs");

            //Operation = new MathOperationPerform(Add);
            //Operation += Substract;
            //Operation += Multiply;
            //Operation += Divide;


            Operation += (x,y) => Console.WriteLine($"Addition {x} + {y} = { x + y } "); 
            Operation += (x, y) => Console.WriteLine($"Substraction {x} - {y} = { x - y } ");
            Operation += (x, y) => Console.WriteLine($"Multiplication {x} * {y} = { x * y } ");
            Operation += (x, y) => Console.WriteLine($"Division {x} / {y} = { x / y } ");

        } 


        public void DoWork(double arg1, double arg2)
        {
            Operation(arg1, arg2);
        }

        private void Add(double x, double y)
        {
            Console.WriteLine($"Addition {x} + {y} = { x + y } ") ;

        }

        private void Substract(double x, double y)
        {
            Console.WriteLine($"Substraction {x} - {y} = { x - y } ");

        }

        private void Multiply(double x, double y)
        {
            Console.WriteLine($"Multiplication {x} * {y} = { x * y } ");

        }

        private void Divide(double x, double y)
        {
            Console.WriteLine($"Division {x} / {y} = { x / y } ");

        }

        public CustomDelegateCustomArgs()
        {
            SubscribeMathOperationEvent();
        }


    }
}
