using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank30DayChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            ThirtyDayChallengeDay4();
        }

        private static void ThirtyDayChallengeDay4()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int result, remainder;
            string resultlog = "";
            result = Math.DivRem(N, 2, out remainder);

            if (N >= 1 && N <= 100)
            {
                if (remainder != 0)
                {
                    resultlog = "Weird";
                }
                else
                {

                    if (N >= 2 && N <= 5)
                    {
                        resultlog = "Not Weird";
                    }

                    if (N >= 6 && N <= 20)
                    {
                        resultlog = "Weird";
                    }

                    if (N > 20)
                    {
                        resultlog = "Not Weird";
                    }
                }

                Console.WriteLine(resultlog);
            }
        }
    }
}
