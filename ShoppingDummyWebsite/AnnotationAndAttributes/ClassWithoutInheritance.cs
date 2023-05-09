using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.AnnotationAndAttributes
{
    public class ClassWithoutInheritance
    {
        [TestMethod]
        public void Sample1()
        {
            Console.WriteLine(" Sample1 Test Method without Inheriting");
        }
        [TestMethod]
        public void Sample2()
        {
            Console.WriteLine(" Sample2 Test Method without Inheriting");
        }
        [TestMethod]
        public void Sample3()
        {
            Console.WriteLine(" Sample3 Test Method without Inheriting");
        }
    }
}
