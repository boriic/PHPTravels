using TechTalk.SpecFlow;
using UI.Logger;
using UI.WebDriver;

namespace PHPTravels.Hooks
{
    [Binding]
    public class BaseHooks
    {

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            if (Driver.WebDriver == null)
                Driver.WebDriver = Driver.CreateWebDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.WebDriver.Quit();

            Logger.CreateLog();
        }
    }
}