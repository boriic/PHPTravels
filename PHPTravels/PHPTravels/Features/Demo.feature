Feature: Demo

@TC0001
Scenario: Navigate to google page
	Given I navigate to "Google" page
	Then the "Google" page should be displayed
	When I click on the "Accept cookies" button
	Then the "Search" textbox should be displayed, enabled and empty
	When I enter "bla bla bla" into "Search" textbox
	Then the "Search" textbox should contain "bla bla bla" value