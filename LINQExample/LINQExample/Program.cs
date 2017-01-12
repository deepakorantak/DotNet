using System;
using System.Collections.Generic;
using System.Linq;


namespace LINQExample
{
    class Program
    {

        public static List<Product> prodList = ShoppingCart.GetshoppingCart();

        static void Main(string[] args)
        {
            //calling Extension method Filter without deferred execution
            //ExtensionMethod();

            ////calling Extension method Filter with deferred execution
            //ExtensionMethodLazzy();

            //// Result using the Expression sytax
            //LinqExpressionSyntax();

            //// Result using the Query sytax
            //LinqQuerySyntax();

            ////Result for First Operator
            //LinqOperatorFirst();

            ////Result for Take Operator
            //LinqOperatorTake();

            //Result for Group By Operator
            LinqOperatorGroup();

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
                               // count = gr.Count(),
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
    }
}
