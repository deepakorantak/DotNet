using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
   abstract class AbstractShape
    {
        public double _param { get; set; }
        public double _area
        {
            get
            {
                return CalculateArea();
            }

            set
            {
                _area = 0.0;
            }
        }

        public double _circumference
        {
            get
            {
                return CalculateCicumference();
            }

            set
            {
                _circumference = 0.0;
            }
        }


        private double CalculateArea()
        {
            //Console.WriteLine("CalcualteArea :: AbstractShape");
            return ExecuteFormulaForArea();
        }

        private double CalculateCicumference()
        {
            //Console.WriteLine("CalculateCicumference :: AbstractShape");
            return ExecuteFormulaForCicumference();
        }

        public abstract double ExecuteFormulaForArea();

        public abstract double ExecuteFormulaForCicumference();


    }
}
