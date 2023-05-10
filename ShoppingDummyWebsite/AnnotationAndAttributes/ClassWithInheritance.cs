using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.AnnotationAndAttributes
{
   // [TestClass]
    public class ClassWithInheritance : ClassGeneric
    {
       // [TestMethod]
        public void Example1()
        {
            Console.WriteLine(" Example1 Test Method of ClassWithInheritance class is Inheriting from ClassGeneric class");
        }
       // [TestMethod]
        public void Example2()
        {
            Console.WriteLine(" Example2 Test Method of ClassWithInheritance class is Inheriting from ClassGeneric class");
        }
      //  [TestMethod]
        public void Example3()
        {
            Console.WriteLine("Example3  Test Method of ClassWithInheritance class is Inheriting from ClassGeneric class");
        }
    }
}
