using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            ISet<int> f1 = new SortedSet<int>();
            ISet<int> f2 = f1;

            Console.WriteLine($"F1 : {f1.GetHashCode()} , type :{f1.GetType()}");
            Console.WriteLine($"F2 : {f2.GetHashCode()} , type :{f2.GetType()}");

            Person p1 = new Person(iage: 21, iname: "Tom");

            Console.WriteLine($"p1 : {p1.GetHashCode()} , type :{p1.GetType()}");
            ChangeName(p1);
            Console.WriteLine($"Name : {p1.name} ");

            Expression<Func<int, int, bool>> f = (s1, s2) => s1 < s2;
            Console.WriteLine(f.Body);

            object[] vals = { "abc", "xyz", "lmn" };
            IEnumerable<string> val1 = vals.OfType<string>();

            val1.Where(s => s.Contains("a"));
            
        }

        public static void ChangeName(Person iP)
        {
            Console.WriteLine($"p1 : {iP.GetHashCode()} , type :{iP.GetType()}");
            iP.name = "Jon";
        }
    }
}
