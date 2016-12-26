using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePosticrementOperator
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0;
            int res;

            res = i++;
            Console.WriteLine($" Postfix ++  result : {res} and i : {i}  ");

            res = ++i;
            Console.WriteLine($" Prefix ++ result : {res} and i : {i}  ");
        }
    }
}
