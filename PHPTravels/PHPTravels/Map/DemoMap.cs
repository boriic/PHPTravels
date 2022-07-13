using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WebDriver;

namespace PHPTravels.Map
{
    public class DemoMap
    {
        public static string Page_Google = "https://www.google.hr/";

        public static IWebElement TextBox_Search => Driver.WebDriver.FindElement(By.Name("q"));
        public static IWebElement Button_Search => Driver.WebDriver.FindElement(By.Name("btnK"));
        public static IWebElement btnAcceptCookies => Driver.WebDriver.FindElement(By.Id("L2AGLb"));
    }
}
