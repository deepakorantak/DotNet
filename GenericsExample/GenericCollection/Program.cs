using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    class Program
    {
        static void Main(string[] args)
        {

            var dir = new SortedDictionary<String, SortedSet<Security>>();
            dir.Add("ICICI", new SortedSet<Security>(new SecurityComparer()));
            dir["ICICI"].Add(new Security { _securityNumber = "SEC103" });
            dir["ICICI"].Add(new Security { _securityNumber = "SEC101" });
            dir["ICICI"].Add(new Security { _securityNumber = "102" });


            dir.Add("HDFC", new SortedSet<Security>(new SecurityComparer()));
            dir["HDFC"].Add(new Security { _securityNumber = "SEC203" });
            dir["HDFC"].Add(new Security { _securityNumber = "SEC101" });
            dir["HDFC"].Add(new Security { _securityNumber = "SEC202" });
            dir["HDFC"].Add(new Security { _securityNumber = "SEC202" });

            foreach (var fund in dir)
            {
                Console.WriteLine($"Fund : {fund.Key}");
                foreach (var sec in fund.Value)
                {
                    Console.WriteLine($"\t Security : {sec._securityNumber}"  );
                }
            }


        }
    }
}
