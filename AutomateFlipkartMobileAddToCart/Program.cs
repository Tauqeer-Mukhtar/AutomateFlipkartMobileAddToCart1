using System;

namespace AutomateFlipkartMobileAddToCart
{
    class Automation
    {

        static public void Main(String[] args)
        {
            
            var HomePage = new HomePage();
            HomePage.Open();
            HomePage.SearchAndAddToCart();

        }
    }

}