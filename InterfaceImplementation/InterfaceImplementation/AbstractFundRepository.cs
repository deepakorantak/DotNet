using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceImplementation
{
    abstract class AbstractFundRepository : IFundRepository
    {
        protected List<Customer> _listCustomer;

        protected List<Fund> _listFund;

        protected List<QueryResult> _queryResult;

        public List<QueryResult> GetRepository()
        {
            _queryResult = new List<QueryResult>();

            var result = (from f in _listFund
                          join c in _listCustomer on f._customerID equals c._customerID
                          orderby c._customerName,f._fundName
                          select new { CustName = c._customerName, FundNumber = f._fundNumber, FundName = f._fundName })
                        ;

            foreach (var item in result)
            {
                _queryResult.Add(new QueryResult(item.CustName, item.FundNumber, item.FundName));
            }

            return _queryResult;
        }


        public AbstractFundRepository()
        {

            PopulateRepsoitoryCustomer();
            PopulateRepsoitoryFund();

        }

        protected abstract void PopulateRepsoitoryCustomer();

        protected abstract void PopulateRepsoitoryFund();

    }
}
