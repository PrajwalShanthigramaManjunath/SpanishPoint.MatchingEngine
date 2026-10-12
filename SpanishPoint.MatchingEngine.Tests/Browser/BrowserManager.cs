using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpanishPoint.MatchingEngine.Tests.Browser;

public sealed class BrowserManager : IBrowserManager, IDisposable
{
    private IWebDriver? _webDriver;

    public IWebDriver WebDriver =>
        _webDriver ?? throw new InvalidOperationException(
            "The browser has not been initialized.");

    public void InitializeBrowser(string browserType)
    {
        if (!string.Equals(
                browserType,
                "Chrome",
                StringComparison.OrdinalIgnoreCase))
        {
            throw new NotSupportedException(
                $"Browser '{browserType}' is not supported. Chrome is required.");
        }

        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");

        _webDriver = new ChromeDriver(options);
    }

    public void Dispose()
    {
        var driver = _webDriver;
        _webDriver = null;

        driver?.Quit();
    }
}
