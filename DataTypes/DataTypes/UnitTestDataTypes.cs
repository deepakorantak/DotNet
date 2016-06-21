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
        public void TestStringType()
        {
            string text = "test1";
            text.ToUpper();

            Assert.AreEqual("TEST1", text);

        }
        
    }
}
