using Reqnroll;
using SpanishPoint.MatchingEngine.Tests.Pages;

namespace SpanishPoint.MatchingEngine.Tests.StepDefinitions;

[Binding]
public class NavigationSteps
{
    private readonly HomePage _homePage;


    public NavigationSteps(HomePage homePage)
    {
        _homePage = homePage;
    }

    [Given("the Matching Engine homepage is displayed")]
    public void GivenTheMatchingEngineHomepageIsDisplayed()
    {
        _homePage.NavigateToHomePage();
    }

    [When("the {string} menu is expanded")]
    public void WhenTheMenuIsExpanded(string menuName)
    {
        _homePage.ExpandSolutionsMenu();
    }

    [Then("the expected list of solutions should be displayed")]
    public void ThenTheExpectedListOfSolutionsShouldBeDisplayed()
    {
        var expectedSolutionsList = new List<string>
        {
            "Music and copyright solutions",
            "Repertoire management",
            "Repertoire and usage matching",
            "Data ingestion and integration",
            "Distribution processing",
            "Member management",
            "Member self service"
        };

        var actualSolutionsList = _homePage.GetSolutionsList();
        Assert.That(actualSolutionsList, Is.EquivalentTo(expectedSolutionsList).IgnoreCase, "The actual list of solutions does not match the expected list.");
    }

}
