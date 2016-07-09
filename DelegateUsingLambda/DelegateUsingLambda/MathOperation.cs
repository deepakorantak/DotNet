using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateUsingLambdaFuncT
{
    class MathOperation
    {

        public double MathProcess(double x,double y , Func<double,double,double> Operation)
        {
            double result = 0;
            Console.WriteLine("Inside Mathprocess with double arguments"  );            
            result = Operation(x, y);
            return result;
        }
 
    }
}
