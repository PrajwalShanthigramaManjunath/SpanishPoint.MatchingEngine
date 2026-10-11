
using Reqnroll;
using Reqnroll.BoDi;
using SpanishPoint.MatchingEngine.Tests.Browser;
using SpanishPoint.MatchingEngine.Tests.Configuration;

namespace SpanishPoint.MatchingEngine.Tests.Hooks;

[Binding]
public sealed class BrowserHooks
{
    private readonly IObjectContainer _objectContainer;
    private readonly ITestConfig _testConfig;

    public BrowserHooks(
        IObjectContainer objectContainer,
        ITestConfig testConfig)
    {
        _objectContainer = objectContainer;
        _testConfig = testConfig;
    }

    [BeforeScenario]
    public void InitialiseBrowser()
    {
        var browserManager = new BrowserManager();

        browserManager.InitializeBrowser(_testConfig.TestBrowser);

        _objectContainer.RegisterInstanceAs<IBrowserManager>(
            browserManager,
            dispose: true);
    }
}
