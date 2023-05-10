using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.MSTest_Structure
{
    [TestClass]
    public class BaseClass
    {
        [AssemblyInitialize]
       public static void BeforeProject(TestContext context)
        {
            Console.WriteLine("Before Project");
        }
        [AssemblyCleanup]
        public static void AfterProject()
        {
            Console.WriteLine("After Project");
        }
    }
}
