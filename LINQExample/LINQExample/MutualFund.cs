using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    class MutualFund
    {
        public string fundCompany { get; set; }
        public string fundName { get; set; }
        public double totalAsset { get; set; }
        public double NAV { get; set; }
        public string fundCategory { get; set; }
        public int year { get; set; }
    }

    class FundFileReader
    {
        public static List<MutualFund> ProcessFunds(string fileName)
        {

            List<MutualFund> result = new List<MutualFund>();

            result = File.ReadAllLines(fileName)
                         .Skip(1)
                         .Where(l => l.Length > 1)
                         .Select(r =>
                                         {
                                             var columns = r.Split(',');
                                             return new MutualFund
                                             {
                                                 fundCompany = columns[0],
                                                 fundName = columns[1],
                                                 totalAsset = double.Parse(columns[2]),
                                                 NAV = double.Parse(columns[3]),
                                                 fundCategory = columns[4],
                                                 year = int.Parse(columns[5])
                                             };
                                         }
                                    ).ToList<MutualFund>();
            return result;
        }
    }

    class FundStatistics
    {
        public double Max { get; set; }
        public double Min { get; set; }
        public double Avg { get; set; }

        private int Count = 0;
        private double Total = 0.0;

        public FundStatistics()
        {
            Max = double.MinValue;
            Min = double.MaxValue;
        }

        public FundStatistics Accumulate(MutualFund f)
        {
            Total += f.NAV;
            Count += 1;
            Min = Math.Min(Min,f.NAV);
            Max = Math.Max(Max, f.NAV);
            return this;
        }

        public FundStatistics Compute()
        {
            Avg = Total / Count;
            return this;
        }

    }
}
