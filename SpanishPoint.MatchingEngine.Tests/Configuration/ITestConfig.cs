using System;
using System.Collections.Generic;
using System.Text;

namespace SpanishPoint.MatchingEngine.Tests.Configuration;

public interface ITestConfig
{
    string TestBrowser { get; }
    string BaseUrl { get; }
}
