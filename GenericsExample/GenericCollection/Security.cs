using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    class Security
    {
        public string _securityNumber { get; set; }
       
    }

    class SecurityComparer : IEqualityComparer<Security> , IComparer<Security>
    {
        public int Compare(Security x, Security y)
        {
          return  x._securityNumber.CompareTo(y._securityNumber) ;
        }

        public bool Equals(Security x, Security y)
        {
            return x._securityNumber.Equals(y._securityNumber);

        }

        public int GetHashCode(Security obj)
        {
            return obj._securityNumber.GetHashCode();
        }
    }


}
