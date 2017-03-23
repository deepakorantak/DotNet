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
            //ThirtyDayChallengeDay4();
            //ThirtyDayChallengeDay6();
            ThirtyDayChallengeDay7();
        }

        private static void ThirtyDayChallengeDay7()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n >= 1 && n <= 1000)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
                var notvalid = arr.Any(a => (a < 1 || a > 10000));
                if (!notvalid)
                {
                    var output = arr.Reverse()
                       .Select(a => a.ToString())
                       .Aggregate((a, c) => a + " " + c)
                       .TrimEnd()
                       ;

                    Console.WriteLine(output);
                }
            }
        }

        private static void ThirtyDayChallengeDay6()
        {
            int n = Int32.Parse(Console.ReadLine());
            if (n >= 1 && n <= 10)
            {

                string S = "";

                for (int i = 1; i <= n; i++)
                {
                    S = Console.ReadLine();
                    if (S.Length >= 1 && S.Length <= 10000)
                    {

                        string evenS = "", oddS = "";
                        for (int j = 0; j < S.Length; j++)
                        {

                            int remainder;
                        int result  = Math.DivRem(j, 2, out remainder);
                            if (remainder == 0)
                            {

                                evenS += S[j];

                            }
                            else
                            {
                                oddS+= S[j];
                            }

                        }

                        Console.WriteLine($"{evenS} {oddS}");
                   

                    }
                }
            }
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
