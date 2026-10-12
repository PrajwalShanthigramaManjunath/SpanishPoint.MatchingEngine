using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpanishPoint.MatchingEngine.Tests.Browser;

namespace SpanishPoint.MatchingEngine.Tests.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(IBrowserManager browserManager)
    {
        Driver = browserManager.WebDriver;
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
    }

    protected void WaitForPageToLoad(By locator)
    {
        Wait.Until(driver =>
            driver.FindElement(locator).Displayed);
    }
}