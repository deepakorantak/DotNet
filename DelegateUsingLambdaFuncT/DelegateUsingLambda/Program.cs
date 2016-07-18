using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateUsingLambdaFuncT
{
    class Program
    {
        static void Main(string[] args)
        {

            double x = 0, y = 0, result = 0;
            Func<double, double, double> Addition = (x1, y1) => x1 + y1;
            Func<double, double, double> Subtract = (x1, y1) => x1 - y1;
            Func<double, double, double> Mutiply = (x1, y1) => x1 * y1;
            Func<double, double, double> Division = (x1, y1) => x1 / y1;

            MathOperation oper = new MathOperation();

            x = 5.35;
            y = 6.65;

                        Console.WriteLine("Enter Add - addition, Sub - Subtraction,Mul - Multiplication, Div - Division");
            string option = Console.ReadLine();

            switch (option.ToUpper())
            {

                case "ADD":
                    result = oper.MathProcess(x, y, Addition);
                    break;
                case "SUB":
                    result = oper.MathProcess(x, y, Subtract);
                    break;
                case "MUL":
                    result = oper.MathProcess(x, y, Mutiply);
                    break;
                case "DIV":
                    result = oper.MathProcess(x, y, Division);
                    break;
                default:
                    break;
            }

            Console.WriteLine($"Result of operation {option.ToUpper()} {x},{y} is {result}");
        }
    }
}
