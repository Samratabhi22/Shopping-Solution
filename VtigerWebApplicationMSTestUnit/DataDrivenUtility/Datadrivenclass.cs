using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace VtigerWebApplicationMSTestUnit.DataDrivenUtility
{
    [TestClass]
    public class Datadrivenclass
    {
        [DataTestMethod]
        [DataRow("Abhishek", 1)]
        [DataRow("Panthal", 2)]
        [DataRow("Rajeev", 3)]
        [DataRow("Lakshmi", 4)]
        [DataRow("Varun Sir", 5)]
        [TestCategory("DataDriven")]
        [TestMethod]
        public void DataDriven1(String a, int b)
        {
            Console.WriteLine(a + " " + b);
           // MessageBox.Show(a + " " + b);

        }
    }
}
