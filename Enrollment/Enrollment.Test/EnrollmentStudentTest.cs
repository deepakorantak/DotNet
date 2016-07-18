using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.Test
{
    [TestClass]
    public class EnrollmentStudentTest
    {
        [TestMethod]
        public void TestStudentHighestGrade()
        {
            Student stud1 = new Student();
            stud1.AddStudent("Sita", 18, 8.5f);
            stud1.AddStudent("Gita", 19, 10);

            stud1.ComputeStatistics();

            Assert.AreEqual(stud1.studentstats.AverageGrade, 9,0.5);
            Assert.AreEqual(stud1.studentstats.AverageAge, 18.5f);

        }
        [TestMethod]
        public void TestReferenceTypes()
        {
            Student s1 = new Student();
            Student s2 = s1;

            s1.name.Add("Deepa");

            Assert.AreEqual(s1.name, s2.name);

            s1 = new Student();

            s1.name.Add("Gauri");
            Assert.AreNotEqual(s1.name, s2.name);
            
        }

        
        [TestMethod]
        public void TestPassReferenceTypes()
        {
            Student s1 = new Student();
            Student s2 = s1;
            AssignName(s1);

            Assert.AreEqual(s1.name, s2.name);

            s2 = new Student();
            Assert.AreNotEqual(s1.name, s2.name);
                    }

        public void AssignName(Student x)
        {
            x.name.Add("Name changed");
        }

            }
}
