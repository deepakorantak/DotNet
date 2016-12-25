using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVsAbstractClass
{
    class Circle : Shape
    {
        public double _radius { get; set; }
        public double _circumference
        {
            get
            {
                return ExecuteFormulaForCiurcumference();
            }
            set
            {
                _circumference = value / (2 * Math.PI);
            }

        }

        public override double ExecuteFormulaForArea()
        {
            Console.WriteLine("ExecuteFormulaForArea :: Circle");
            return (Math.PI / 2) * _radius * _radius;
        }

        public double ExecuteFormulaForAreaNV()
        {
            Console.WriteLine("ExecuteFormulaForArea :: Circle");
            return (Math.PI / 2) * _radius * _radius;
        }

        public double ExecuteFormulaForCiurcumference()
        {
            Console.WriteLine("ExecuteFormulaForCurcumference :: Circle");
            return 2 * Math.PI * _radius;
        }

        public Circle(double radius)
        {
            _radius = radius;
        }
    }
}
