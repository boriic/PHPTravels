using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WebDriver;

namespace UI.Methods
{
    public class Helpers
    {
        public static void MoveToElement(IWebElement element, bool bUseJavaScript)
        {
            if (!bUseJavaScript)
            {
                Actions actions = new Actions(Driver.WebDriver);

                actions.MoveToElement(element).Build().Perform();

                Thread.Sleep(1000);
            }
            else
            {
                ((IJavaScriptExecutor)Driver.WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

                Thread.Sleep(1000);
            }

        }
    }
}
