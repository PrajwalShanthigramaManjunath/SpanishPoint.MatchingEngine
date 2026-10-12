using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
    private readonly By _cookiesDenyButton = By.Id("CybotCookiebotDialogBodyButtonDecline");
    private IWebElement CookiesDenyButton => Driver.FindElement(_cookiesDenyButton);


    public HomePage(
        IBrowserManager browserManager,
        ITestConfig testConfig) : base(browserManager)
    {
        _baseUrl = testConfig.BaseUrl;
    }

    public void NavigateToHomePage()
    {
        Driver.Navigate().GoToUrl(_baseUrl);
        WaitForPageToLoad(_homePageHeadingLocator);

        ManageCookieConsent();
    }

    public void ExpandSolutionsMenu()
    {
        Wait.Until(_ =>
        {
            var menu = SolutionsElement;
            return menu.Displayed && menu.Enabled;
        });

        SolutionsElement.Click();

        Wait.Until(_ =>
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

    private void ManageCookieConsent()
    {
        var cookieWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));

        try
        {
            cookieWait.Until(driver =>
                CookiesDenyButton.Displayed &&
                CookiesDenyButton.Enabled);

            CookiesDenyButton.Click();
        }
        catch (WebDriverTimeoutException)
        {
            // Continue the test if the cookie consent dialog does not appear within the timeout.
        }
    }
}