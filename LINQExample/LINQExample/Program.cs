using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace LINQExample
{
    class Program
    {

        public static List<Product> prodList = ShoppingCart.GetshoppingCart();
        public static List<Fund> fundList = FundFileReader.ProcessFunds("Fund.csv");
        public static List<FundHouse> fundHouseList = FundHouseFileReader.ProcessFundHouses("FundHouse.csv");

        static void Main(string[] args)
        {
            //calling Extension method Filter without deferred execution
            //ExtensionMethod();

            //calling Extension method Filter with deferred execution
            //ExtensionMethodLazzy();

            // Result using the Expression sytax
            //LinqExpressionSyntax();

            // Result using the Query sytax
            //LinqQuerySyntax();

            //Result for First Operator
            //LinqOperatorFirst();

            //Result for Take Operator
            //LinqOperatorTake();

            //Result for Group By Operator
            // LinqOperatorGroup();

            //Result for Join operation on composite key
            //LinqOperatorJoin();

            //Result for Grpup Join operation
            //LinqOperatorGroupJoin();

            //Result for SelectMany operation
            //LinqOperatorSelectMany();

            //Result for Grpup Join operation
            //LinqOperatorSelectMany();

            //Result for Agrregation operation
            //LinqOperatorAggregate();

            //Convert to XMl using Linq
            ConverListToXML();

            //Read a XML using Linq
            ReadXMLToList();

        }


        private static void ExtensionMethod()
        {

            var expResult = prodList.Filter(p => p.Price > 100);
            foreach (var item in expResult)
            {
                Console.WriteLine($"Name :{item.Item}, Type :{item.ItemType}, Quantity :{item.Qty}, Price :{item.Price}");
            }
        }

        private static void ExtensionMethodLazzy()
        {

            Console.WriteLine("\n");
            Console.WriteLine("Lazy Filter ......");
            var expResult = prodList.FilterLazy(p => p.Price > 100);
            foreach (var item in expResult)
            {
                Console.WriteLine($"Name :{item.Item}, Type :{item.ItemType}, Quantity :{item.Qty}, Price :{item.Price}");
            }
        }

        private static void LinqExpressionSyntax()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Expression Syntax ......");

            var expResult = prodList.Where(p => p.Price >= 100)
                                     .OrderByDescending(p => p.ItemType)
                                     .ThenByDescending(p => p.Item);

            foreach (var item in expResult)
            {
                Console.WriteLine($" Type :{item.ItemType}, Name :{item.Item}, Quantity :{item.Qty}, Price :{item.Price}");
            }
        }

        private static void LinqQuerySyntax()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Query Syntax ......");

            var expResult = from p in prodList
                            where p.Price >= 100
                            orderby p.ItemType descending, p.Item descending
                            select p;

            foreach (var item in expResult)
            {
                Console.WriteLine($" Type :{item.ItemType}, Name :{item.Item}, Quantity :{item.Qty}, Price :{item.Price}");
            }
        }

        private static void LinqOperatorFirst()
        {
            Console.WriteLine("\n");
            Console.WriteLine("First operator result ......");
            var item = prodList.Where(p => p.Price >= 100)
                                     .OrderByDescending(p => p.ItemType)
                                     .ThenBy(p => p.Item)
                                     .First(p => p.ItemType.Contains("Dairy"));


            Console.WriteLine($" Type :{item.ItemType}, Name :{item.Item}, Quantity :{item.Qty}, Price :{item.Price}");
        }

        private static void LinqOperatorTake()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Take operator result ......");

            var expResult = prodList.Where(p => p.Price >= 100)
                                         .OrderByDescending(p => p.ItemType)
                                         .ThenBy(p => p.Item)
                                         .Take(2);

            foreach (var item in expResult)
            {
                Console.WriteLine($" Type :{item.ItemType}, Name :{item.Item}, Quantity :{item.Qty}, Price :{item.Price}");
            }
        }

        private static void LinqOperatorGroup()
        {
            Console.WriteLine("\n");
            Console.WriteLine("GroupBy operator result (Expression) ......");

            var expResult = prodList.GroupBy(p => p.ItemType, p => new { Name = p.Item, Quantity = p.Qty, Price = p.Price });

            foreach (var grouping in expResult)
            {
                Console.WriteLine($"{grouping.Key} , Count - {grouping.Count()}");
                foreach (var item in grouping)
                {
                    Console.WriteLine($" Name :{item.Name}, Quantity :{item.Quantity}, Price :{item.Price}");
                }

            }

            Console.WriteLine("\n");
            Console.WriteLine("GroupBy operator result (Query) ......");

            var qryResult = from gr in (
                                        from p in prodList
                                        group p by p.ItemType into groupResult
                                        select groupResult
                                        )
                            select new
                            {
                                key = gr.Key,
                                count = gr.Count(),
                                prodList = (
                                            from g in gr
                                            select new { Name = g.Item, Quantity = g.Qty, Price = g.Price }
                                           )
                            };


            foreach (var grouping in qryResult)
            {
                Console.WriteLine($"{grouping.key} , Count - {grouping.count}");
                foreach (var item in grouping.prodList)
                {
                    Console.WriteLine($" Name :{item.Name}, Quantity :{item.Quantity}, Price :{item.Price}");
                }

            }

        }

        private static void LinqOperatorJoin()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Join operator on composite key result (Expression) ......");

            var expResult = fundList.Join(fundHouseList,
                                            f => { return new { f.fundCompany, f.year }; },
                                            h => { return new { h.fundCompany, h.year }; },
                                            (f, h) => new { h.fundCompany, h.year, f.fundName }
                                          )
                                     .Where(r => r.fundCompany.Contains("ICICI"))
                                     .ToList();
            expResult.ForEach(i => Console.WriteLine($" { i.fundCompany} , { i.fundName} ,{i.year } "));


            Console.WriteLine("\n");
            Console.WriteLine("Join operator on composite key result (Query) ......");

            var qryResult = from f in fundList
                            join h in fundHouseList
                            on new { f.fundCompany, f.year } equals new { h.fundCompany, h.year }
                            where f.fundCompany.Contains("ICICI")
                            select new { h.fundCompany, h.year, f.fundName };

            qryResult.ToList().ForEach(i => Console.WriteLine($" { i.fundCompany},{ i.fundName} ,{i.year } "));

        }

        private static void LinqOperatorGroupJoin()
        {
            Console.WriteLine("\n");
            Console.WriteLine("GroupJoin operator result (Expression) ......");

            var expResult = fundHouseList.GroupJoin(fundList,
                                                    h => h.fundCompany,
                                                    f => f.fundCompany,
                                                    (h, grp) => new { _fundHouse = h, _grpfunds = grp.OrderByDescending(f => f.totalAsset) }
                                                    )
                                         .OrderBy(s => s._fundHouse.fundCompany);

            expResult.Take(4).ToList().ForEach(
                                                    i =>
                                                    {
                                                        Console.WriteLine($" { i._fundHouse.fundCompany} , {i._fundHouse.year } , {i._grpfunds.Count()} ");
                                                        i._grpfunds.ToList().ForEach(j => Console.WriteLine($"\t {j.fundName} , {j.fundCategory} , {j.NAV} , {j.totalAsset}"));
                                                    }
                                              );


            Console.WriteLine("\n");
            Console.WriteLine("GroupJoin operator result (Query) ......");

            var qryResult = from h in fundHouseList
                            join f in fundList
                            on h.fundCompany equals f.fundCompany into grpFunds
                            orderby h.fundCompany
                            select
                            new
                            {
                                _fundHouse = h,
                                _grpfunds = from g in grpFunds orderby g.totalAsset descending select g
                            };

            qryResult.Take(4).ToList().ForEach(
                                                    i =>
                                                    {
                                                        Console.WriteLine($" { i._fundHouse.fundCompany} , {i._fundHouse.year } , {i._grpfunds.Count()} ");
                                                        i._grpfunds.ToList().ForEach(j => Console.WriteLine($"\t {j.fundName} , {j.fundCategory} , {j.NAV} , {j.totalAsset}"));
                                                    }
                                             );


            Console.WriteLine("\n");
            Console.WriteLine("Join and then Group by  operator result (Expression) ......");

            var expResult1 = fundHouseList.Join(fundList,
                                                h => h.fundCompany,
                                                f => f.fundCompany,
                                                (h, f) => new { h.year, h.fundCompany, f.fundCategory, f.fundName ,f.NAV}
                                               )
                                           .GroupBy(a => a.fundCategory)
                                           .OrderBy(r=>r.Key);

            expResult1.ToList().ForEach(i =>
            {
                Console.WriteLine($" Fund Category : { i.Key} ");
                i.OrderByDescending(r=>r.NAV).ToList().ForEach(j => Console.WriteLine($"\t {j.fundName} , {j.NAV} "));
            });


        }

        private static void LinqOperatorSelectMany()
        {
            Console.WriteLine("\n");
            Console.WriteLine("SelectMany operator result (Expression) ......");

            var expResult = fundHouseList.Join(fundList,
                                                h => h.fundCompany,
                                                f => f.fundCompany,
                                                (h,f) => new { h.year, h.fundCompany,f.fundCategory,f.fundName}
                                               )
                                         .GroupBy(a=> a.fundCategory)
                                         .SelectMany(g=>g)
                                         ;

            expResult.OrderBy(r=>r.fundName).ToList().ForEach(r => Console.WriteLine(r.fundName));

        }

        private static void LinqOperatorAggregate()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Aggregation Min Max and Avg operator result (Expression) ......");

            var expResult = fundList.GroupBy(f=>f.fundCompany) 
                                    .Select(g => {
                                                    var stats = g.Aggregate(new FundStatistics(), (acc, f) => acc.Accumulate(f), acc => acc.Compute());
                                                    return new
                                                    {
                                                        g.Key,
                                                        stats.Max,
                                                        stats.Min,
                                                        stats.Avg
                                                    };
                                                }
                                            )
                                     .OrderByDescending(g => g.Max);


            expResult.ToList().ForEach(
                                            i =>
                                            {
                                                Console.WriteLine($"Fund House : { i.Key} \tMax NAV : {i.Max} \tMin NAV : {i.Min} \tAvg NAV : {i.Avg}");
                                            }
                                       );



            Console.WriteLine("\n");
            Console.WriteLine("Another Example Aggregation Min Max and Avg operator result (Expression) ......");

            var expResult1 = fundList.GroupBy(f=>f.fundCategory)
                                     .Select(g=> {

                                                    var stats = g.ToList().Aggregate(new FundStatistics(), (acc, f) => acc.Accumulate(f), acc => acc.Compute());
                                                     return new { g.Key, Min = stats.Min, Max = stats.Max, Avg = stats.Avg };

                                                 })
                                      .OrderByDescending(r=>r.Max);

            expResult1.ToList().ForEach(
                                        i =>
                                        {
                                            Console.WriteLine($"Fund Category : { i.Key} \tMax NAV : {i.Max} \tMin NAV : {i.Min} \tAvg NAV : {i.Avg}");
                                        }
                                   );

            Console.WriteLine("\n");
            Console.WriteLine("Aggregation Min Max and Avg operator result (Query) ......");

            var qryResult = from f in fundList
                            group f by f.fundCompany into grpResult
                            select
                            new
                            {
                                Key = grpResult.Key,
                                Min = grpResult.Min(f=>f.NAV),
                                Max = grpResult.Max(f => f.NAV),
                                Avg = grpResult.Average(f => f.NAV)

                            } into result
                            orderby result.Max descending
                            select result;

            qryResult.ToList().ForEach(
                                            i =>
                                            {
                                                Console.WriteLine($"Fund House : { i.Key} \tMax NAV : {i.Max} \tMin NAV : {i.Min} \tAvg NAV : {i.Avg}");
                                            }
                                       );

        }

        private static void ConverListToXML()
        {
            var document = new XDocument();
            var funds = new XElement("Funds", from rec in fundList
                                              select new XElement("Fund", new XAttribute("Fund", rec.fundName)
                                                                        , new XAttribute("FundCategory", rec.fundCategory)
                                                                        , new XAttribute("FundHouse", rec.fundCompany)
                                                                        , new XAttribute("Year", rec.year)
                                                                        , new XAttribute("NAV", rec.NAV)
                                                                        , new XAttribute("AUM", rec.totalAsset)
                                                                 ));

            var fundhouses = new XElement("FundHouses", from rec in fundHouseList
                                                        select new XElement("FundHouse", new XAttribute("FundHouse", rec.fundCompany)
                                                                                       , new XAttribute("Year", rec.year)                                                                       
                                                                 ));
            document.Add(funds);
            document.Save("fund.xml");

            document = new XDocument();
            document.Add(fundhouses);
            document.Save("fundhouse.xml");






        }

        private static void ReadXMLToList()
        {

            Console.WriteLine("\n");
            Console.WriteLine("Reading XML into List(Query) ......");

            Console.WriteLine("");
            var document = XDocument.Load("fund.xml");
            var list = from d in document.Descendants("Fund")
                       where (string)d.Attribute("FundCategory") == "Balanced"
                       select new { _fundHouse = (string)d.Attribute("FundHouse"),
                                    _fund = (string)d.Attribute("Fund"),
                                    _nav = (double)d.Attribute("NAV"),
                                    _aum = (double)d.Attribute("AUM")
                       };


            Console.WriteLine("\n");
            Console.WriteLine("Reading XML into List(Experssion) ......");

            var expResult = document.Descendants("Fund")
                            .Where(fund => (string)fund.Attribute("FundCategory") == "Balanced")
                            .Select(fund => new
                            {
                                _fundHouse = (string)fund.Attribute("FundHouse"),
                                _fund = (string)fund.Attribute("Fund"),
                                _nav = (double)fund.Attribute("NAV"),
                                _aum = (double)fund.Attribute("AUM")
                            });



            expResult.ToList().ForEach(r => { Console.WriteLine($"Fund - {r._fundHouse} , {r._fund} , {r._nav} , {r._aum}"); });
            
        }
    }
}
