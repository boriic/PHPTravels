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
            {
                Logger.Logger.AddLog("Element is not displayed but should be!", true, true);
                throw new Exception("Element is not displayed but should be!");
            }

            if (!bDisplayed && element.Displayed)
            {
                Logger.Logger.AddLog("Element is displayed but should not be!", true, true);
                throw new Exception("Element is displayed but should not be!");
            }

            Logger.Logger.AddLog($"Displayed ({bDisplayed})", bVerification: true);
        }

        public static bool isDisplayed(IWebElement element)
        {
            return element.Displayed;
        }

        public static void Enabled(IWebElement element, bool bEnabled = true)
        {
            if (bEnabled && !element.Enabled)
            {
                Logger.Logger.AddLog("Element is not enabled but should be!", true, true);
                throw new Exception("Element is not enabled but should be!");
            }

            if (!bEnabled && element.Displayed)
            {
                Logger.Logger.AddLog("Element is enabled but should not be!", true, true);
                throw new Exception("Element is enabled but should not be!");
            }

            Logger.Logger.AddLog($"Enabled ({bEnabled})", bVerification: true);
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
            {
                Logger.Logger.AddLog("Element is not empty but should be!", true, true);
                throw new Exception("Element is not empty but should be!");
            }

            if (!bEmpty && string.IsNullOrEmpty(sElementValue))
            {
                Logger.Logger.AddLog("Element is empty but should not be!", true, true);
                throw new Exception("Element is empty but should not be!");
            }

            Logger.Logger.AddLog($"Empty ({bEmpty})", bVerification: true);
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
            {
                Logger.Logger.AddLog($"Element value not as expected. Element text is: {sElementValue}, expected text is: {sValue}", true, true);
                throw new Exception($"Element value not as expected. Element text is: {sElementValue}, expected text is: {sValue}");
            }

            Logger.Logger.AddLog($"Verify Text ({sValue})", bVerification: true);
        }

        public static void VerifyTextContains(IWebElement element, string sValue)
        {
            string sElementValue = element.Text;

            if (string.IsNullOrEmpty(sElementValue))
                sElementValue = element.GetAttribute("value");

            if (!sElementValue.Contains(sValue))
            {
                Logger.Logger.AddLog($"Element value does not contain expected text. Element text is: {sElementValue}, expected text is: {sValue}", true, true);
                throw new Exception($"Element value does not contain expected text. Element text is: {sElementValue}, expected text is: {sValue}");
            }

            Logger.Logger.AddLog($"Verify Text Contains ({sValue})", bVerification: true);
        }

        public static void VerifySelectedOption(IWebElement element, string sOption, bool bSelectElement = true)
        {
            if (bSelectElement)
            {
                SelectElement selectElement = new SelectElement(element);
                string selectedOption = selectElement.SelectedOption.Text;

                if (!selectedOption.Contains(sOption))
                {
                    Logger.Logger.AddLog($"Selected option not as expected. Selected option is: {selectedOption}, expected option is: {sOption}", true, true);
                    throw new Exception($"Selected option not as expected. Selected option is: {selectedOption}, expected option is: {sOption}");
                }
                Logger.Logger.AddLog($"Verify Selected Option ({sOption})", true);
            }
            else
            {
                string sDefaultValue = element.FindElement(By.TagName("p")).Text;
                if (!sDefaultValue.Contains(sOption))
                {
                    Logger.Logger.AddLog($"Selected option not as expected. Selected option is: {sDefaultValue}, expected option is: {sOption}", true, true);
                    throw new Exception($"Selected option not as expected. Selected option is: {sDefaultValue}, expected option is: {sOption}");
                }
                Logger.Logger.AddLog($"Verify Selected Option ({sOption})", true);
            }
        }

        public static void VerifyPageURL(string sUrl)
        {
            if (!Driver.WebDriver.Url.Equals(sUrl))
            {
                Logger.Logger.AddLog($"Expected page is not displayed. URL is: {Driver.WebDriver.Url}, expected URL is: {sUrl}!", true, true);
                throw new Exception($"Expected page is not displayed. URL is: {Driver.WebDriver.Url}, expected URL is: {sUrl}!");
            }

            Logger.Logger.AddLog($"Verify Page URL ({sUrl})", bVerification: true);
        }

        public static void VerifyPageURLContains(string sUrl)
        {
            if (!Driver.WebDriver.Url.Contains(sUrl))
            {
                Logger.Logger.AddLog($"Expected page is not displayed. URL is: {Driver.WebDriver.Url}, expected URL is: {sUrl}!", true, true);
                throw new Exception($"Expected page is not displayed. URL is: {Driver.WebDriver.Url}, expected URL is: {sUrl}!");
            }

            Logger.Logger.AddLog($"Verify Page URL Contains ({sUrl})", bVerification: true);
        }

        public static void VerifyMenuItemExist(IWebElement menuElement, string sMenuItem)
        {
            IList<IWebElement> lItems = menuElement.FindElements(By.TagName("li"));

            if (!lItems.Any(item => item.Text == sMenuItem))
            {
                Logger.Logger.AddLog($"Menu item {sMenuItem} doesn't exist", bError: true);
                throw new Exception($"Menu item doesn't contain {sMenuItem}");
            }

            Logger.Logger.AddLog($"Verify Menu Item Exist {sMenuItem}");
        }

        public static void VerifyDatePickerWithCurrentDate(IWebElement datePickerElement)
        {
            string sValue = datePickerElement.GetAttribute("value");

            string sCurrentDate = DateTime.Now.ToString("dd-MM-YYYY");

            if (sValue != sCurrentDate)
            {
                Logger.Logger.AddLog($"Date picker value not correct. Current value: {sValue}, expected value: {sCurrentDate}", bError: true);
            }

            Logger.Logger.AddLog($"Date picker value not correct. Current value: {sValue}, expected value: {sCurrentDate}");
        }
    }
}
