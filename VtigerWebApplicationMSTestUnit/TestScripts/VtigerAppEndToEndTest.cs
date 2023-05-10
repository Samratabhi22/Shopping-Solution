using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtigerWebApplicationMSTestUnit.POM_Pages;
using VtigerWebApplicationMSTestUnit.Utilities;

namespace VtigerWebApplicationMSTestUnit.TestScripts
{
    [TestClass]
    public  class VtigerAppEndToEndTest
    {

        public static IWebDriver driver;
        public WebdriverUtility utility;

       [ClassInitialize]
        public static  void Setup(TestContext context)
        {
            // Set up the driver before each test
            driver = new ChromeDriver();
        }
        [TestInitialize]
        public void wait()

        {
            utility = new WebdriverUtility();
            utility.MaximizeWindow(driver);
           
            utility.ImplicitlyWaitingForSeconds(driver, 8);
            
        }
        [TestMethod]
        public void Login_ValidCredentials_SuccessfulLogin()
        {
            // Navigate to the login page
            driver.Navigate().GoToUrl("http://localhost:8888/");
            
            LoginPage login = new LoginPage(driver);
            login.Valid_Login("admin", "admin");
           
            // Wait for the dashboard page to load
            String dashboardTitle = driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Text;
         
           Assert.AreEqual("Home", dashboardTitle);
            
        }
        [TestMethod]
        
        public void CreateContact_ValidData_ContactCreated()
        {
            

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

