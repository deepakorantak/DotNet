using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {

            CreateSquareList();
            CreateCircleQueue();
            convertTypes();

         
        }

        private static void CreateSquareList()
        {
            Square s1 = new Square(3);
            Square s2 = new Square(4);
            Square s3 = new Square(5);

            ListShape<Square> q2 = new ListShape<Square>();

            AddBuffer<Square>(q2, s1);
            AddBuffer<Square>(q2, s2);
            AddBuffer<Square>(q2, s3);

            Console.WriteLine("Elements in the List of Squares....");
            PrintAllBuffer(q2);

            AbstractShape sd = DeleteBuffer(q2);

            Console.WriteLine($"Square  :  with side-  {sd._param} :  area - {sd._area} :  circuference - {sd._circumference} got deleted from the list ");
            
            Console.WriteLine("Elements in the List of Squares post deletion of S2....");

            PrintAllBuffer(q2);
        }

        private static void CreateCircleQueue()
        {
            Circle c1 = new Circle(3);
            Circle c2 = new Circle(4);
            Circle c3 = new Circle(5);
           

            QueueShape<AbstractShape> q1 = new QueueShape<AbstractShape>();

            AddBuffer<Circle>(q1, c1);
            AddBuffer<Circle>(q1, c2);
            AddBuffer<Circle>(q1, c3);

            Console.WriteLine("Elements in the Queue of Circles....");

            PrintAllBuffer(q1);

            AbstractShape del = DeleteBuffer(q1);

            Console.WriteLine($"Circle  :  with radius-  {del._param} :  area - {del._area} :  circuference - {del._circumference} got deleted from the queue ");

            Console.WriteLine("Elements in the Queue of Circles after deletion...");
            PrintAllBuffer(q1);
        }

        public static void PrintAllBuffer(IBufferReadOnlyShape<AbstractShape> _ibuffer)
        {
            
            foreach (var item in _ibuffer)
            {
                String typeClass = item.GetType().ToString().Remove(0, 16);
                String paramName = typeClass.Equals("Circle") ? "radius-" : typeClass.Equals("Square")?"side-":"parameter-";

            Console.WriteLine($"{typeClass} : with {paramName } {item._param} , area -  {item._area } , circumference - {item._circumference}");
            } 
        }

        public static void AddBuffer<T>(IBufferWriteOnlyShape<T> _buffer, T item)
        {
            _buffer.add(item);
        }
               

        public static AbstractShape DeleteBuffer(IBufferReadOnlyShape<AbstractShape> _buffer)
        {
            return _buffer.delete();
        }

        public static void convertTypes()
        {

            Square s1 = new Square(3);

            Console.WriteLine($"Square  :  with side-  {s1._param} :  area - {s1._area} :  circuference - {s1._circumference} ");

            Converter<Square, Circle> convertsquare = (s) =>
            {
                Circle cc = new Circle(s._param);
                return cc;
            };

            Circle c1 = TypeConvert<Square, Circle>(s1, convertsquare);
            Console.WriteLine($"Post conversion - Circle created with radius -  {c1._param} :  area - {c1._area} :  circuference - {c1._circumference} ");

            Converter<Circle, Square> convertcircle = (c) =>
            {
                Square cs = new Square(c._param);
                return cs;
            };

            // No need to explicitly specify the Generic input and output parametes for the Typeconvert method 
            s1 = TypeConvert(c1, convertcircle);
            Console.WriteLine($"Post conversion - original Sqaure created with side -  {s1._param} :  area - {s1._area} :  circuference - {s1._circumference} ");
        }

        public static Toutput TypeConvert<T, Toutput>(T sq, Converter<T, Toutput> convert)
        {
            return convert(sq);
        }
    }
}
