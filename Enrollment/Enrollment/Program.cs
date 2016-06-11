using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment
{
    class Program
    {
        static void Main(string[] args)
        {

            Student stud = new Student();
            StudentStatistics stats = new StudentStatistics();
            stud.AddStudent("Anna", 20, 7.5f);
            stud.AddStudent("John",21,8);
            stud.AddStudent("Julie", 30, 6.5f);
            stud.AddStudent("Mark", 34, 9);

            stats = stud.ComputeStatistics();

            Console.WriteLine("Max Grade : "+ stats.MaxGrade);
            Console.WriteLine("Min Grade : "+ stats.MinGrade);
            Console.WriteLine("Average Grade : "+ stats.AverageGrade);
            Console.WriteLine("Average Age : " + Math.Ceiling(stats.AverageAge));

            Console.WriteLine("Press any key to continue !!");
            Console.ReadLine();                       

        }
    }
}
