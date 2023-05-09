using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
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
    public class ExtentReportTests
    {
       


        private IWebDriver driver;
        private ExtentReports extent;
        private ExtentTest test;

        [TestInitialize]
        public void Setup()
        {
            // Set up the driver before each test
            driver = new ChromeDriver();

            // Set up ExtentReports
            var htmlReporter = new ExtentHtmlReporter("TestReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [TestMethod]
        public void Login_ValidCredentials_SuccessfulLogin()
        {
            // Start ExtentTest
            test = extent.CreateTest("Login_ValidCredentials_SuccessfulLogin", "Verify successful login");

            try
            {
                // Navigate to the login page
                driver.Navigate().GoToUrl("https://your-website.com/login");

                // Find the username and password input fields and enter valid credentials
                var usernameInput = driver.FindElement(By.Id("username"));
                usernameInput.SendKeys("your-username");

                var passwordInput = driver.FindElement(By.Id("password"));
                passwordInput.SendKeys("your-password");

                // Find the login button and click it
                var loginButton = driver.FindElement(By.Id("login-button"));
                loginButton.Click();

                // Wait for the dashboard page to load
                var dashboardTitle = driver.FindElement(By.CssSelector(".dashboard-title"));
                Assert.AreEqual("Dashboard", dashboardTitle.Text);

                // Log the test as passed in ExtentReports
                test.Pass("Login successful");
            }
            catch (Exception ex)
            {
                // Capture screenshot and log the test as failed in ExtentReports
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var screenshotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots", "LoginFailed.png");
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

                test.Fail("Login failed",
                    MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
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

