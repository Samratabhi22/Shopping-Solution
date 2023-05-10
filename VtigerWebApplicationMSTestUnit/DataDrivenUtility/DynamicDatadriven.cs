using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerWebApplicationMSTestUnit.DataDrivenUtility
{
    [TestClass]
    public class DynamicDatadriven
    {
        public static IEnumerable<Object[]> data
        {
            get
            {
                return new[]
                {
                    new Object[] { 1, 2 },
                    new Object[] { 2, 3 },
                    new Object[] { 3, 4 },
                    new Object[] { 4, 5 },
                };
            }
        }
        [TestMethod]
        [TestCategory("DynamicDataDriven")]
        [DynamicData(nameof(data), DynamicDataSourceType.Property)]
        public void TestMethod3(int a, int b)
        {
            Console.WriteLine(a + " " + b);
           // MessageBox.Show(a + " " + b);

        }
    }
}
