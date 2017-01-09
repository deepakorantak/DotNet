using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            //Get type of the square and accessing it's memebers
            var type = typeof(Square);
            Console.WriteLine( $"Type is : {type}" );
            
            var members = type.GetMembers(BindingFlags.Static |
                                            BindingFlags.Instance |
                                            BindingFlags.NonPublic |
                                            BindingFlags.Public
                                            );
            foreach (var item in members)
            {
                Console.WriteLine($"Members of Shapre class : {item.Name} ");
               
            }


            Square s1 = new Square(2);

            // Invoking a method of s1 by refelction

            var _stype = s1.GetType();
            MethodInfo minfo = _stype.GetMethod("ExecuteFormulaForArea");
            
            double result = (double)minfo.Invoke(s1,null);

            Console.WriteLine( $"Result of invoked method ExecuteFormulaForArea is : {result}");

            // Getting value of a property of s1 by refelction

            PropertyInfo pinfo = _stype.GetProperty("_area");
            double area = (double)pinfo.GetValue(s1) ;

            Console.WriteLine($"Value of property _area is : {area}");
                    
        

        }
    }
}
