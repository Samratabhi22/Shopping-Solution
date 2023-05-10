using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.MSTest_Structure
{
    [TestClass]
    public class TestScriptWithInheritance:ClassGeneric
    {
        [TestMethod]
        public void TestMethodOne()
        {
            Console.WriteLine("TestMethod 1");
        }
    }
}
