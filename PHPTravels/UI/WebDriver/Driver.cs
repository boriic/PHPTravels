using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace UI.WebDriver
{
    public class Driver
    {
        public static IWebDriver WebDriver { get; set; }
        public static IWebDriver CreateWebDriver()
        {
            string sDriverPath = TestContext.Parameters["WebDriverPath"];
            string sBrowser = TestContext.Parameters["WebDriverPath"];
            IWebDriver _driver;

            switch (sBrowser.ToLower())
            {
                case "chrome":
                    _driver = new ChromeDriver(sDriverPath);
                    break;
                case "firefox":
                    _driver = new FirefoxDriver(sDriverPath);
                    break;
                case "edge":
                    _driver = new EdgeDriver(sDriverPath);
                    break;
                default:
                    _driver = new ChromeDriver(sDriverPath);
                    break;
            }
            return _driver;
        }
    }
}
