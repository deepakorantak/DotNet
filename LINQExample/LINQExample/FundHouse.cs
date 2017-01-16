using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    class FundHouse
    {
        public string fundCompany { get; set; }
        public int year { get; set; }
    }

    class FundHouseFileReader
    {
        public static List<FundHouse> ProcessFundHouses(string fileName)
        {

            List<FundHouse> result = new List<FundHouse>();

            result = File.ReadAllLines(fileName)
                         .Skip(1)
                         .Where(l => l.Length > 1)
                         .Select(r =>
                         {
                             var columns = r.Split(',');
                             return new FundHouse
                             {
                                 fundCompany = columns[0],
                                 year = int.Parse(columns[1])
                             };
                         }
                                    ).ToList<FundHouse>();
            return result;
        }
    }
}
