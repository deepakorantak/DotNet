using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class car : automobile
    {
        public car(string manf, string color, string trans)
            : base(manf, color)
        {
            _performance = (int)Performance.Good;
            transmission = trans;
        }

        static double stdMilage = 13.25;
        string transmission;
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

