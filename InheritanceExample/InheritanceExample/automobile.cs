using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class automobile
    {
        string manufacturer;
        string color;
        public double Running { get; set; }
        public double Consumption { get; set; }
        public double Milage ;

        public automobile(string manf,string col)
        {
            manufacturer = manf;
            color = col;
            Milage = 0.0;
            Running = 0.0;
            Consumption = 0.0;
        }

        public void  CalcMilage()
        {
           Milage = Running / Consumption;
        }


    }
}
