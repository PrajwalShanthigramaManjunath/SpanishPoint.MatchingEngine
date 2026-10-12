Feature: Matching Engine website navigation

Scenario: Solutions menu displays available solutions
	Given the Matching Engine homepage is displayed
	When the "Solutions" menu is expanded
	Then the expected list of solutions should be displayed

Scenario: Distribution Processing page displays expected content
	Given the Matching Engine homepage is displayed
	When the "Solutions" menu is expanded
	And the "Distribution Processing" option is selected from the Solutions menu
	And the Distribution Processing page is scrolled to the "All-in-one solution for scale" section
	Then the "All-in-one solution for scale" section on the Distribution Processing page should display the expected content