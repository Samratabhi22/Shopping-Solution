using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.VtigerApplication.VtigerEndToEnd
{
    [TestClass]
    public class VtigerTestsEndtoEnd
    {
       


    
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            // Set up the driver before each test
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void Login_ValidCredentials_SuccessfulLogin()
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

            var dashboardTitle = driver.FindElement(By.XPath("//title"));
            Assert.AreEqual("Administrator - Home - vtiger CRM 5 - Commercial Open Source CRM", dashboardTitle.Text);
        }

        [TestMethod]
        public void CreateContact_ValidData_ContactCreated()
        {
            // Login to Vtiger CRM
            Login_ValidCredentials_SuccessfulLogin();

            // Navigate to the Contacts module
            driver.Navigate().GoToUrl("https://your-vtiger-app.com/index.php?module=Contacts&action=index&parenttab=Marketing");

            // Find the "Create" button and click it
            var createButton = driver.FindElement(By.CssSelector(".quickCreateLink"));
            createButton.Click();

            // Fill in the contact details
            var firstNameInput = driver.FindElement(By.Name("firstname"));
            firstNameInput.SendKeys("John");

            var lastNameInput = driver.FindElement(By.Name("lastname"));
            lastNameInput.SendKeys("Doe");

            var emailInput = driver.FindElement(By.Name("email"));
            emailInput.SendKeys("john.doe@example.com");

            // Save the contact
            var saveButton = driver.FindElement(By.CssSelector(".crmbutton.small.save"));
            saveButton.Click();

            // Wait for the contact detail page to load
            var contactDetailTitle = driver.FindElement(By.CssSelector(".pageTitle"));
            Assert.AreEqual("Contact Details", contactDetailTitle.Text);

            // Assert that the contact was created successfully
            var contactName = driver.FindElement(By.CssSelector(".moduleTitle"));
            Assert.AreEqual("John Doe", contactName.Text);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up the driver after each test
            driver.Quit();
        }
    }

}

