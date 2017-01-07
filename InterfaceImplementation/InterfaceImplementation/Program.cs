using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureFundRepository f = new ConfigureFundRepository();
            List<QueryResult> result = f.GetFundResult();
           // result.Sort((a, b) => { return a.customerName.CompareTo(b.customerName); });
            result.ForEach(e =>
                                {
                                    Console.WriteLine($"Customer Name : {e.customerName} , Fund Number :{e.fundNumber} , Fund Name {e.fundName}");
                                }
            );

        }
    }
}
