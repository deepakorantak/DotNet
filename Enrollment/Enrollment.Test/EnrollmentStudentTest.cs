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
    }
}
