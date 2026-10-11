using OpenQA.Selenium;
using SpanishPoint.MatchingEngine.Tests.Browser;
using SpanishPoint.MatchingEngine.Tests.Configuration;

namespace SpanishPoint.MatchingEngine.Tests.Pages;

public class HomePage : BasePage
{
    private readonly string _baseUrl;

    private readonly By _homePageHeadingLocator =
        By.XPath("//h2[normalize-space()='Speeding up distributions at scale']");

    public HomePage(
        IBrowserManager browserManager,
        ITestConfig testConfig): base(browserManager)
    {
        _baseUrl = testConfig.BaseUrl;
    }

    public void NavigateTo()
    {
        Driver.Navigate().GoToUrl(_baseUrl);
        WaitForPageToLoad(_homePageHeadingLocator);
    }
}