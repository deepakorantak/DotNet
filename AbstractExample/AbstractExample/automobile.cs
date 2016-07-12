using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample
{
    abstract class Automobile
    {
        protected string _manufacturer;
        protected string _color;
        public double Running { get; set; }
        public double Consumption { get; set; }
        public double Milage;
        public int PerformanceRate;

        protected static double _stdMilage;

        enum Performance
        {
            Excellent = 1,
            Good = 2,
            BelowAverage = 3
        }

        public Automobile(string manf, string col)
        {
            _manufacturer = manf;
            _color = col;
            Milage = 0.0;
            Running = 0.0;
            Consumption = 0.0;
            PerformanceRate = (int)Performance.Good;
        }

        public void CalcMilage()
        {
            Milage = Running / Consumption;
        }


        public void RatePerformance()
        {
            if (Milage > _stdMilage)
            {
                PerformanceRate = (int)Performance.Excellent;
            }
            else if (Milage == _stdMilage)
            {
                PerformanceRate = (int)Performance.Good;
            }
            else
            {
                PerformanceRate = (int)Performance.BelowAverage;
            }

        }

        // abstract method
        public abstract void PrintInfo();
        
    }
}
