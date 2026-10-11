using System;
using System.Collections.Generic;
using System.Text;

namespace SpanishPoint.MatchingEngine.Tests.Configuration;

public sealed class TestConfig : ITestConfig
{
    public string TestBrowser { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
}
