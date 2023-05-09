using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ShoppingDummyWebsite.CommonUtilities;
using ShoppingDummyWebsite.POM_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDummyWebsite.RawTestScripts
{
    [TestClass]
   [TestCategory("Endtoend")]
    public class EndToEndTest :BaseClass
    {
        [TestMethod]
        [TestCategory("Regression")]
        public void EndToEnd()

        {
            Console.WriteLine("============Started the execution in the EndToEnd() method ============");
            LoginPage loginpage = new LoginPage(driver); 
                                

            ProductsPage products_page = loginpage.validLogin(exUtil.Get_value_by_pasing_key("Ecom_Login", "username")); 
            Console.WriteLine(loginpage.validLogin(exUtil.Get_value_by_pasing_key("Ecom_Login", "username")));

            //  ProductsPage products_pages = loginpage.validLogin(exUtil.Get_value_by_pasing_key("Ecom_Login", "password"));

            products_page.waitForPageToDisplay();
            IList<IWebElement> actualProducts = products_page.getproducts();

            string[] expectedProducts = { "iphone X", "Blackberry", };
            string[] actualPrdcts = new string[2];
            Console.WriteLine(actualPrdcts);

           

         //   products_page.waitForPageToDisplay();
            //IList<IWebElement> actualProducts = products_page.getproducts();





            foreach (IWebElement product in actualProducts)
            {
                if (expectedProducts.Contains(product.FindElement(products_page.getTitle()).Text))
                {
                    //if true come inside if block
                    //if my array of string (2 phones)contains expected in all lists of phones

                    //if true then 
                    //then click on Add to cart else don't click
                    product.FindElement(products_page.getaddToCartButton()).Click();


                }
                string text = product.FindElement(products_page.getTitle()).Text;
                Console.WriteLine(text);

            }
            CheckOutPage checkoutpage = products_page.CheckOut();
            IList<IWebElement> checkoutCards = checkoutpage.getselectedproducts();

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualPrdcts[i] = checkoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualPrdcts);



            //moved to new page by selecting 2 phones iphone and blackberry


            ConfirmationPage confirmationpage = checkoutpage.finalCheckoutButton();


            //  driver.FindElement(By.Id("country")).SendKeys("Ind");

            confirmationpage.getCountryTxtBox();
            confirmationpage.waitForCountriesListToDisplay();
            confirmationpage.getCountryClick();
            confirmationpage.getCheckBoxClick();
            confirmationpage.getpurchaseButton();



            // driver.FindElement(By.XPath("//a[.='India']")).Click();
            //driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
            // driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();
            String confirmTexta = confirmationpage.getSucessMatch();
            String str = "Success";

            StringAssert.Contains(str, confirmTexta);




            Console.WriteLine("================Reached end===============");



        }

    }
}

