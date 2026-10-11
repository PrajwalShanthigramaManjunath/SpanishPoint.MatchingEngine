Feature: Matching Engine website navigation

Scenario: Solutions menu displays available solutions
    Given the Matching Engine homepage is displayed
    When the Solutions menu is expanded
    Then the expected solutions should be displayed

Scenario: Distribution Processing page displays expected content
    Given the Matching Engine homepage is displayed
    When the Solutions menu is expanded
    And the Distribution Processing option is selected
    And the page is scrolled to the "All-in-one solution for scale" section
    Then the section should display the expected content