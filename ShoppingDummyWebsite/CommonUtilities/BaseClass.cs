using AventStack.ExtentReports.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;

namespace ShoppingDummyWebsite.CommonUtilities
{
    [TestClass]
    [TestCategory("BaseClass")]
    public class BaseClass
    {
        public IWebDriver driver;
        public ExcelUtilities exUtil;
        public IWebDriverUtility wUtil;


        [TestInitialize]
        public void initializeTest()

        {
            //configuration
           
            driver = new ChromeDriver();
            exUtil = new ExcelUtilities();
            wUtil = new IWebDriverUtility();

            wUtil.ImplicitlyWaitingForSeconds(driver,5);
            wUtil.MaximizeWindow(driver);

           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
           // driver.Manage().Window.Maximize();
            driver.Url = exUtil.Get_value_by_pasing_key("Ecom_Login", "url");

        }
        
       // public IWebDriver getDriver()
       // {
         //   return driver;
        //}
       [TestCleanup]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}

