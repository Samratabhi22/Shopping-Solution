using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace VtigerWebApplicationMSTestUnit.POM_Pages
{
    public  class LoginPage
    {
        [FindsBy(How = How.Name, Using = "user_name")]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "user_password")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "submitButton")]
        private IWebElement LoginButton { get; set; }

        public LoginPage(IWebDriver driver)

        {
            
            PageFactory.InitElements(driver, this);
        }

        public void Valid_Login(string username, string password)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            LoginButton.Click();
        }
    }
}
