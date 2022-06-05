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
    public static class WrappedDriver
    {

        private static IWebDriver _instance;
        public static IWebDriver ChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            var driver = new ChromeDriver(options);            
            return driver;

        }

        public static IWebDriver Instance
        {

            get
            {
                if(_instance != null)
                {

                    return _instance;
                }
                else
                {
                    _instance = ChromeDriver();
                    return _instance;
                }

            }


        }

        public static bool WebDriverWait(IWebElement element, int timeOut)
        {

            var driverWait = new WebDriverWait(Instance,new TimeSpan(0,0,timeOut));
            var waitCondition =  driverWait.Until(  x =>
            {
                try
                {

                    return element.Displayed && element.Enabled;

                }
                catch (Exception exp)
                {
                    Console.WriteLine("Timeout Exception :" + exp.ToString());
                    return false;
                }

            });

            return waitCondition;


        }

        public static void WaitForElement(this IWebDriver driver, By elementSelector, int timeOut)
        {

            var driverWait = new WebDriverWait(driver, new TimeSpan(0, 0, timeOut));
            var waitCondition = driverWait.Until(x =>
            {
                try
                {

                    return driver.FindElements(elementSelector).Count > 0;

                }
                catch (Exception exp)
                {
                    Console.WriteLine("Timeout Exception :" + exp.ToString());
                    return false;
                }

            });

        }


    }
}
