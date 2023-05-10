using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtigerWebApplicationMSTestUnit.POM_Pages;

namespace VtigerWebApplicationMSTestUnit.TestScripts
{
    [TestClass]
    public  class VtigerAppEndToEndTest
    {

        public static IWebDriver driver;

        [ClassInitialize]
        public static  void Setup(TestContext context)
        {
            // Set up the driver before each test
            driver = new ChromeDriver();
        }
        [TestInitialize]
        public void wait()

        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        }
        [TestMethod]
        public void Login_ValidCredentials_SuccessfulLogin()
        {
            // Navigate to the login page
            driver.Navigate().GoToUrl("http://localhost:8888/");

            // Find the username and password input fields and enter valid credentials
            //var usernameInput = driver.FindElement(By.Name("user_name"));
            //usernameInput.SendKeys("admin");

            //var passwordInput = driver.FindElement(By.Name("user_password"));
            //passwordInput.SendKeys("admin");

            // Find the login button and click it
            //var loginButton = driver.FindElement(By.Id("submitButton"));
            //loginButton.Click();

            LoginPage login = new LoginPage(driver);
            login.Valid_Login("admin", "admin");
           
            // Wait for the dashboard page to load
            String dashboardTitle = driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Text;
         
           Assert.AreEqual("Home", dashboardTitle);
            
        }
        [TestMethod]
        public void CreateContact_ValidData_ContactCreated()
        {
            // Login to Vtiger CRM
            //  Login_ValidCredentials_SuccessfulLogin();



            // Navigate to the login page
            
            //driver.Navigate().GoToUrl("http://localhost:8888/");
            // Login to Vtiger CRM
           //  Login_ValidCredentials_SuccessfulLogin();


            // Find the "Create" button and click it
           
            //IWebElement createButton = driver.FindElement(By.XPath("//a[text()='Contacts']"));
            //createButton.Click();

            // Navigate to the Contacts module
            //IWebElement plusicon = driver.FindElement(By.XPath("//img[contains(@title,'Create Contact')]"));
            //plusicon.Click();
            // Fill in the contact details
            //var firstNameInput = driver.FindElement(By.Name("firstname"));
            //firstNameInput.SendKeys("John");

            //var lastNameInput = driver.FindElement(By.Name("lastname"));
            //lastNameInput.SendKeys("Doe");

            //var emailInput = driver.FindElement(By.Name("email"));
            //emailInput.SendKeys("john.doe@example.com");

            //// Save the contact
            //var saveButton = driver.FindElement(By.CssSelector(".crmbutton.small.save"));
            //saveButton.Click();

            ContactPage contact = new ContactPage(driver);
            contact.Create_Contact("John", "Doe", "john.doe@example.com");

            // Wait for the contact detail page to load
           
            String contactDetailTitle = driver.FindElement(By.XPath(" //span[contains(text(),'Contact Information')]")).Text;
            StringAssert.Contains(contactDetailTitle,"Contact Information" );

            // Assert that the contact was created successfully
            String contactName = driver.FindElement(By.XPath("//span[@class='dvHeaderText']")).Text;
            StringAssert.Contains(contactName,"Doe John") ;
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            // Clean up the driver after each test
            driver.Quit();
        }


    }

    }

