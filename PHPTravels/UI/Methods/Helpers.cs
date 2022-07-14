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
        public static string sRandomTourUrl = "";
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
                Logger.Logger.AddLog($"Error occured while clearing text", bError: true);
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
                Logger.Logger.AddLog($"Error occured while navigating to: ({sUrl})!", bError: true);
                throw new Exception($"Error occured while navigating to: ({sUrl}).");
            }
        }
        public static void VerifySearchResults(IWebElement element, string sOption)
        {
            IList<IWebElement> lSearchResults = element.FindElements(By.TagName("li"));

            if (!lSearchResults.Any(item => item.Text == sOption))
            {
                Logger.Logger.AddLog($"Search result doesn't contain ({sOption})", bError:true);
                throw new Exception($"Search result doesn't contain ({sOption})");
            }

            Logger.Logger.AddLog($"Verify Search Results ({sOption})", true);
        }

        public static void SelectFromDestinationDropdownByValue(IWebElement element, string sOption)
        {
            IList<IWebElement> lDestinations = element.FindElements(By.TagName("li"));

            if(!lDestinations.Any(item => item.Text == sOption))
            {
                Logger.Logger.AddLog($"Dropdown doesn't contain ({sOption})", bError: true);
                throw new Exception($"Dropdown doesn't contain ({sOption})");
            }
            lDestinations.FirstOrDefault(item => item.Text == sOption).Click();

            Logger.Logger.AddLog($"Select From Destination Dropdown By Value ({sOption})", true);
        }

        public static void VerifyRandomTourLocation(IWebElement element, string sValue)
        {
            IList<IWebElement> lResults = element.FindElements(By.TagName("li"));

            string sLocation = lResults[new Random().Next(0, 24)].FindElement(By.TagName("p")).Text;

            if (sLocation != sValue)
            {
                Logger.Logger.AddLog($"Random tour doesn't contain location ({sValue})", bError: true);
                throw new Exception($"Random tour doesn't contain location ({sValue})");
            }

            Logger.Logger.AddLog($"Verify Random Tour Location ({sValue})", true);
        }

        public static void ClickOnRandomTourAndRetreiveUrl(IWebElement element)
        {
            try
            {
                IList<IWebElement> lTours = element.FindElements(By.XPath("div[@class='col-lg-4']"));

                int iRandomTour = new Random().Next(0, lTours.Count - 1);

                sRandomTourUrl = lTours[iRandomTour].FindElement(By.TagName("a")).GetAttribute("href");

                Actions actions = new Actions(Driver.WebDriver);

                actions.MoveToElement(lTours[iRandomTour]).Build().Perform();

                Thread.Sleep(3000);

                lTours[iRandomTour].Click();

                Logger.Logger.AddLog("Click On Random Tour And Retreive Url");
            }
            catch (Exception)
            {
                Logger.Logger.AddLog($"Error occurred while trying to click on random tour", bError: true);
                throw new Exception($"Error occurred while trying to click on random tour");
            }
        }
    }
}
