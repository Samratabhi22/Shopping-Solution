using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerWebApplicationMSTestUnit.DataDrivenUtility
{
    public class Extentreportsclass
    {
        public static String path = "C:\\Users\\Hp\\source\\repos\\ECommerceProject\\Shopping Solution\\VtigerWebApplicationMSTestUnit\\DataDrivenUtility\\reports\\";

        public static ExtentReports extentReports = new ExtentReports();
        public ExtentTest extentTest = extentReports.CreateTest("cname");
        // public ExtentTest extentTest = extentReports.CreateTest(MethodBase.GetCurrentMethod().Name);
        public ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
        public void extentreportmethod(IWebDriver driver)
        {
            if (extentTest.Status == Status.Fail)
            {

                ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
                var screenShot = takesScreenshot.GetScreenshot();
                string screenShotPath = "C:\\Users\\Hp\\source\\repos\\ECommerceProject\\Shopping Solution\\VtigerWebApplicationMSTestUnit\\DataDrivenUtility\\Snapshots\\defect.png";
                screenShot.SaveAsFile(screenShotPath, ScreenshotImageFormat.Png);
                extentTest.Log(Status.Info, "Taken screenshot");
                bool condition = false;
                if (condition == true)
                {
                    Assert.IsTrue(true);
                    extentTest.Pass("Test Passed");
                }
                else
                {
                    try
                    {
                        Assert.IsTrue(false);

                    }
                    catch (Exception ex)
                    {
                        extentTest.Fail("Test failed");

                    }
                }
                extentTest.AddScreenCaptureFromPath(screenShotPath);
            }
            else if (extentTest.Status == Status.Pass)
            {
                extentTest.Pass("passed");
            }
            else if (extentTest.Status == Status.Skip)
            {
                extentTest.Log(Status.Info, "skipped");
            }
        }
    }
}
