using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class Car : Automobile
    {

        string _transmission;
        public Car(string manf, string color, string trans)
            : base(manf, color)        {
          
            _transmission = trans;
            _stdMilage = 13.25;
        }

        
                     
 
    }
}

