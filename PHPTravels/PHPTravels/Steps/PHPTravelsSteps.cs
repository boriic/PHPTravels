using PHPTravels.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UI.Methods;

namespace PHPTravels.Steps
{
    [Binding]
    public class PHPTravelsSteps
    {
        [Given(@"I navigate to the PHPTravels page")]
        public void GivenINavigateToThePHPTravelsPage()
        {
            Helpers.NavigateToPage(PHPTravelsMap.PHPTravelsPage);
        }

        [Then(@"the ""([^""]*)"" page should be displayed")]
        public void ThenThePageShouldBeDisplayed(string sPage)
        {
            switch (sPage.ToLower())
            {
                case "phptravels":
                    VerifyMethods.VerifyPageURL(PHPTravelsMap.PHPTravelsPage);
                    break;

                case "login":
                    VerifyMethods.VerifyPageURL(PHPTravelsMap.Login.PHPTravelsLoginPage);
                    break;

                case "phptravels dashboard":
                    VerifyMethods.VerifyPageURL(PHPTravelsMap.Dashboard.PHPTravelsDashboardPage);
                    break;

                case "tours":
                    VerifyMethods.VerifyPageURL(PHPTravelsMap.Tours.PHPTravelsToursPage);
                    break;

                default:
                    throw new Exception("Page not found");
            }
        }


        [When(@"I enter ""([^""]*)"" into ""([^""]*)"" textbox")]
        public void WhenIEnterIntoTextbox(string sValue, string sTextbox)
        {
            switch (sTextbox.ToLower())
            {

                case "destination":
                    SetMethods.EnterText(PHPTravelsMap.Tours.txtDestination, sValue);
                    break;

                default:
                    throw new Exception("Textbox not found");
            }
        }


        [Then(@"the ""([^""]*)"" textbox should be displayed, enabled and empty")]
        public void ThenTheTextboxShouldBeDisplayedEnabledAndEmpty(string sTextbox)
        {
            switch (sTextbox.ToLower())
            {
                case "email":
                    VerifyMethods.Displayed(PHPTravelsMap.Login.txtEmail);
                    VerifyMethods.Enabled(PHPTravelsMap.Login.txtEmail);
                    VerifyMethods.Empty(PHPTravelsMap.Login.txtEmail);
                    break;

                case "password":
                    VerifyMethods.Displayed(PHPTravelsMap.Login.txtPassword);
                    VerifyMethods.Enabled(PHPTravelsMap.Login.txtPassword);
                    VerifyMethods.Empty(PHPTravelsMap.Login.txtPassword);
                    break;

                case "destination":
                    VerifyMethods.Displayed(PHPTravelsMap.Tours.txtDestination);
                    VerifyMethods.Enabled(PHPTravelsMap.Tours.txtDestination);
                    VerifyMethods.Empty(PHPTravelsMap.Tours.txtDestination);
                    break;

                default:
                    throw new Exception("Textbox not found");
            }
        }

        [When(@"I click on the ""([^""]*)"" button")]
        public void WhenIClickOnTheButton(string sButton)
        {
            switch (sButton.ToLower())
            {
                case "login":
                    SetMethods.Click(PHPTravelsMap.Home.btnLogin);
                    break;

                case "loginuser":
                    SetMethods.Click(PHPTravelsMap.Login.btnLogin);
                    break;

                default:
                    throw new Exception("Button not found");
            }
        }

        [Then(@"the ""([^""]*)"" button should be displayed and enabled")]
        public void ThenTheButtonShouldBeDisplayedAndEnabled(string sButton)
        {
            switch (sButton.ToLower())
            {
                case "login":
                    Thread.Sleep(3000);

                    VerifyMethods.Displayed(PHPTravelsMap.Home.btnLogin);
                    VerifyMethods.Enabled(PHPTravelsMap.Home.btnLogin);
                    break;

                case "LoginUser":
                    VerifyMethods.Displayed(PHPTravelsMap.Login.btnLogin);
                    VerifyMethods.Enabled(PHPTravelsMap.Login.btnLogin);
                    break;

                case "search":
                    VerifyMethods.Displayed(PHPTravelsMap.Tours.btnSearch);
                    VerifyMethods.Enabled(PHPTravelsMap.Tours.btnSearch);
                    break;

                default:
                    break;
            }
        }

        [When(@"I enter corresponding string into ""([^""]*)"" textbox")]
        public void WhenIEnterCorrespondingStringIntoTextbox(string sTextbox)
        {
            switch (sTextbox.ToLower())
            {
                case "email":
                    SetMethods.EnterText(PHPTravelsMap.Login.txtEmail, TestContext.Parameters["Email"]);
                    break;

                case "password":
                    SetMethods.EnterText(PHPTravelsMap.Login.txtPassword, TestContext.Parameters["Password"]);
                    break;

                default:
                    break;
            }
        }

