using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.AnnotationAndAttributes
{
  //  [TestClass]
    public class BaseClass
    {
      //  [AssemblyInitialize]
        public static void AssemblyIni(TestContext context)
        {
            Console.WriteLine("Assembly iniitialized");
        }
      //  [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Console.WriteLine("Assembly cleanedup");

        }
    }
}
