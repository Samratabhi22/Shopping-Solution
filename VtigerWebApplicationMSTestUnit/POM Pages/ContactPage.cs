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
    public class ContactPage
    {

        [FindsBy(How = How.XPath, Using = "//a[text()='Contacts']")]
        private IWebElement Contacts_Mod { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[contains(@title,'Create Contact')]")]
        private IWebElement plusicon { get; set; }

        [FindsBy(How = How.Name, Using = "firstname")]
        private IWebElement firstNameInput { get; set; }

        //  var lastNameInput = driver.FindElement(By.Name("lastname"));
        // lastNameInput.SendKeys("Doe");
        [FindsBy(How = How.Name, Using = "lastname")]
        private IWebElement lastNameInput { get; set; }
        // var emailInput = driver.FindElement(By.Name("email"));
        //emailInput.SendKeys("john.doe@example.com");
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement emailInput { get; set; }
        //var saveButton = driver.FindElement(By.CssSelector(".crmbutton.small.save"));
        // saveButton.Click();
        [FindsBy(How = How.CssSelector, Using = ".crmbutton.small.save")]
        private IWebElement saveButton { get; set; }

        public ContactPage(IWebDriver driver)

        {

            PageFactory.InitElements(driver, this);
        }

        public void Create_Contact(string firstname, string lastname,String mail)
        {

            Contacts_Mod.Click();
            plusicon.Click();
            firstNameInput.SendKeys(firstname);
            lastNameInput.SendKeys(lastname);
            emailInput.SendKeys(mail);
            saveButton.Click();
        }
    }
}
