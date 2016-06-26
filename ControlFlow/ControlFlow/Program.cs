using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow
{
    class Program
    {
        static List<int> rainfall;
        static float avgRainfall = 0;
        static string gradeRainfall;
        static string gradeGradeNameRainFall;
        static Exception floatDivisorZero = new Exception("Dividing a Float By Zero");


        static void Main(string[] args)
        {

            PopulateList();
            try
            {
                AverageRainFall();
            }
            catch (floatDivisorZero ex)
            {
                Console.WriteLine("Exception Caught : " + ex.Message);
                //throw;
            }

            CalcRainFallGrade();
            PrintRainFall();

            Console.WriteLine($"Average Rain Fall : {avgRainfall} , Grade : {gradeGradeNameRainFall} Rain Fall");

        }

        static void PopulateList()
        {
            rainfall = new List<int>();
            rainfall.Add(100);
            rainfall.Add(112);
            rainfall.Add(130);
            rainfall.Add(120);
            rainfall.Add(90);
            rainfall.Add(80);
        }

        static void AverageRainFall()
        {

            for (int i = 0; i < rainfall.Count; i++)
            {
                avgRainfall += rainfall[i];
            }

            if (rainfall.Count == 0)
            {
                throw floatDivisorZero;
            }
            avgRainfall = avgRainfall / rainfall.Count;
        }

        static void CalcRainFallGrade()
        {
            if (avgRainfall >= 100)
            {
                gradeRainfall = "A";
            }
            else if (avgRainfall >= 90)
            {
                gradeRainfall = "B";
            }
            else if (avgRainfall >= 75)
            {
                gradeRainfall = "C";
            }
            else if (avgRainfall >= 60 && avgRainfall != 0)
            {
                gradeRainfall = "D";
            }
            else
            {
                gradeRainfall = "E";
            }


            switch (gradeRainfall)
            {
                case "A":
                    gradeGradeNameRainFall = "Excellent";
                    break;
                case "B":
                    gradeGradeNameRainFall = "Good";
                    break;
                case "C":
                    gradeGradeNameRainFall = "Average";
                    break;
                case "D":
                    gradeGradeNameRainFall = "Below Average";
                    break;
                default:
                    gradeGradeNameRainFall = "Error";
                    break;
            }

        }

        static void PrintRainFall()
        {
            bool endoflist = rainfall.Count > 0 ? true : false;

            int i = 0;

            while (endoflist)
            {
                Console.WriteLine(rainfall[i]);
                i++;

                endoflist = i == rainfall.Count ? false : true;

            }
        }

    }
}

