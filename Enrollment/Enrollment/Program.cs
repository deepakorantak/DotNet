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
            stud.AddStudent("Anna", 20, 7.5f);
            stud.AddStudent("John",21,8);
            stud.AddStudent("Julie", 30, 6.5f);
            stud.AddStudent("Mark", 34, 9);

            stud.ComputeStatistics();
            stud.PrintStudentInfo();                                

        }
    }
}
