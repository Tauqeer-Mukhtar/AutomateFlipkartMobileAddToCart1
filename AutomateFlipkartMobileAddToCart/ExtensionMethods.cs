using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;




namespace AutomateFlipkartMobileAddToCart
{
    public  static class ExtensionMethods
    {
            
        public static void SafeClick(this IWebElement element, int timeOut = 5, int explicitWait = 1)
        {
        
            
            var visibility = WrappedDriver.WebDriverWait(element,timeOut);
            if (!visibility)
                throw new Exception("Element Not Visible");
            element.Click();
            Thread.Sleep(explicitWait * 1000);
            
        }

        public static void SwitchToTab(this IWebDriver driver,  int tabNumber = 1)
        {

            var windowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles[tabNumber]);

        }

        public static void SwitchToMainWindow(this IWebDriver driver)
        {

            var windowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles[0]);

        }

        public static string GetTypedValue(this IWebElement element)
        {

            return "d";


        }

    }
}
