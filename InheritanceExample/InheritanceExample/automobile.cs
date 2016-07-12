using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class Automobile
    {
        string _manufacturer;
        string _color;
        public double _Running { get; set; }
        public double _Consumption { get; set; }
        public double _Milage;
        public int _performance;

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
            _Milage = 0.0;
            _Running = 0.0;
            _Consumption = 0.0;
            _performance = (int)Performance.Good;
        }

        public void CalcMilage()
        {
            _Milage = _Running / _Consumption;
        }


        public void RatePerformance()
        {
            if (_Milage > _stdMilage)
            {
                _performance = (int)Performance.Excellent;
            }
            else if (_Milage == _stdMilage)
            {
                _performance = (int)Performance.Good;
            }
            else
            {
                _performance = (int)Performance.BelowAverage;
            }

        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Manufacturer : {_manufacturer}");
            Console.WriteLine($"Color : {_color}");
            Console.WriteLine($"Running in Km : {_Running}");
            Console.WriteLine($"Consupmtion in Litre : {_Consumption}");
            Console.WriteLine($"Milage in km/ltr : {_Milage}");
            Console.WriteLine($"Performance rating : {_performance}");
        }
        
    }
}
