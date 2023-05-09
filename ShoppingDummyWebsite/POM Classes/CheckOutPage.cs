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
    public class CheckOutPage
    {
        private IWebDriver driver;
        //driver.FindElements(By.CssSelector("h4 a"));
        // driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();


        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> selectedproducts;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-success']")]
        private IWebElement checkOutButon;


        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IList<IWebElement> getselectedproducts()
        {
            return selectedproducts;
        }
        public ConfirmationPage finalCheckoutButton()
        {
            checkOutButon.Click();
            return new ConfirmationPage(driver);
        }

    }
}

