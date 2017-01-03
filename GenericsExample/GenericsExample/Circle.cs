using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class Circle : AbstractShape
    {
      
        public override double ExecuteFormulaForArea()
        {
            //Console.WriteLine("ExecuteFormulaForArea :: Circle");
            return (Math.PI / 2) * _param * _param;
        }

        public override double ExecuteFormulaForCicumference()
        {
           // Console.WriteLine("ExecuteFormulaForCurcumference :: Circle");
            return 2 * Math.PI * _param;
        }

        public Circle(double radius)
        {
            _param = radius;
        }
    }

}
