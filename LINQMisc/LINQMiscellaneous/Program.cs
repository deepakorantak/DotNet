using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace LINQMiscellaneous
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinqChallengeSwimLengths();
            //LinqChallengeKeyCount();
            //LinqChallengeBishop();
            //LinqChallengeAge();
            //LinqChallengeRange();
            //LinqChallengeAlbumDuration();
            //LinqChallengeAvgScore();

        }

        private static void LinqChallengeSwimLengths()
        {
            var orgList = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35"
            .Split(',')
            .Select(r => "00:" + r)
            .ToList();

            Console.WriteLine("Original List : ");
            orgList.ForEach(r => Console.WriteLine(r));
          

            var InitialVal = new List<string>();
            InitialVal.Add("00:00:00");

            var diffList = InitialVal
                            .Concat(orgList)
                            .Take(orgList.Count())
                            .ToList();

           Console.WriteLine("Second List : ");
           diffList.ForEach(r => Console.WriteLine(r));

            Console.WriteLine("Swimming lengths : ");
            orgList.Zip(diffList, (f, s) => TimeSpan.Parse(f) - TimeSpan.Parse(s))
            .ToList()
            .ForEach(r => Console.WriteLine(r));                     
                     
                                                              
            
        }

        private static void LinqChallengeKeyCount()
        {
            Console.WriteLine("Animal and their count :");
            "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
             .Split(',')
             .Select(r => { if (r == "Dog" || r == "Cat") return r; else return "Other"; })
             .GroupBy(r => r)
             .Select(r => new { name = r.Key, count = r.Count() })
             .OrderBy(r => r.name)
             .ToList()
             .ForEach(r => Console.WriteLine($"{r.name} : {r.count}"));

            Console.WriteLine("Using extension method - Animal and their count :");
            "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog"
             .Split(',')
             .Select(r => { if (r == "Dog" || r == "Cat") return r; else return "Other"; })
             .CountBy(r => r)
             .ToList()
             .ForEach(r => Console.WriteLine($"{r.Key} : {r.Value}"));

        }


        private static void LinqChallengeBishop()
        {
            Console.WriteLine($"Bishop possible moves from c6:");
            Enumerable.Range('a', 8)
                      .SelectMany(r => Enumerable.Range('1', 8), (c, r) => new { column = (char)c, row = (char)r })
                      .Where(r=> (Math.Abs(r.column - 'c') == Math.Abs(r.row - '6')) && (r.column != 'c'))
                      .ToList()
                      .ForEach(a => Console.WriteLine($"{a.column}{a.row}"));

            Console.WriteLine($"Post refactoring - Bishop possible moves from c6:");
           
            GetChaseBoard()
                      .Where(r => IsBishopMove(r,"c6") )
                      .ToList()
                      .ForEach(a => Console.WriteLine(a));

            Console.WriteLine($"Using Query Expression - Bishop possible moves from c6:");

            (from col in Enumerable.Range('a', 8)
            from row in Enumerable.Range('1', 8)
            let dc = Math.Abs(col - 'c')
            let dr= Math.Abs(row - '6')
            where dr == dc && dc != 0
            select new { square = String.Concat((char)col, (char)row) , dr,dc})
            .ToList()
            .ForEach(a => Console.WriteLine(a.square));

           

        }

        private static bool IsBishopMove(string r, string v)
        {
            return ((Math.Abs(r[0] - v[0]) == Math.Abs(r[1] - v[1])) && r[0] != 'c');            
            
        }

        private static IEnumerable<string> GetChaseBoard()
        {
            return Enumerable.Range('a', 8)
                     .SelectMany(r => Enumerable.Range('1', 8), (c, r) => String.Concat((char)c, (char)r));
        }

        private static void LinqChallengeAge()
        {

            Console.WriteLine($"Linear Sequence calculating Age :");

            Func<string, DateTime> parseDOB = dob => DateTime.ParseExact(dob, "d/M/yyyy", CultureInfo.InvariantCulture);
            File.ReadAllLines("D:\\Deepa\\Training\\GitHub\\DotNet\\LINQMisc\\challengeAge.txt")
                                .Where(r => r.Length > 1)
                                .Select(r => r.Split(','))
                                .Select(s => new { name = s[0], dob = parseDOB(s[1]) })
                                .Select(s => new { name = s.name, dob = s.dob, age = GetAge(s.dob) })
                                .OrderByDescending(r => r.age)
                                .ToList()
                                .ForEach(r => Console.WriteLine($"Name : {r.name} , Date of Birth : {r.dob} , Age : {r.age}"));
        }

        private static int GetAge(DateTime dob)
        {
            var age = (DateTime.Today.Year - dob.Year);
            if (dob > DateTime.Today.AddYears(-age)) age--;
            return age;
        }

        private static void LinqChallengeRange()
        {
            Console.WriteLine($"Linear Sequence :");

            "2,5,7-10,11,17-18"
            .Split(',')
            .Select(r => r.Split('-'))
            .Select(r => new { start = Int32.Parse(r[0]), last = Int32.Parse(r.Last()) })
            .SelectMany(r => Enumerable.Range(r.start, r.last - r.start + 1))
            .ToList()
            .ForEach(r => Console.WriteLine(r));

            Console.WriteLine($"Linear Sequence without Duplicates :");

            var result = "6,1-3,2-4"
            .Split(',')
            .Select(r => r.Split('-'))
            .Select(r => new { start = Int32.Parse(r[0]), last = Int32.Parse(r.Last()) })
            .SelectMany(r => Enumerable.Range(r.start, r.last - r.start + 1))
            .OrderBy(a => a)
            .Distinct()
            .Select(r => r.ToString())
            .Join("`")            ;

            Console.WriteLine(result);
            
            
        }

        private static void LinqChallengeAlbumDuration()
        {
            var Duration = "2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24"
                .Split(',')
                .Select(r => TimeSpan.Parse("0:" + r))
                //.Aggregate((r1, r2) => r1 + r2)
                .Sum();
                

            Console.WriteLine($"Duration of the Album : {Duration}");
            

        }
        
        private static void LinqChallengeAvgScore()
        {
            var avgScore = "10,5,0,8,10,1,4,0,10,1"
                 .Split(',')
                 .Select(e => Int32.Parse(e))
                 .OrderBy(e => e)
                 .Skip(3)
                 .ToList();

            avgScore.ForEach(e => { Console.WriteLine(e); });
            Console.WriteLine($"Average Score : {avgScore.Average(e => e)} ");
        }
    }
}
