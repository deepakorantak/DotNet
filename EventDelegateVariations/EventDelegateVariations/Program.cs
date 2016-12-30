using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateVariations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Custom delegate implememtation with custom parameters 
            CustomDelegateCustomArgs c1 = new CustomDelegateCustomArgs();
            c1.DoWork(6,3);

            // Custom delegate but standard parameters with sender object and Eventargs
            //MathOperationArgs is inherited from EventArgs
            MathOperationArgs e = new MathOperationArgs();
            e.x = 10;
            e.y = 5;

            CustomDelegateEventArgs c2 = new CustomDelegateEventArgs();
            c2.DoWork(c2, e);


            // Eventhandler delegate with standard parameters with sender object and Eventargs
            //MathOperationArgs is inherited from EventArgs
            MathOperationArgs ab = new MathOperationArgs();
            ab.x = 15;
            ab.y = 3;

            EventHandlerDelgate c3 = new EventHandlerDelgate();
            c3.DoWork(c3, ab);

            // Eventhandler delegate using lambda with standard parameters with sender object and Eventargs with
            //MathOperationArgs is inherited from EventArgs
            MathOperationArgs eb = new MathOperationArgs();
            eb.x = 3;
            eb.y = 6;

            EventHandlerUsingLambda c4 = new EventHandlerUsingLambda();
            c4.DoWork(c4, eb);

            //action T delgate
            ActionTDelagate c5 = new ActionTDelagate();
            c5.ProcessData(6, 5, c5.OperationAdd);
            c5.ProcessData(6, 5, c5.OperationSubstract);
            c5.ProcessData(6, 5, c5.OperationMultiply);
            c5.ProcessData(6, 5, c5.OperationDivision);

            //function T delgate
            FunctionTDelegate c6 = new FunctionTDelegate();
            c6.ProcessData(7, 2, c6.OperationAdd);
            c6.ProcessData(7, 2, c6.OperationSubstract);
            c6.ProcessData(7, 2, c6.OperationMultiply);
            c6.ProcessData(7, 2, c6.OperationDivision);


        }
    }
}
