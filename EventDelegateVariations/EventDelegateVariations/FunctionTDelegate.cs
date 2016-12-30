using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegateVariations
{
    class FunctionTDelegate
    {
        Action<double> OperationCompleted = (s) => Console.WriteLine($"Result is {s}");
        public Func<double, double, double> OperationAdd = (x, y) => { return x + y; };
        public Func<double, double, double> OperationSubstract = (x, y) => { return x - y; };
        public Func<double, double, double> OperationMultiply = (x, y) => { return x * y; };
        public Func<double, double, double> OperationDivision = (x, y) => { return x / y; };

        public void ProcessData(double a, double b, Func<double, double, double> opr)
        {
            Console.WriteLine("In class FunctionTDelegate");
            double result =  opr(a, b);
            OperationCompleted(result);
        }
    }
}
