using PHPTravels.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UI.Logger;
using UI.Methods;
using UI.WebDriver;

namespace PHPTravels.Steps
{
    [Binding]
    public class DemoSteps
    {
        [Given(@"I navigate to ""([^""]*)"" page")]
        public void GivenINavigateToPage(string sPage)
        {
            switch (sPage.ToLower())
            {
                case "google":
                    Helpers.NavigateToPage(DemoMap.Page_Google);
                    break;

                default:
                    throw new Exception("Page not found");
            }
        }

        [Then(@"the ""([^""]*)"" textbox should contain ""([^""]*)"" value")]
        public void ThenTheTextboxShouldContainValue(string sTextbox, string sValue)
        {
            switch (sTextbox.ToLower())
            {
                case "search":
                    VerifyMethods.VerifyText(DemoMap.TextBox_Search, sValue);
                    break;

                default:
                    break;
            }
        }

    }
}
