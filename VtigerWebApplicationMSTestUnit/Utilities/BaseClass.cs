using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string screenShotPath = "C:\\Users\\Hp\\source\\repos\\ECommerceProject\\Shopping Solution\\VtigerWebApplicationMSTestUnit\\Utilities\\ScreenShots\\ss.png";

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void SetupReporting(TestContext context)
        {
            // Initialize ExtentReports and attach the HTML reporter
            htmlReporter = new ExtentHtmlReporter("C:\\Users\\Hp\\source\\repos\\ECommerceProject\\Shopping Solution\\VtigerWebApplicationMSTestUnit\\Utilities\\Report\\");
            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);


            extent.AddSystemInfo("HostName", "localhost");
            extent.AddSystemInfo("Environment", "TestingEnvironment");
            extent.AddSystemInfo("QA Name", "Abhishek Kumar");

            //here we gave all the information how to generate the Report--->PArt 1
        }

        [TestInitialize]
        public void initialize()
        {
            //CREATE REPORT ----> PArt2

            //report ---->  Report Results to ExtentReports
            //create entry for your report(this is the test coming from your report)
            //then finally you can say it is pass or fail
            //I am writing this in [TestInitialize] so that before executing every test this [TestInitialize] method will execute
            // var test=extent.CreateTest(TestContext.CurrentContext.Test.Name);
            var test= extent.CreateTest(TestContext.TestName);

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
            //Generate the final report according to Pass or Fail ----> PArt 3
          //  test.Log(test.Status);
            var res = TestContext.CurrentTestOutcome;
            if (res.Equals(Status.Fail))
            {
                test.Fail("Test Failed");
               
                utility.TakeScreenShot(driver, TestContext.TestName);
                test.AddScreenCaptureFromPath(screenShotPath, "Failed");
                test.Log(Status.Info, "--->Test Failed");
                Console.WriteLine("Test Failed");

            }
            else if(res.Equals(Status.Pass))
            {

                 // test.Pass("Test Passed");
                  test.Log(Status.Pass, "--->Test Passed");
                   test.Log(test.Status);
                   Console.WriteLine(test.Status);
                   Console.WriteLine("Test Passed");

            }
            driver.Quit();
           // driver.Dispose();

            

        }


        [AssemblyCleanup]
        public static void GenerateReport()
        {
            // Flush the ExtentReports instance to write the report to the output file

            extent.Flush();
            htmlReporter.Stop();
        }
    }
}
