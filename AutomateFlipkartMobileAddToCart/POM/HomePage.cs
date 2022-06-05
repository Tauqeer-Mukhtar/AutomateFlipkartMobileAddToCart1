using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AutomateFlipkartMobileAddToCart
{
    public class HomePage
    {

        private IWebDriver Driver;

        public HomePage()
        {
            Driver = WrappedDriver.Instance;

        }

        private string HomePageUrl = "https://www.flipkart.com/"; 
        private IWebElement Mobile => WrappedDriver.Instance.FindElement(By.CssSelector("[alt='Mobiles']"));
        private By listOfMobileCompanies => By.CssSelector("[alt='Shop Now']");
        private By ListOfMobiles => By.CssSelector(".CXW8mj");


        public void Open()
        {

            Driver.Url = HomePageUrl ;
            Driver.Navigate();
            var pageLoaded  =  WrappedDriver.WebDriverWait(Mobile,5);

            Console.WriteLine("Waiting for Page to load Completely...");
            if (!pageLoaded)
                throw new Exception("Page Not Loaded Completely");

            Console.WriteLine("Page Loading Finished.");
            Console.WriteLine("Close any Open Dialog...");

            var dialog = Driver.FindElements(By.CssSelector("._2KpZ6l._2doB4z"));

            if (dialog.Count > 0)
            {
                dialog[0].SafeClick(1);
            }

            
        }

        public void SearchAndAddToCart()
        {


            Mobile.SafeClick();
            Driver.WaitForElement(listOfMobileCompanies,5);
            Driver.FindElements(listOfMobileCompanies)[0].SafeClick();
            Driver.WaitForElement(ListOfMobiles,5);
            Driver.FindElements(ListOfMobiles)[0].SafeClick();
            Driver.SwitchToTab();
            Driver.WaitForElement(By.CssSelector("button._3v1-ww"), 5);
            Driver.FindElement(By.CssSelector("button._3v1-ww")).SafeClick();
            Driver.WaitForElement(By.CssSelector("._26HdzL+button"), 5);
            Driver.FindElement(By.CssSelector("._26HdzL+button")).SafeClick(explicitWait : 5);
            Console.WriteLine("Number of Products Selected are : " + Driver.FindElement(By.CssSelector("input._253qQJ")).GetAttribute("value"));
            Console.WriteLine("Total Price  = " + Driver.FindElement(By.XPath(".//*[contains(text(),'Total Amount')]//ancestor::div[@class='Ob17DV']//div//span")).Text);
            
        }

    }
}