        [Then(@"the ""([^""]*)"" textbox should contain corresponding string")]
        public void ThenTheTextboxShouldContainCorrespondingString(string sTextbox)
        {
            switch (sTextbox.ToLower())
            {
                case "email":
                    VerifyMethods.VerifyText(PHPTravelsMap.Login.txtEmail, TestContext.Parameters["Email"]);
                    break;

                case "password":
                    VerifyMethods.VerifyText(PHPTravelsMap.Login.txtPassword, TestContext.Parameters["Password"]);
                    break;

                default:
                    break;
            }
        }

        [Then(@"the top menu should be displayed")]
        public void ThenTheTopMenuShouldBeDisplayed()
        {
            VerifyMethods.Displayed(PHPTravelsMap.Dashboard.wrpMenu);
        }

        [Then(@"the top menu should contain ""([^""]*)"" menu item")]
        public void ThenTheTopMenuShouldContainMenuItem(string sMenuItem)
        {
            switch (sMenuItem.ToLower())
            {
                case "tours":
                    VerifyMethods.VerifyMenuItemExist(PHPTravelsMap.Dashboard.wrpMenu, "Tours");
                    break;

                default:
                    break;
            }
        }

        [When(@"I click on the ""([^""]*)"" menu item")]
        public void WhenIClickOnTheMenuItem(string sMenuItem)
        {
            switch (sMenuItem.ToLower())
            {
                case "tours":
                    SetMethods.ClickOnMenuItem(PHPTravelsMap.Dashboard.wrpMenu, "Tours");
                    break;

                default:
                    break;
            }
        }

        [Then(@"the ""([^""]*)"" dropdown should be displayed, enabled and contains ""([^""]*)"" value")]
        public void ThenTheDropdownShouldBeDisplayedEnabledAndContainsValue(string sDropdown, string sValue)
        {
            switch (sDropdown.ToLower())
            {
                case "destination":
                    VerifyMethods.VerifySelectedOption(PHPTravelsMap.Tours.ddDestination, sValue);
                    break;

                case "check-in":
                    VerifyMethods.VerifyDatePickerWithCurrentDate(PHPTravelsMap.Tours.dpCheckIn);
                    break;

                case "travellers":
                    Thread.Sleep(3000);

                    VerifyMethods.VerifySelectedOption(PHPTravelsMap.Tours.ddTravellers, sValue, false);
                    break;

                default:
                    break;
            }
        }

        [Then(@"the ""([^""]*)"" datepicker should be displayed and enabled and contains current date")]
        public void ThenTheDatepickerShouldBeDisplayedAndEnabledAndContainsCurrentDate(string sDatePicker)
        {
            switch (sDatePicker.ToLower())
            {
                default:
                    break;
            }
        }

        [When(@"I click on the ""([^""]*)"" dropdown")]
        public void WhenIClickOnTheDropdown(string sDropdown)
        {
            switch (sDropdown.ToLower())
            {
                case "destination":
                    SetMethods.Click(PHPTravelsMap.Tours.ddDestination, true);
                    break;

                default:
                    break;
            }
        }

        [Then(@"the ""([^""]*)"" textbox should contain ""([^""]*)"" string")]
        public void ThenTheTextboxShouldContainString(string sTextbox, string sValue)
        {
            switch (sTextbox.ToLower())
            {
                case "destination":
                    VerifyMethods.VerifyText(PHPTravelsMap.Tours.txtDestination, sValue);
                    break;

                default:
                    break;
            }
        }

        [Then(@"the ""([^""]*)"" dropdown should contain ""([^""]*)"" option")]
        public void ThenTheDropdownShouldContainOption(string sDropdown, string sValue)
        {
            switch (sDropdown.ToLower())
            {
                case "destination":
                    Thread.Sleep(5000);

                    Helpers.VerifySearchResults(PHPTravelsMap.Tours.wrpDestinationResults, sValue);
                    break;

                default:
                    break;
            }
        }

        [When(@"I click on ""([^""]*)"" option in ""([^""]*)"" dropdown")]
        public void WhenIClickOnOptionInDropdown(string sValue, string sDropdown)
        {
            switch (sDropdown.ToLower())
            {
                default:
                    break;
            }
        }


        [Then(@"the ""([^""]*)"" dropdown should have ""([^""]*)"" selected")]
        public void ThenTheDropdownShouldHaveSelected(string sDropdown, string sValue)
        {
            switch (sDropdown.ToLower())
            {
                default:
                    break;
            }
        }

        [Then(@"the adults count should be ""([^""]*)""")]
        public void ThenTheAdultsCountShouldBe(string sAdultsCount)
        {
            switch (sAdultsCount.ToLower())
            {
                default:
                    break;
            }
        }

        [Then(@"the ""([^""]*)"" should be displayed")]
        public void ThenTheShouldBeDisplayed(string sElement)
        {
            switch (sElement.ToLower())
            {
                default:
                    break;
            }
        }

        [Then(@"the random tour from the list should contain ""([^""]*)"" as the location")]
        public void ThenTheRandomTourFromTheListShouldContainAsTheLocation(string sValue)
        {
            switch (sValue.ToLower())
            {
                default:
                    break;
            }
        }


    }
}
