using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Square : Shape
    {
        public double _side { get; set; }
        public override double ExecuteFormulaForArea()
        {
            Console.WriteLine("ExecuteFormulaForArea :: Square");
            return _side * _side;
        }

        public override double ExecuteFormulaForCicumference()
        {
            Console.WriteLine("ExecuteFormulaForCicumference :: Square");
            return 4 * _side;
        }

        public Square(double side)
        {
            _side = side;
        }
    }
}
