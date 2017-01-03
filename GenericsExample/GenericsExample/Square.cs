using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class Square : AbstractShape
    {
        
        public override double ExecuteFormulaForArea()
        {
            //Console.WriteLine("ExecuteFormulaForArea :: Square");
            return _param * _param;
        }

        public override double ExecuteFormulaForCicumference()
        {
            //Console.WriteLine("ExecuteFormulaForCicumference :: Square");
            return 4 * _param;
        }

        public Square(double side)
        {
            _param = side;
        }
    }
}
