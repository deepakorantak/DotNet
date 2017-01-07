using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InterfaceImplementation
{
    class FundRepositoryXML : AbstractFundRepository
    {
       
        XDocument doc = XDocument.Load("D:\\Deepa\\Training\\GitHub\\DotNet\\InterfaceImplementation\\InterfaceImplementation\\bin\\Debug\\data.xml");

        protected override void PopulateRepsoitoryCustomer()
        {

            _listCustomer = new List<Customer>();
            IEnumerable<XElement> res = doc.Descendants("Customer");
            foreach (var item in res)
            {
                _listCustomer.Add(new Customer (CustomerID: (int)item.Attribute("Number"), 
                                                CutomerName: (string)item.Attribute("Name")
                                                )
                                 );
            }

            Console.WriteLine("Printing List of customers");
            _listCustomer.ForEach(p => { Console.WriteLine($"{p._customerID } , {p._customerName}"); });
        }

        protected override void PopulateRepsoitoryFund()
        {
            _listFund = new List<Fund>();
            IEnumerable<XElement> res = doc.Descendants("Fund");
            foreach (var item in res)
            {
                _listFund.Add(new Fund(CustomerID: (int)item.Attribute("Customer_Number"),
                                       FundNumber: (int)item.Attribute("Fund_Number"),
                                       FundName: (string)item.Attribute("Fund_Name")
                                      )
                             );
            }

            Console.WriteLine("Printing List of funds");
            _listFund.ForEach(p => { Console.WriteLine($"{p._customerID } , {p._fundNumber} , {p._fundName}"); });
        }

      }
}
