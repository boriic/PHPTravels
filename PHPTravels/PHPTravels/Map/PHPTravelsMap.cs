using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WebDriver;

namespace PHPTravels.Map
{
    public static class PHPTravelsMap
    {
        public static string PHPTravelsPage => "https://www.phptravels.net/";

        public static class Home
        {
            public static IWebElement btnLogin => Driver.WebDriver.FindElement(By.XPath("//a[@class='theme-btn theme-btn-small theme-btn-transparent ml-1 waves-effect']"));
        } 
        public static class Login
        {
            public static string PHPTravelsLoginPage => "https://www.phptravels.net/login";

            public static IWebElement txtEmail => Driver.WebDriver.FindElement(By.Name("email"));
            public static IWebElement txtPassword => Driver.WebDriver.FindElement(By.Name("password"));
            public static IWebElement btnLogin => Driver.WebDriver.FindElement(By.XPath("//div[@class='btn-box pt-3 pb-4']/button"));
        }
        public static class Dashboard
        {
            public static string PHPTravelsDashboardPage = "https://www.phptravels.net/account/dashboard";

            public static IWebElement wrpMenu => Driver.WebDriver.FindElement(By.XPath("//*[@id='fadein']/header/div[2]/div/div/div/div/div[2]/nav/ul"));
        }
        public static class Tours
        {
            public static string PHPTravelsToursPage => "https://www.phptravels.net/tours";

            public static IWebElement ddDestination => Driver.WebDriver.FindElement(By.Id("tours_city"));
            public static IWebElement dpCheckIn => Driver.WebDriver.FindElement(By.XPath("//input[@id='date']"));
            public static IWebElement ddTravellers => Driver.WebDriver.FindElement(By.XPath("//*[@id='tours-search']/div/div/div[3]/div/div/div/a"));
            public static IWebElement btnSearch => Driver.WebDriver.FindElement(By.Id("submit"));
            public static IWebElement txtDestination => Driver.WebDriver.FindElement(By.XPath("/html/body/span/span/span[1]/input"));
            public static IWebElement btnAddAdults => Driver.WebDriver.FindElement(By.XPath("//*[@id='tours-search']/div/div/div[3]/div/div/div/div/div[1]/div/div/div[2]/i"));
            public static IWebElement btnRemoveAdults => Driver.WebDriver.FindElement(By.XPath("//*[@id='tours-search']/div/div/div[3]/div/div/div/div/div[1]/div/div/div[1]/i"));
            public static IWebElement btnAddChild => Driver.WebDriver.FindElement(By.XPath("//*[@id='tours-search']/div/div/div[3]/div/div/div/div/div[2]/div/div/div[2]/i"));
            public static IWebElement btnRemoveChild => Driver.WebDriver.FindElement(By.XPath("//*[@id='tours-search']/div/div/div[3]/div/div/div/div/div[2]/div/div/div[1]/i"));
            public static IWebElement lblAdultsCount => Driver.WebDriver.FindElement(By.XPath("//*[@id='tours_adults']"));
            public static IWebElement wrpDestinationResults => Driver.WebDriver.FindElement(By.Id("select2-tours_city-results"));


            public class Results
            {
                public static IWebElement wrpResultList => Driver.WebDriver.FindElement(By.XPath("//section[@id='data']//ul"));
            }
        }
    }
}
