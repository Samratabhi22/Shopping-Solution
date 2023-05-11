using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VtigerWebApplicationMSTestUnit.Utilities
{
    [TestClass]
    public class BaseClass
    {
        public static IWebDriver driver;
        public WebdriverUtility utility;
        public ExcelUtility exUtil;
        public static ExtentReports extent;//understood
        public ExtentTest test;

        public static ExtentHtmlReporter htmlReporter;//understood
        public static string reportPath = "C:\\Users\\Hp\\source\\repos\\ECommerceProject\\Shopping Solution\\VtigerWebApplicationMSTestUnit\\Utilities\\Report\\";
        public static string screenShotPath;

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void SetupReporting(TestContext context)
        {
            // Initialize ExtentReports and attach the HTML reporter
            extent = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter("reportPath");
            htmlReporter.Start();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("HostName", "localhost");
            extent.AddSystemInfo("Environment", "TestingEnvironment");
            extent.AddSystemInfo("QA Name", "Abhishek Kumar");

            //here we gave all the information how to generate the Report--->PArt 1
        }

        [TestInitialize]
        public void initialize()
        {
            test=extent.CreateTest(TestContext.TestName);

            driver = new ChromeDriver();
            exUtil = new ExcelUtility();
            driver.Navigate().GoToUrl("http://localhost:8888/");
             utility = new WebdriverUtility();
            utility.MaximizeWindow(driver);
           utility.ImplicitlyWaitingForSeconds(driver,8);

        }

        [TestCleanup]
        public void Cleanup()
        {
            
            if (test.Status.Equals(Status.Fail))
            {
                 WebdriverUtility.TakeScreenShot(driver);
                Console.Write(screenShotPath);
                test.AddScreenCaptureFromPath(screenShotPath);
            }
            driver.Quit();
           driver.Dispose();
        }
        [AssemblyCleanup]
        public static void GenerateReport()
        {
            extent.Flush();
            htmlReporter.Stop();
        }
    }
}
