using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VtigerWebApplicationMSTestUnit.DataDrivenUtility
{
    [TestClass]
    public class Datadriven2withURL
    {
        public static IWebDriver driver;
        public Extentreportsclass ec = new Extentreportsclass();
        [TestInitialize]
        public void BMsetups()
        {

            driver = new ChromeDriver();
            ec.extentTest = Extentreportsclass.extentReports.CreateTest("Ccare");
            driver.Manage().Window.Maximize();

        }

        [TestMethod]
        [TestCategory("validateURL")]
        [DataTestMethod]
        [DataRow("https://meet.google.com/", "Google Meet")]
        [DataRow("https://meet.google.com/", "Google  eMeet")]
        [DataRow("https://www.facebook.com/login/", "Log in to Facebook")]
        [DataRow("https://opensource.zalando.com/zalenium/", "Zalenium - A flexible and scalable Selenium Grid.")]
        public void DatadrivenTest(String url, String exptitle)
        {
            string mname = MethodBase.GetCurrentMethod().Name;
            driver.Url = url;
            ec.extentTest.Info(url + "   " + exptitle);
            string acttitle = driver.Title;
            Console.WriteLine(acttitle);
            try
            {
                Assert.Equals(exptitle, acttitle);
                Console.WriteLine("title matched");

            }
            catch (Exception e)
            {
                try
                {
                    Assert.IsTrue(exptitle.Contains(acttitle));

                    Console.WriteLine("title contains actual title");

                    ec.extentTest.Info("title contains actual title");

                }
                catch
                {
                    Console.WriteLine("title not match");

                    ec.extentTest.Log(Status.Info, "title not match");
                    ec.extentTest.Fail("Test failed");
                    Console.WriteLine(e.StackTrace);
                }

            }
            ec.extentreportmethod(driver);
        }


        [TestCleanup]
        public void AMsetups()
        {

            driver.Quit();
            driver.Dispose();
        }
    }
}
