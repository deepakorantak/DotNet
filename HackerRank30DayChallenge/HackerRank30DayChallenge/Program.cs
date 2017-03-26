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
            //ThirtyDayChallengeDay7();
            //ThirtyDayChallengeDay8();
            //ThirtyDayChallengeDay9();
            ThirtyDayChallengeDay10();
        }

        private static void ThirtyDayChallengeDay10()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var res = Convert.ToString(n, 2).SelectMany(a=>a.ToString()).ToArray();
            int cnt = res.Count();
            int i = 0,j = 0;
            int consOnes = 0,preConsOnes = 0;
            

           while(i < cnt)
            {
                if (res[i] == '1'  )
                {
                    if (i == 0  )
                    {
                        consOnes++;
                    }
                    else if(res[j]=='1') 
                    {
                        consOnes++;
                    }
                    else
                    {
                        consOnes = 1;

                    }
                }
                else
                {
                    preConsOnes = consOnes > preConsOnes ? consOnes : preConsOnes;
                    consOnes = 0;
                }
                j = i;
                i++;

            }

            consOnes = (preConsOnes > consOnes) ? preConsOnes : consOnes;

            Console.WriteLine(consOnes);
        }

        private static void ThirtyDayChallengeDay9()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n>= 2 && n<=12)
            {

               var res =  factorial(n);
                Console.WriteLine(res);              
            }
            
        }

        private static int factorial(int n)
        {
            do
            {

                if (n == 1)
                {
                    return 1;
                }
                else
                {
                    return n * factorial(--n);
                }

            }while(n > 0);
        }

        private static void ThirtyDayChallengeDay8()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n>=1 && n<= Math.Pow(10,5))
            {
                Dictionary<string, int> phonebook = new Dictionary<string, int>();
                
                string name = "";
                int phonenumber = 0;
                string output = "";

                for (int i = 1; i <= n; i++)
                {
                    var input = Console.ReadLine().Split(' ');
                    name = input[0].ToLower();
                    phonenumber = Convert.ToInt32(input[1]);
                    phonebook.Add(name, phonenumber);
                }

                var query = true;
                List<string> queryNames = new List<string>();
                string queryName = "";
                int cnt = 0;

                do
                {
                    queryName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(queryName) && cnt <= Math.Pow(10, 5))
                    {
                        queryNames.Add(queryName);
                        ++cnt;

                    }
                    else
                    {
                        query = false;

                    }

                } while (query);

               

                foreach (var item in queryNames)
                {

                    if (phonebook.ContainsKey(item))
                    {
                        Console.WriteLine($"{item}={ phonebook[item]}");
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }
                }

                Console.ReadLine();

            }
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
