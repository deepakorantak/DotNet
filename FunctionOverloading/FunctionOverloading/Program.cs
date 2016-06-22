using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionOverloading
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 2, b = 3;
            Console.WriteLine("Result : " + add(a, b));

            float c = 3.1f, d = 4.2f;
            Console.WriteLine("Result : " + add(c, d));
        }
        

        static int add(int var1, int var2)
        {
            return var1 + var2;
        }

        static float add(float var1 , float var2)
        {
            return var1 + var2;
        }
    }
}
