using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.MSTest_Structure
{
    [TestClass]
    public class ClassGeneric
    {
        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("Before Test");
        }
        [TestCleanup]
        public void AfterTest()
        {
            Console.WriteLine("After Test");
        }
    }
}
