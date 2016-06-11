using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment
{
    class Student
    {
        List<string> name;
        List<int> age;
        List<float> grade;

        public Student()
        {
            name = new List<string>();
            age = new List<int>();
            grade = new List<float>();

        }

        public void AddStudent(string iName, int iage, float igrade)
        {
            name.Add(iName);
            age.Add(iage);
            grade.Add(igrade);

        }

        public StudentStatistics ComputeStatistics()
        {
            StudentStatistics  stats = new StudentStatistics();
            float sumAge = 0,sumGrade = 0;

            foreach (int ag in age)
            {
                sumAge += ag;
            }

            stats.MaxGrade = StudentStatistics.MinFloatValue;
            stats.MinGrade = StudentStatistics.MaxFloatValue;

            foreach (float gr in grade)
            {
                sumGrade += gr;
                stats.MaxGrade = Math.Max(gr, stats.MaxGrade);
                stats.MinGrade = Math.Min(gr, stats.MinGrade);
            }

            stats.AverageAge = sumAge / age.Count;
            stats.AverageGrade = sumGrade / grade.Count;
            

            return stats;

        }

    }
}
