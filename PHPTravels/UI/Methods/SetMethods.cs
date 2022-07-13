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
                //Logger
            }
            catch (Exception ex)
            {
                //Logger
                throw new Exception($"Error occured while entering text: {ex.Message}");
            }
        }

        public static void Click(IWebElement element, bool bMoveToElement, int iWaitMili = 1500)
        {
            try
            {
                if (bMoveToElement)
                {
                    Actions actions = new Actions(Driver.WebDriver);
                    actions.MoveToElement(element).Click().Build().Perform();
                    Thread.Sleep(iWaitMili);
                    //logger
                }
                else
                {
                    element.Click();
                    Thread.Sleep(iWaitMili);
                    //logger
                }
            }
            catch (Exception ex)
            {
                //logger
                throw new Exception($"Error occured while clicking the element: {ex.Message}");
            }
        }

        public static void SelectOptionByValue(IWebElement element, string sOption)
        {
            try
            {
                var selectElement = new SelectElement(element);
                selectElement.SelectByValue(sOption);
                //logger
            }

            catch (Exception ex)
            {
                //logger
                throw new Exception($"Error occured while selecting option: {ex.Message}");
            }
        }

        public static void SelectOptionByIndex(IWebElement element, int iIndex)
        {
            try
            {
                var selectElement = new SelectElement(element);
                selectElement.SelectByIndex(iIndex);
                //logger
            }

            catch (Exception ex)
            {
                //logger
                throw new Exception($"Error occured while selecting option: {ex.Message}");
            }
        }

        public static void Clear(IWebElement element)
        {
            try
            {
                element.Clear();
                //Logger
            }
            catch (Exception ex)
            {
                //Logger
                throw new Exception($"Error occured while clearing text: {ex.Message}");
            }
        }
    }
}
