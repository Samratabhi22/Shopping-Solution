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
            Console.WriteLine("Class Initialized within classWithAll");
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("Class Cleaned within classWithAll");
        }
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Test Method One within same class i.e classWithAll");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("Test Method Two within same class i.e classWithAll");
        }
        [TestMethod]
        public void TestMethod3()
        {
            Console.WriteLine("Test Method Three within same class i.e classWithAll");
        }

    }
}
