using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class Bike : Automobile
    {
        string _engine;

        public Bike(string manf, string color,string iengine)
            : base(manf, color)
        {           
            _engine = iengine;
            _stdMilage = 80;
        }                      
       
    }
}
