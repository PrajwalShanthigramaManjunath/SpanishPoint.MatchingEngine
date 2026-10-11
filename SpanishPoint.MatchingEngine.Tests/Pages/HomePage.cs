using OpenQA.Selenium;
using SpanishPoint.MatchingEngine.Tests.Browser;
using SpanishPoint.MatchingEngine.Tests.Configuration;

namespace SpanishPoint.MatchingEngine.Tests.Pages;

public class HomePage : BasePage
{
    private readonly string _baseUrl;

    private readonly By _homePageHeadingLocator =
        By.XPath("//h2[normalize-space()='Speeding up distributions at scale']");
    private IWebElement SolutionsElement => Driver.FindElement(By.Id("nav-toggle-solutions"));
    private IReadOnlyCollection<IWebElement> SolutionsList =>
    Driver.FindElements(By.CssSelector(
        "section[role='menu'] a[class*='SubNavLink_linkEl']"));


    public HomePage(
        IBrowserManager browserManager,
        ITestConfig testConfig): base(browserManager)
    {
        _baseUrl = testConfig.BaseUrl;
    }

    public void NavigateToHomePage()
    {
        Driver.Navigate().GoToUrl(_baseUrl);
        WaitForPageToLoad(_homePageHeadingLocator);
    }

    public void ExpandSolutionsMenu()
    {
        Wait.Until(_=>
        {
            var menu = SolutionsElement;
            return menu.Displayed && menu.Enabled;
        });

        SolutionsElement.Click();

        Wait.Until(_=>
            SolutionsElement.GetDomAttribute("aria-expanded") == "true");
    }

    public List<string> GetSolutionsList()
    {
        return SolutionsList
            .Where(item => item.Displayed)
            .Select(item => item.Text.Trim())
            .ToList();
    }

    public void SelectSolutionOption(string optionName)
    {
        var optionElement = Wait.Until(_ => SolutionsList
            .FirstOrDefault(item => item.Displayed && item.Text.Trim().Equals(optionName, StringComparison.OrdinalIgnoreCase)));
        if (optionElement == null)
        {
            throw new NoSuchElementException($"The solution option '{optionName}' was not found in the Solutions menu.");
        }
        optionElement.Click();
    }
}