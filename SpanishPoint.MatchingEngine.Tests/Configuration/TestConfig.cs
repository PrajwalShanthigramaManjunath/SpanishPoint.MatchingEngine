namespace SpanishPoint.MatchingEngine.Tests.Configuration;

public sealed class TestConfig : ITestConfig
{
    public string TestBrowser { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
}
