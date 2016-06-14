using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment
{
    public class Student
    {
        private List<string> name;
        private List<int> age;
        private List<float> grade;
        public StudentStatistics studentstats;

        public Student()
        {
            name = new List<string>();
            age = new List<int>();
            grade = new List<float>();
            studentstats = new StudentStatistics();
        }

        public void AddStudent(string iName, int iage, float igrade)
        {
            name.Add(iName);
            age.Add(iage);
            grade.Add(igrade);

        }

        public void ComputeStatistics()
        {
            float sumAge = 0,sumGrade = 0;
            studentstats.MaxGrade = StudentStatistics.MinFloatValue;
            studentstats.MinGrade = StudentStatistics.MaxFloatValue;

            for (int i = 0; i < age.Count; i++)
            {
                 sumAge += age[i];
                 sumGrade += grade[i];
                 studentstats.MaxGrade = Math.Max(grade[i], studentstats.MaxGrade);
                 studentstats.MinGrade = Math.Min(grade[i], studentstats.MinGrade);
            }
            
            studentstats.AverageAge = sumAge / age.Count;
            studentstats.AverageGrade = sumGrade / grade.Count;           

        }

        public void PrintStudentInfo()
        {

            for (int i = 0; i < name.Count; i++)
            {
                Console.WriteLine("Name : " + name[i] + " Age : " + age[i] + " Grade : "+ grade[i]);
            }
           
            Console.WriteLine("Max Grade : " + studentstats.MaxGrade);
            Console.WriteLine("Min Grade : " + studentstats.MinGrade);
            Console.WriteLine("Average Grade : " + studentstats.AverageGrade);
            Console.WriteLine("Average Age : " + Math.Ceiling(studentstats.AverageAge));

            Console.WriteLine("Press any key to continue !!");
            Console.ReadLine();
        }

    }
}
