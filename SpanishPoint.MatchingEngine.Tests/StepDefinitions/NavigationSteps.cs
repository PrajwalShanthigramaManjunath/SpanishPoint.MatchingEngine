using Reqnroll;
using SpanishPoint.MatchingEngine.Tests.Pages;

namespace SpanishPoint.MatchingEngine.Tests.StepDefinitions;

[Binding]
public class NavigationSteps
{
    private readonly HomePage _homePage;
    private readonly DistributionProcessingPage _distributionProcessingPage;


    public NavigationSteps(HomePage homePage, DistributionProcessingPage distributionProcessingPage)
    {
        _homePage = homePage;
        _distributionProcessingPage = distributionProcessingPage;
    }

    [Given("the Matching Engine homepage is displayed")]
    public void GivenTheMatchingEngineHomepageIsDisplayed()
    {
        _homePage.NavigateToHomePage();
    }

    [When("the {string} menu is expanded")]
    public void WhenTheMenuIsExpanded(string menuName)
    {
        switch (menuName.ToLower())
        {
            case "solutions":
                _homePage.ExpandSolutionsMenu();
                break;

            //Add more cases here for menus like Knowledge hub if needed in the future.

            default:
                throw new ArgumentException(
                    $"Menu '{menuName}' is not supported.");
        }
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

    [When("the {string} option is selected from the Solutions menu")]
    public void WhenTheOptionIsSelectedFromTheSolutionsMenu(string optionName)
    {
                _homePage.SelectSolutionOption(optionName);
               
    }

    [When("the Distribution Processing page is scrolled to the {string} section")]
    public void WhenTheDistributionProcessingPageIsScrolledToTheSection(string sectionName)
    {
                _distributionProcessingPage.ScrollToDistributionProcessingSection(sectionName);
 
    }

    [Then("the {string} section on the Distribution Processing page should display the expected content")]
    public void ThenTheSectionOnTheDistributionProcessingPageShouldDisplayTheExpectedContent(string sectionName)
    {
        switch (sectionName.ToLower())
        {
            case "all-in-one solution for scale":
                var expectedSectionContent = new[]
                {
        "All-in-one solution for scale",
        "Imagine an technology solution for collective management organisations that stays ahead of industry trends.",
        "With Matching Engine's distribution processing solution, you can:",
        "Distribute royalty payments quickly",
        "Provide full detail of music usage to members",
        "Reduce cost-to-distribution ratios.",
        "Prevent missing payments",
        "Matching Engine has advanced matching capability that ensures maximum automation to get money to Collective Management Organisation members quickly, while also preventing any missing payments.",
        "Comply with international standards",
        "The system complies with international metadata and encoding standards (ISWC, ISRC, DDEX, Unicode), and supports multilingual and non-latin script works.",
        "Run analytics and queries",
        "Collective Management Organisations can use Rest API to integrate other parts of their system. Its full data lakehouse gives access to underlying repertoire data to run analytics and queries.",
        "Manage different collection share pictures",
        "Matching Engine is designed to manage different collection share pictures based on territories and right types. This includes advanced support for carve outs and carve ins.",
        "Minimise manual intervention",
        "Advanced agreement support facilitates implementation of direct licensing carve outs and carve ins, without manual intervention on a work-by-work basis.",
        "Tackle fluctuating data volumes",
        "The Matching Engine system is based on a modern cloud-based architecture that scales dynamically to support fluctuating data volumes for Collective Management Organisations."
        };

                var actualSectionContent = _distributionProcessingPage.GetSectionContent(sectionName);

                foreach (var expectedText in expectedSectionContent)
                {
                    Assert.That(actualSectionContent,
                        Does.Contain(expectedText).IgnoreCase,
                        $"Expected content not found: {expectedText}");
                }
                break;
            //Add more cases if needed in the future.
            default:
                throw new ArgumentException(
                    $"Section '{sectionName}' is not supported.");
        }
    }
}
