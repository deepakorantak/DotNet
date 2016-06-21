using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTypes
{
    [TestClass]
    public class UnitTestDataTypes
    {
        [TestMethod]
        public void TestValueTypes()
        {
            int x1 = 2;
            int x2 = x1;
            Assert.AreEqual(x1, x2);

            x1 = 5;

            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void TestPassValueTypes()
        {
            int x1 = 4;
            int x2 = x1;

            AssignValue(x1);
            Assert.AreEqual(x1, x2);
        }

        [TestMethod]
        public void TestPassValueRefTypes()
        {
            int x1 ;
            int x2 = 4; //= x1
                
            AssignRefValue(out x1);
            Assert.AreNotEqual(x1, x2);
        }
        //assigning
        public void AssignValue(int x)
        {
            x = 10;
        }


        [TestMethod]
        public void AssignRefValue(out int x)
        {
            x = 1;
            x = x + 1;
        }

        [TestMethod]
        public void TestStringTypeMutable()
        {
            string text = "test1";
            text = text.ToUpper();

            Assert.AreEqual("TEST1", text);

        }


        [TestMethod]
        public void TestIntTypeMutable()
        {
            int val = 4;
            string valText = val.ToString();

            Assert.AreEqual("4".GetType(),valText.GetType());
            Assert.AreEqual("4", valText);

        }

        [TestMethod]
        public void TestDataTypeMutable()
        {
            DateTime curDate = new DateTime(1995,12,2);
            curDate = curDate.AddYears(1);

            Assert.AreEqual(1996,curDate.Year);

        }



    }
}
