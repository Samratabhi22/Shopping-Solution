using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
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
    public  class VtigerAppEndToEndTest : BaseClass
    {
        
        [TestMethod]
        public void Login_ValidCredentials_SuccessfulLogin()
        {
            
            LoginPage login = new LoginPage(driver);
            login.Valid_Login(exUtil.Get_value_by_pasing_key("Login", "username"), exUtil.Get_value_by_pasing_key("Login", "password"));
           
            // Wait for the dashboard page to load
            String dashboardTitle = driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Text;
         
           Assert.AreEqual("Home", dashboardTitle);
            ContactPage contact = new ContactPage(driver);
            contact.Create_Contact("Varun", "SN", "varun@gmail.com");
            // Wait for the contact detail page to load
            String contactDetailTitle = driver.FindElement(By.XPath(" //span[contains(text(),'Contact Information')]")).Text;
               StringAssert.Contains(contactDetailTitle,"Contact Information" );
            // Assert that the contact was created successfully
            String contactName = driver.FindElement(By.XPath("//span[@class='dvHeaderText']")).Text;
            StringAssert.Contains(contactName, "SN Varun");


        }
        [TestMethod]
        public void Login_ValidCredentials_SuccessLogin()
        {
            LoginPage login = new LoginPage(driver);
            login.Valid_Login(exUtil.Get_value_by_pasing_key("Login", "username"), exUtil.Get_value_by_pasing_key("Login", "password"));

            // Wait for the dashboard page to load
            String dashboardTitle = driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Text;

            Assert.AreEqual("Home", dashboardTitle);
            ContactPage contact = new ContactPage(driver);
            contact.Create_Contact("Varun", "SN", "varun@gmail.com");
            // Wait for the contact detail page to load
            String contactDetailTitle = driver.FindElement(By.XPath(" //span[contains(text(),'Contact Information')]")).Text;
            StringAssert.Contains(contactDetailTitle, "Contact Information");
            // Assert that the contact was created successfully
            String contactName = driver.FindElement(By.XPath("//span[@class='dvHeaderText']")).Text;
            StringAssert.Contains(contactName, "SN Varun");


        }
        [TestMethod]
        public void Login_ValidCredential_SuccessLogin()
        {
            String dashboardTitle = null;
            try
            {
                LoginPage login = new LoginPage(driver);
                login.Valid_Login(exUtil.Get_value_by_pasing_key("Login", "username_wrong"), exUtil.Get_value_by_pasing_key("Login", "password_wrong"));
                test.Log(Status.Info, "Test Executed");
                // Wait for the dashboard page to load
                //  dashboardTitle = driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Text;
                dashboardTitle =driver.Title;
                
                Assert.AreEqual("Home", dashboardTitle);
                test.Pass("Test Passed");
                
            }
            catch(Exception ex) 
            {
               test.Fail("Test Failed");
              
                test.Info(ex);
                WebdriverUtility.TakeScreenShot(driver);
                test.AddScreenCaptureFromPath(Utilities.BaseClass.screenShotPath);
                Console.Write(Utilities.BaseClass.screenShotPath);
                

            }


        }
       

    }

    }

