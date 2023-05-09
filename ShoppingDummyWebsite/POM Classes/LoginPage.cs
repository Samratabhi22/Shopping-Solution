using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.POM_Classes
{
    public  class LoginPage
    {

        private IWebDriver driver;
        // driver.FindElement(By.Id("username"))//webelement
        //By.Id("username")//locator
        // SendKeys("rahulshettyacademy");//acton on webelement

        // driver.FindElement(By.Name("password")).SendKeys("learning");

        //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
        //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement userName;
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement passWord;
        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkbox;
        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In']")]
        private IWebElement signbtn;


        //Page Object Factory
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public ProductsPage validLogin(string user )
        {
            //Action on page objects

            userName.SendKeys(user);
            passWord.SendKeys(user);
            checkbox.Click();
            signbtn.Click();
            return new ProductsPage(driver);


        }
    }
}
