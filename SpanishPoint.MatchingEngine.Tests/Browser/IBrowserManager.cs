using OpenQA.Selenium;

namespace SpanishPoint.MatchingEngine.Tests.Browser;

    public interface IBrowserManager
    {
    IWebDriver WebDriver { get; }

    void InitializeBrowser(string browserType);

}

