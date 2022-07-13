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
        public static void Clear(IWebElement element)
        {
            try
            {
                element.Clear();
                Logger.Logger.AddLog($"Clear ({element.TagName}: {element.Text})", bError: true);
            }
            catch (Exception ex)
            {
                Logger.Logger.AddLog($"Error occured while clearing text: {ex.Message}", bError: true);
                throw new Exception($"Error occured while clearing text: {ex.Message}");
            }
        }
        public static void NavigateToPage(string sUrl)
        {
            try
            {
                Driver.WebDriver.Navigate().GoToUrl(sUrl);
                Driver.WebDriver.Manage().Window.Maximize();

                Logger.Logger.AddLog($"Navigate To Page ({sUrl})");
            }
            catch (Exception)
            {
                Logger.Logger.AddLog($"Error occured while navigating to: {sUrl}!", bError: true);
                throw new Exception($"Error occured while navigating to: {sUrl}.");
            }
        }
    }
}
