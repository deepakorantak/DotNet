using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQMiscellaneous
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqChallengeRange();

            LinqChallengeAlbumDuration();

            LinqChallengeAvgScore();
         

        }

        private static void LinqChallengeRange()
        {
            var linearSequence = "2,5,7-10,11,17-18"
                                 .Split(',')
                                 .Select(r => r.Split('-'))
                                 .Select(r => new { start = Int32.Parse(r[0]), last = Int32.Parse(r.Last()) })
                                 .SelectMany(r => Enumerable.Range(r.start, r.last - r.start + 1))
                                 .ToList();

            Console.WriteLine($"Linear Sequence :");
            linearSequence.ForEach(r => Console.WriteLine(r) );

            var linearWODuplicates = "6,1-3,2-4"
                     .Split(',')
                     .Select(r => r.Split('-'))
                     .Select(r => new { start = Int32.Parse(r[0]), last = Int32.Parse(r.Last()) })
                     .SelectMany(r => Enumerable.Range(r.start, r.last - r.start + 1))
                     .OrderBy(a => a)
                     .Distinct()
                     .ToList();                     

            Console.WriteLine($"Linear Sequence without Duplicates :");
            linearWODuplicates.ForEach(r => Console.WriteLine(r));




        }

        private static void LinqChallengeAlbumDuration()
        {
            var Duration = "2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24"
                .Split(',')
                .Select(r => TimeSpan.Parse("0:" + r))
                .Aggregate((r1, r2) => r1 + r2);
                ;

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
