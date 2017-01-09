using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFundamental
{
    class Fund
    {
        public int _fundNumber { get; set; }
        public String _fundName { get; set; }
        public double? _nav { get; set; }
        public int _customerID { get; set; }

        public Fund()
        {
            Console.WriteLine("Default constructor ....");
        }

        public Fund(int CustomerID , int FundNumber, String FundName, double? NAV = null  )
        {
            Console.WriteLine("Parameterised constructor ....");

            _customerID = CustomerID;
            _fundName = FundName;
            _fundNumber = FundNumber;
            _nav = NAV;
        }

    }

    class Customer
    {
        public int _customerID { get; set; }
        public String _customerName { get; set; }

        public Customer(int CustomerID, String CutomerName)
        {
            _customerID = CustomerID;
            _customerName = _customerName;
        }
    }
}
