using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVsAbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
           
            // Virtual method demonstration 
            // Type parent - Object child 
            Shape c1 = new Circle(2.2);
            Console.WriteLine( $"Area of circle c1 :{c1._area}" );
            Console.WriteLine($"AreaNV of circle c1 :{c1._areaNV}");

            // Type parent - Object parent
            Shape c2 = new Shape();
            Console.WriteLine($"Area of circle c2 :{c2._area}");
            Console.WriteLine($"AreaNV of circle c2 :{c2._areaNV}");

            // Type child - Object child
            Circle c3 = new Circle(4.4);
            Console.WriteLine($"Area of circle c3 :{c3._area}");
            Console.WriteLine($"AreaNV of circle c3 :{c3._areaNV}");

            // Console.ReadLine();
            //Abstract Class demonstration

            Square s1 = new Square(1.5);
            Console.WriteLine($"Area of square s1 :{s1._area}");
            Console.WriteLine($"Circumference of square s1 :{s1._circumference}");
        }
    }
}
