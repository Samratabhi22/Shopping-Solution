using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingSession
{
    [TestClass]
    public  class FibonacciSeries
    {
        static int p1 = 0, p2 = 1, p3;
        [TestMethod]
        public static void fibonacci()
        {
            Console.WriteLine("PLease provide input value");
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine(p1+" "+p2);
            for(int i=2;i<count;i++)
            {
                p3 = p1 + p2;
                Console.WriteLine(" "+p3);
                p1= p2;
                p2= p3;
            }

        }
    }
}
