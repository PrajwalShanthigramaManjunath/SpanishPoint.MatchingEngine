using Microsoft.Extensions.Configuration;
using NUnit.Framework.Constraints;
using Reqnroll;
using Reqnroll.BoDi;
using SpanishPoint.MatchingEngine.Tests.Configuration;

namespace SpanishPoint.MatchingEngine.Tests.Hooks;

[Binding]
public class InitialSetupHooks
{

    [BeforeTestRun(Order = 0)]
    public static void CreateConfig(IObjectContainer objectContainer)
    {
        IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        using var disposable = (IDisposable)config;

        var testConfig = config.GetSection("Test").Get<TestConfig>() ?? throw new InvalidOperationException("Test configuration missing");

        objectContainer.RegisterInstanceAs<ITestConfig>(testConfig);

    }
}
