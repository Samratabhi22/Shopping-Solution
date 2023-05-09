using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.AnnotationAndAttributes
{
    [TestClass]
    public class ClassWithAll
    {
        [ClassInitialize]
        public static void ClassIni(TestContext context)
        {
            Console.WriteLine("Class Initialized within class");
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("Class Cleaned with in class");
        }
        [TestMethod]
        public void TestMethod()
        {
            Console.WriteLine("Test Method One");
        }
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Test Method Two");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("Test Method Three");
        }

    }
}
