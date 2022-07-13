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

        [Then(@"the ""([^""]*)"" page should be displayed")]
        public void ThenThePageShouldBeDisplayed(string sPage)
        {
            switch (sPage.ToLower())
            {
                case "google":
                    VerifyMethods.VerifyPageURL(DemoMap.Page_Google);
                    break;

                default:
                    throw new Exception("Page not found");
            }
        }

        [When(@"I click on the ""([^""]*)"" button")]
        public void WhenIClickOnTheButton(string sButton)
        {
            switch (sButton.ToLower())
            {
                case "accept cookies":
                    SetMethods.Click(DemoMap.btnAcceptCookies);
                    break;

                default:
                    throw new Exception("Button not found");
            }
        }

        [Then(@"the ""([^""]*)"" textbox should be displayed, enabled and empty")]
        public void ThenTheTextboxShouldBeDisplayedEnabledAndEmpty(string sTextbox)
        {
            switch (sTextbox.ToLower())
            {
                case "search":
                    VerifyMethods.Displayed(DemoMap.TextBox_Search);
                    VerifyMethods.Enabled(DemoMap.TextBox_Search);
                    VerifyMethods.Empty(DemoMap.TextBox_Search);
                    break;

                default:
                    throw new Exception("Textbox not found");
            }
        }

        [When(@"I enter ""([^""]*)"" into ""([^""]*)"" textbox")]
        public void WhenIEnterIntoTextbox(string sValue, string sTextbox)
        {
            switch (sTextbox.ToLower())
            {
                case "search":
                    SetMethods.EnterText(DemoMap.TextBox_Search, sValue);
                    break;

                default:
                    throw new Exception("Textbox not found");
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
