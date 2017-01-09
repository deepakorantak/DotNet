using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFundamental
{
    class Program
    {

        public static List<Fund> listOfFund = new List<Fund>();
        public static List<Customer> listOfCustomer = new List<Customer>();

        static void Main(string[] args)
        {

            PopulateFundList();
            
            PopulateCustomerList();
            
            SortList();

            PrintList(listOfFund);

            OrderList();

            PrintList(listOfFund);

            FilteList();

            JoinFundCustomer();

        }

        private static void JoinFundCustomer()
        {
            var queryResult = from f in listOfFund
                              join c in listOfCustomer on f._customerID equals c._customerID
                              where f._fundName.Contains("Balanced")
                              orderby f._fundName
                              select new { custName = c._customerName, fundNumber = f._fundNumber, fundName = f._fundName };

            Console.WriteLine("Joining Collection using LINQ and result of the query ....");

            foreach (var item in queryResult)
            {
                Console.WriteLine( $"Customer Name : {item.custName} , Fund Number : {item.fundNumber} , Fund Name : {item.fundName}");
            }


        }

        private static void FilteList()
        {
            //Filtering based on condition
            Console.WriteLine("Filtering List based on Criteria = fund Name  contains ICICI");
            Predicate<Fund> pr = c => c._fundName.Contains("ICICI");
            listOfFund.FindAll(pr).ForEach(p => Console.WriteLine($"Fund Number : {p._fundNumber} , Fund Name : {p._fundName}"));
            
            Console.WriteLine("Filtering List based on Criteria = fund Name  contains HDFC");
            Func<Fund, bool> f1 = d => d._fundName.Contains("HDFC");
            listOfFund.Where(f1 ).ToList<Fund>().ForEach(p => Console.WriteLine($"Fund Number : {p._fundNumber} , Fund Name : {p._fundName}"));

          
        }

        private static void OrderList()
        {
            //Sorting the list using order by fund number 
            Func<Fund, int> f = (p) => { return p._fundNumber; };
            Console.WriteLine("Using Order By clause = fund number");
            listOfFund.OrderBy<Fund, int>(f).ToList<Fund>().ForEach(p => Console.WriteLine($"Fund Number : {p._fundNumber} , Fund Name : {p._fundName}"));
                      
        }

        private static void SortList()
        {
            //Sorting using Sort Function 
            Console.WriteLine("Using sorting by fund name....");

            Comparison<Fund> delComparison = (x, y) => { return x._fundName.CompareTo(y._fundName); };
            listOfFund.Sort(delComparison);
        }

        private static void PopulateFundList()
        {
            listOfFund.Add(new Fund(11,1, "ICICI Prudential - Balanced Fund"));
            listOfFund.Add(new Fund(11,3, "ICICI Prudential - Debt Fund"));
            listOfFund.Add(new Fund(22,2, "HDFC - Equity(G) Fund"));
            listOfFund.Add(new Fund(22,4, "HDFC - Balanced Fund"));

        }


        private static void PopulateCustomerList()
        {
            listOfCustomer.Add(new Customer(11, "ICICI Prudential"));
            listOfCustomer.Add(new Customer(22, "HDFC"));
        }


        private static void PrintList(List<Fund> listOfFund)
        {
            Console.WriteLine("List of Funds ....");
            Action<Fund> s = p => { Console.WriteLine($"Fund Number : {p._fundNumber} , Fund Name : {p._fundName}"); };
            listOfFund.ForEach(s);
        }
    }
}
