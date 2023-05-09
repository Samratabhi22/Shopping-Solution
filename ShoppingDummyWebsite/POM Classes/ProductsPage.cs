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
    public class ProductsPage
    {
        private IWebDriver driver;
        By title = By.CssSelector(".card-title a");
        By addToCart = By.CssSelector(".card-footer button");


        // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

        //    IList<IWebElement> actualProducts = driver.FindElements(By.TagName("app-card"));
        //  driver.FindElement(By.PartialLinkText("Checkout")).Click();

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> products;
        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkOutButton;
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void waitForPageToDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

        }
        public IList<IWebElement> getproducts()
        {
            return products;
        }
        public By getTitle()
        {
            return title;
        }
        public By getaddToCartButton()
        {
            return addToCart;
        }
        public CheckOutPage CheckOut()
        {
            checkOutButton.Click();
            return new CheckOutPage(driver);
        }
    }
}

