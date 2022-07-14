Feature: PHPTravels

Testing functionalities of PHPTravels tours page

@TC001
Scenario: Search for destination and verify location
	Given I navigate to the PHPTravels page
	Then the "PHPTravels" page should be displayed
	And the "Login" button should be displayed and enabled
	When I click on the "Login" button
	Then the "Login" page should be displayed
	And the "Email" textbox should be displayed, enabled and empty
	And the "Password" textbox should be displayed, enabled and empty
	And the "LoginUser" button should be displayed and enabled
	When I enter corresponding string into "Email" textbox
	Then the "Email" textbox should contain corresponding string
	When I enter corresponding string into "Password" textbox
	Then the "Password" textbox should contain corresponding string
	When I click on the "LoginUser" button
	Then the "PHPTravels Dashboard" page should be displayed
	And the top menu should be displayed
	And the top menu should contain "Tours" menu item
	When I click on the "Tours" menu item
	Then the "Tours" page should be displayed
	And the "Destination" dropdown should be displayed, enabled and contains "Search by City" value
	And the "Check-in" datepicker should be displayed and enabled
	And the "Travellers" dropdown should be displayed, enabled and contains "Travellers 1" value
	And the "Search" button should be displayed and enabled
	When I click on the "Destination" dropdown
	Then the "Destination" textbox should be displayed, enabled and empty
	When I enter "Istanbul" into "Destination" textbox
	Then the "Destination" textbox should contain "Istanbul" string
	And the "Destination" dropdown should contain "Istanbul,Turkey" option
	When I click on "Istanbul,Turkey" option in "Destination" dropdown
	Then the "Destination" dropdown should have "Istanbul,Turkey" selected
	When I click on the "Travellers" dropdown
	Then the "Add adults" button should be displayed and enabled
	And the "Remove adults" button should be displayed and enabled
	And the "Add child" button should be displayed and enabled
	And the "Remove child" button should be displayed and enabled
	When I click on the "Add adults" button
	Then the adults count should be "2"
	When I click on the "Search" button
	Then the "Search Result List" should be displayed
	And the random tour from the list should contain "Istanbul" as the location

@TC002
Scenario: Click on random tour and book
	Given I navigate to the PHPTravels page
	Then the "PHPTravels" page should be displayed
	And the "Login" button should be displayed and enabled
	When I click on the "Login" button
	Then the "Login" page should be displayed
	And the "Email" textbox should be displayed, enabled and empty
	And the "Password" textbox should be displayed, enabled and empty
	And the "LoginUser" button should be displayed and enabled
	When I enter corresponding string into "Email" textbox
	Then the "Email" textbox should contain corresponding string
	When I enter corresponding string into "Password" textbox
	Then the "Password" textbox should contain corresponding string
	When I click on the "LoginUser" button
	Then the "PHPTravels Dashboard" page should be displayed
	And the top menu should be displayed
	And the top menu should contain "Tours" menu item
	When I click on the "Tours" menu item
	Then the "Tours" page should be displayed
	When I click on random tour
	Then the "Random Tour" page should be displayed
	And the "Adults" dropdown should be displayed, enabled and contains "1" value
	And the "Book Now" button should be displayed and enabled
	When I click on "2" option in "Adults" dropdown
	Then the "Adults" dropdown should have "2" selected
	When I click on the "Book Now" button
	Then the "Booking" page should be displayed