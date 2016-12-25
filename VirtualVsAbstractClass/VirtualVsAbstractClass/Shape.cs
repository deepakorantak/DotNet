using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVsAbstractClass
{
    class Shape
    {
        public double _area
        {
                    get {
                            return ExecuteFormulaForArea();
                        }

                    set {
                            _area = 0.0;
                        } 
        }

        public double _areaNV
        {
            get
            {
                return ExecuteFormulaForAreaNV();
            }

            set
            {
                _areaNV = 0.0;
            }
        }

        //public double CalculateArea()
        //{
        //    Console.WriteLine("CalcualteArea :: Shape");
        //    return ExecuteFormulaForArea();
        //}

        public virtual double ExecuteFormulaForArea()
        {
            Console.WriteLine("ExecuteFormulaForArea :: Shape");
            return -1.0;
        }

        public double ExecuteFormulaForAreaNV()
        {
            Console.WriteLine("ExecuteFormulaForAreaNV :: Shape");
            return -1.0;
        }

    }
}
