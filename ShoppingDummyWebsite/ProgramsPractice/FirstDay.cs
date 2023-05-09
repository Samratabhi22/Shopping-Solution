using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.ProgramsPractice
{
    [TestClass]
    public class FirstDay
    {
        [TestMethod, TestCategory("Prime")]
        public void Test()
        {
            int n = 5, count = 0;
            for (int i = 2; i < n / 2; i++)
            {
                if (i % 2 == 0)
                {
                    count++;
                }

            }
            if (count == 0)
            {
                Console.WriteLine("Given number is prime");
            }
            else
            {
                Console.WriteLine("Given number is not prime");
            }
        }
        [TestMethod, TestCategory("Factorial")]
        public void Test2()
        {

            int n = 5;
            Console.Write("0," + "1," + "1");
            for (int i = 3; i < n; i++)
            {
                int n1 = 1, n2 = 1, n3;
                n3 = n1 + n2;
                n1 = n2;
                n2 = n3;
                Console.Write(n3 + ",");
            }
        }
        [TestMethod, TestCategory("Reverse the String")]
        public void Test3()
        {
            string name = "lakshmi";
            Console.WriteLine("Given string is: " + name);
            for (int i = name.Length - 1; i > 0; i--)
            {
                Console.Write(name.Substring(i));
            }

        }
        [TestMethod, TestCategory("Pattern")]
        /*  *
            * *
            * * *
            * * * *
            * * * * *
         */
        public void Test4()
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
        [TestMethod, TestCategory("StringFindCharacter")]
        public void Test5()
        {
            char c = 'a'; int count = 0;
            string name = "lakshmi";
            for (int i = 0; i < name.Length; i++)
            {
                if (name.Substring(i).Equals(c))
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Not Present");
            }
            else if (count == 1)
            {
                Console.WriteLine("Present in one time");
            }
            else
            {
                Console.WriteLine("Present More than once");
            }
        }
    }
}
