
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceImplementation
{
    class FundRepositoryService : AbstractFundRepository
    {
        protected override void PopulateRepsoitoryCustomer()
        {
            _listCustomer = new List<Customer>();
            _listCustomer.Add(new Customer(11, "ICICI Prudential"));
            _listCustomer.Add(new Customer(22, "HDFC"));
        }

        protected override void PopulateRepsoitoryFund()
        {
            _listFund = new List<Fund>();
            _listFund.Add(new Fund(11, 1, "ICICI Prudential - Balanced Fund"));
            _listFund.Add(new Fund(11, 3, "ICICI Prudential - Debt Fund"));
            _listFund.Add(new Fund(22, 2, "HDFC - Equity(G) Fund"));
            _listFund.Add(new Fund(22, 4, "HDFC - Balanced Fund"));
        }
    }
}
