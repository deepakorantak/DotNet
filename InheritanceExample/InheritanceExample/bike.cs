using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class bike : automobile
    {
        public bike(string manf, string color,string iengine)
            : base(manf, color)
        {
            _performance = (int)Performance.Good;
            engine = iengine;
        }

        static double stdMilage = 80;
        string engine;
        int _performance;

        enum Performance
        {
            Excellent = 3,
            Good = 2,
            BelowAverage = 1

        }

       


        public void RatePerformance()
        {
            if (Milage > stdMilage)
            {
                _performance = (int)Performance.Excellent;
            }
            else if (Milage == stdMilage)
            {
                _performance = (int)Performance.Good;
            }
            else
            {
                _performance = (int)Performance.BelowAverage;
            }

        }
    }
}
