using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.AnnotationAndAttributes
{
    [TestClass]
    public class ClassGeneric
    {


        [TestInitialize]
        public void TestIni()
        {
            Console.WriteLine("Test Initialized");
        }
        [TestCleanup]
        public void TestClean()
        {
            Console.WriteLine("Test Cleaned");
        }


    }  
}

