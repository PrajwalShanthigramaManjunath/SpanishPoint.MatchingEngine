using OpenQA.Selenium;
using SpanishPoint.MatchingEngine.Tests.Browser;

namespace SpanishPoint.MatchingEngine.Tests.Pages;

public class DistributionProcessingPage : BasePage
{
    private readonly By _distributionProcessingPageHeadingLocator =
        By.XPath("//h2[normalize-space()='Distribution processing']");

    //Only distribution-processing-overview section has an ID, so locating them by their headings for consistency.
    private IWebElement GetSection(string sectionName) =>
    Driver.FindElement(By.XPath(
        $"//section[.//h2[normalize-space()='{sectionName}']]"));


    public DistributionProcessingPage(
        IBrowserManager browserManager) : base(browserManager)
    {

    }

    public void ScrollToDistributionProcessingSection(string sectionName)
    {
        WaitForPageToLoad(_distributionProcessingPageHeadingLocator);

        var section = Wait.Until(_ => GetSection(sectionName));

        ((IJavaScriptExecutor)Driver).ExecuteScript(
            "arguments[0].scrollIntoView({block: 'center'});", section);
    }

    public string GetSectionContent(string sectionName)
    {
        var section = GetSection(sectionName);
        return section.Text;
    }
}
