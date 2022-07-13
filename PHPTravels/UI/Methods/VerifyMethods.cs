using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WebDriver;

namespace UI.Methods
{
    public class VerifyMethods
    {
        public static void Displayed(IWebElement element, bool bDisplayed = true)
        {
            if (bDisplayed && !element.Displayed)
                //logger
                throw new Exception("Element is not displayed but should be!");

            if (!bDisplayed && element.Displayed)
                //logger
                throw new Exception("Element is displayed but should not be!");
        }

        public static bool isDisplayed(IWebElement element)
        {
            return element.Displayed;
        }

        public static void Enabled(IWebElement element, bool bEnabled = true)
        {
            if (bEnabled && !element.Enabled)
                //logger
                throw new Exception("Element is not enabled but should be!");

            if (!bEnabled && element.Displayed)
                //logger
                throw new Exception("Element is enabled but should not be!");
        }
        public static bool isEnabled(IWebElement element)
        {
            return element.Enabled;
        }

        public static void Empty(IWebElement element, bool bEmpty = true)
        {
            string sElementValue = element.Text;

            if (string.IsNullOrEmpty(sElementValue))
                sElementValue = element.GetAttribute("value");

            if (bEmpty && !string.IsNullOrEmpty(sElementValue))
                //logger
                throw new Exception("Element is not empty but should be!");

            if (!bEmpty && string.IsNullOrEmpty(sElementValue))
                //logger
                throw new Exception("Element is empty but should not be!");
        }
        public static bool isEmpty(IWebElement element)
        {

            if (string.IsNullOrEmpty(element.Text) && string.IsNullOrEmpty(element.GetAttribute("value")))
                return true;
            else
                return false;
        }

        public static void VerifyText(IWebElement element, string sValue)
        {
            string sElementValue = element.Text;

            if (string.IsNullOrEmpty(sElementValue))
                sElementValue = element.GetAttribute("value");

            if (!sElementValue.Equals(sValue))
                //logger
                throw new Exception($"Element value not as expected. Element text is: {sElementValue}, expected text is {sValue}");
        }

        public static void VerifyTextContains(IWebElement element, string sValue)
        {
            string sElementValue = element.Text;

            if (string.IsNullOrEmpty(sElementValue))
                sElementValue = element.GetAttribute("value");

            if (!sElementValue.Contains(sValue))
                //logger
                throw new Exception($"Element value does not contain expected text. Element text is: {sElementValue}, expected text is {sValue}");
        }

        public static void VerifySelectedOption(IWebElement element, string sOption)
        {
            SelectElement selectElement = new SelectElement(element);
            string selectedOption = selectElement.SelectedOption.ToString();

            if (selectedOption != sOption)
            {
                //logger
                throw new Exception($"Selected option not as expected. Selected option is {selectedOption}, expected option is {sOption}");
            }
        }

        public static void VerifyPageURL(string sUrl)
        {
            if (!Driver.WebDriver.Url.Equals(sUrl))
                //logger
                throw new Exception("Expected page is not displayed");
        }

        public static void VerifyPageURLContains(string sUrl)
        {
            if (!Driver.WebDriver.Url.Contains(sUrl))
                //logger
                throw new Exception("Expected page is not displayed");
        }

    }
}
