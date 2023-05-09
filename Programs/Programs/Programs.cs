using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.Programs
{
    public  class Programs
    {//Remove duplicates in a Array
       // public static void Main(String[] args)

        {
            int[] a = { 1,2,3,1,2,5,6,7,4,7 };
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < a.Length; i++)
            {
                set.Add(a[i]);

            }
            foreach (int e in set)
            {
                Console.WriteLine(e + " ");
            }

        }
    }
}
