using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateVariations
{

    class ActionTDelagate
    {

        Action<string> OperationCompleted = (s) => Console.WriteLine(s);
        public Action<double, double> OperationAdd = (x, y) => Console.WriteLine(  $"Addition of {x} + {y} = {x + y}");
        public Action<double, double> OperationSubstract = (x, y) => Console.WriteLine($"Substraction of {x} - {y} = {x - y}");
        public Action<double, double> OperationMultiply = (x, y) => Console.WriteLine($"Multiplication of {x} * {y} = {x * y}");
        public Action<double, double> OperationDivision = (x, y) => Console.WriteLine($"Division of {x} / {y} = {x / y}");
        
        public void ProcessData(double a,double b, Action<double,double> opr)
        {
            Console.WriteLine("In class ActionSTDelagate");
            opr(a, b);
            OperationCompleted("Operation Completed !!");            
        }

    }
}
