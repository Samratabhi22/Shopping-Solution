using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerWebApplicationMSTestUnit.Utilities
{
    public  class WebdriverUtility
    {
        


        public void ImplicitlyWaitingForSeconds(IWebDriver driver, int seconds)

        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }


        public void MaximizeWindow(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }
        public void Select(IWebDriver driver, IWebElement element, int index)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByIndex(index);

        }
        public void Select(IWebDriver driver, IWebElement element, string text)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText(text);

        }
        public void Select(string value, IWebDriver driver, IWebElement element)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);

        }
        public void SwitchToFrame(IWebDriver driver, int index)
        {

            driver.SwitchTo().Frame(index);
        }
        public void SwitchToFrame(IWebDriver driver, string text)
        {
            driver.SwitchTo().Frame(text);
        }
        public void SwitchToFrame(string id, IWebDriver driver)
        {
            driver.SwitchTo().Frame(id);
        }
        public void AlertAccept(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Accept();
        }
        public void AlertDismiss(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Dismiss();
        }
        public string AlertGetText(IWebDriver driver)
        {
            string text = driver.SwitchTo().Alert().Text;
            return text;
        }
        public void AlertSendValue(IWebDriver driver, string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
        }
        public static void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            var ss = screenshot.GetScreenshot();
            Utilities.BaseClass. screenShotPath = "C:\\Users\\Hp\\source\\repos\\ECommerceProject\\Shopping Solution\\VtigerWebApplicationMSTestUnit\\Utilities\\ScreenShots\\ss.png";
            ss.SaveAsFile(Utilities.BaseClass.screenShotPath, ScreenshotImageFormat.Png);
           // return screenShotPath;

        }
    }
}
