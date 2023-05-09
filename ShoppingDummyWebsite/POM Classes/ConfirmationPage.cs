using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace ShoppingDummyWebsite.POM_Classes
{
    public class ConfirmationPage
    {
        private IWebDriver driver;
        // driver.FindElement(By.Id("country")).SendKeys("Ind");

        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[.='India']")));
        // driver.FindElement(By.XPath("//a[.='India']")).Click();
        // driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
        // driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();
        //  driver.FindElement(By.XPath("//strong[contains(text(),'Success')]"))

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement countryTxtBox;

        [FindsBy(How = How.XPath, Using = "//a[.='India']")]
        private IWebElement countryclick;

        [FindsBy(How = How.XPath, Using = "//label[@for='checkbox2']")]
        private IWebElement checkbox;

        [FindsBy(How = How.XPath, Using = "//input[@value='Purchase']")]
        private IWebElement purchaseButton;

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'Success')]")]
        private IWebElement SuccessTextMatch { get; set; }

        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        public void getCountryTxtBox()
        {
            countryTxtBox.SendKeys("Ind");
        }
        public void waitForCountriesListToDisplay()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[.='India']")));
        }
        public void getCountryClick()
        {
            countryclick.Click();
        }
        public void getCheckBoxClick()
        {
            checkbox.Click();
        }
        public void getpurchaseButton()
        {
            purchaseButton.Click();
        }
        public string getSucessMatch()
        {
            return SuccessTextMatch.Text;
        }
    }
}

