using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WebDriver;

namespace UI.Methods
{
    public class SetMethods
    {
        public static void EnterText(IWebElement element, string sValue, int iWaitMili = 1500)
        {
            try
            {
                element.SendKeys(sValue);
                Thread.Sleep(iWaitMili);

                Logger.Logger.AddLog($"Enter Text ({sValue})");
            }
            catch (Exception)
            {
                Logger.Logger.AddLog($"Error occured while entering text: {sValue}", bError: true);
                throw new Exception($"Error occured while entering text: {sValue}");
            }
        }

        public static void Click(IWebElement element, bool bMoveToElement = false, int iWaitMili = 1500)
        {
            try
            {
                if (bMoveToElement)
                {
                    Actions actions = new Actions(Driver.WebDriver);
                    actions.MoveToElement(element).Click().Build().Perform();

                    Thread.Sleep(iWaitMili);

                    Logger.Logger.AddLog($"Click (Move to element ({bMoveToElement}))");
                }
                else
                {
                    element.Click();

                    Thread.Sleep(iWaitMili);

                    Logger.Logger.AddLog($"Click");
                }
            }
            catch (Exception)
            {
                Logger.Logger.AddLog($"Error occured while clicking the element: {element.TagName}", bError: true);
                throw new Exception($"Error occured while clicking the element: {element.TagName}");
            }
        }

        public static void SelectOptionByValue(IWebElement element, string sOption)
        {
            try
            {
                var selectElement = new SelectElement(element);
                selectElement.SelectByValue(sOption);

                Logger.Logger.AddLog($"Select Option By Value ({sOption})");
            }

            catch (Exception)
            {
                Logger.Logger.AddLog($"Error occured while selecting option: {sOption}", bError: true);
                throw new Exception($"Error occured while selecting option: {sOption}");
            }
        }

        public static void SelectOptionByIndex(IWebElement element, int iIndex)
        {
            try
            {
                var selectElement = new SelectElement(element);
                selectElement.SelectByIndex(iIndex);

                Logger.Logger.AddLog($"Select Option By Index ({iIndex})");
            }

            catch (Exception)
            {
                Logger.Logger.AddLog($"Error occured while selecting option on index: {iIndex}", bError: true);
                throw new Exception($"Error occured while selecting option on index: {iIndex}");
            }
        }

        public static void ClickOnMenuItem(IWebElement menuElement, string sMenuItem)
        {
            IList<IWebElement> lItems = menuElement.FindElements(By.TagName("li"));

            if (!lItems.Any(item => item.Text == sMenuItem))
            {
                Logger.Logger.AddLog($"Menu item doesn't contain {sMenuItem}", bError: true);
                throw new Exception($"Menu item doesn't contain {sMenuItem}");
            }

            lItems.FirstOrDefault(item => item.Text == sMenuItem).Click();

            Logger.Logger.AddLog($"Click On Menu Item {sMenuItem}");
        }
    }
}
