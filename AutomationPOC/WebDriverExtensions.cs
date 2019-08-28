using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationPOC
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementSafe(this IWebDriver driver, By by)
        {
            IWebElement element = null;
            try
            {
                element = driver.FindElement(by);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Element does not exist on the page. {by}");
            }

            return element;
        }
    }
}
