using OpenQA.Selenium;
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
    }
}
