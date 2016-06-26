using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlow
{
    class Program
    {
        static List<int> rainfall ;
        static float avgRainfall = 0;
        static string gradeRainfall;
        static string gradeGradeNameRainFall;

        
        static void Main(string[] args)
        {
            PopulateList();
            AverageRainFall();
            CalcRainFallGrade();

            Console.WriteLine($"Average Rain Fall : {avgRainfall} , Grade : {gradeGradeNameRainFall} Rain Fall");                   
           
        }

        static void PopulateList()
        {
            rainfall = new List<int>();
           /* rainfall.Add(100);
            rainfall.Add(112);
            rainfall.Add(130);
            rainfall.Add(120);
            rainfall.Add(90);
            rainfall.Add(80);*/
        }

        static void AverageRainFall()
        {
            
            for (int i = 0; i < rainfall.Count; i++)
            {
                avgRainfall += rainfall[i];
            }

            try
            {
                avgRainfall = avgRainfall / rainfall.Count;
                
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Try Cath - Error DBZ : " + ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("Try Cath - Error : " + ex.Message);
            }
         
         }

        static void CalcRainFallGrade()
        {
            if (avgRainfall >= 100 )
            {
                gradeRainfall = "A";
            }
            else if (avgRainfall >= 90)
            {
                gradeRainfall = "B";
            }
            else if(avgRainfall >=75)
            {
                gradeRainfall = "C";
            }
            else if (avgRainfall >= 60 && avgRainfall != 0 )
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


    }
}
