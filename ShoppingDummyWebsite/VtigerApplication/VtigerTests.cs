using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.VtigerApplication
{
    [TestClass]
    public class VtigerTests
    {
    
        private IWebDriver driver;
        private ExtentReports extent;
        private ExtentTest test;
        private ILogger logger;

        [TestInitialize]
        public void Setup()
        {
            // Set up the driver before each test
            driver = new ChromeDriver();

            // Set up ExtentReports
            var htmlReporter = new ExtentHtmlReporter("TestReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            //// Set up Serilog logger
            //logger = new LoggerConfiguration()
            //    .WriteTo.File("TestLog.log", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();
        }

        [TestMethod]
        public void Login_ValidCredentials_SuccessfulLogin()
        {
            // Start ExtentTest
            test = extent.CreateTest("Login_ValidCredentials_SuccessfulLogin", "Verify successful login");

            try
            {
                // Navigate to the login page
                driver.Navigate().GoToUrl("https://your-vtiger-app.com/index.php?action=Login&module=Users");

                // Find the username and password input fields and enter valid credentials
                var usernameInput = driver.FindElement(By.Name("username"));
                usernameInput.SendKeys("your-username");

                var passwordInput = driver.FindElement(By.Name("password"));
                passwordInput.SendKeys("your-password");

                // Find the login button and click it
                var loginButton = driver.FindElement(By.CssSelector(".crmbutton.small.save"));
                loginButton.Click();

                // Wait for the dashboard page to load
                var dashboardTitle = driver.FindElement(By.CssSelector(".pageTitle"));
                Assert.AreEqual("Dashboard", dashboardTitle.Text);

                // Log the test as passed in ExtentReports
                test.Pass("Login successful");

                // Log the test as passed in Serilog logger
               // logger.Information("Login_ValidCredentials_SuccessfulLogin - Login successful");
            }
            catch (Exception ex)
            {
                // Capture screenshot and log the test as failed in ExtentReports
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var screenshotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots", "LoginFailed.png");
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

                test.Fail("Login failed",
                    MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());

                // Log the exception in Serilog logger
                //logger.Error(ex, "Login_ValidCredentials_SuccessfulLogin - Login failed");
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up the driver after each test
            driver.Quit();

            // Flush and close ExtentReports
            extent.Flush();
           // extent.Close();
        }
    }

}

