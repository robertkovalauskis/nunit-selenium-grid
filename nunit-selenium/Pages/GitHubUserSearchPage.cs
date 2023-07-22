using nunit_selenium.Core;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace nunit_selenium.Pages;

public class GitHubUserSearchPage : PageBase
{
    public GitHubUserSearchPage(IWebDriver driver) : base(driver)
    {
    }

    public GitHubUserSearchPage()
    {
    }

    [FindsBy(How = How.CssSelector, Using = "input[data-testid='search-bar']")]
    public IWebElement searchField { get; private set; }
    
    [FindsBy(How = How.XPath, Using = "//button[text()[contains(.,'search')]]")]
    public IWebElement searchButton { get; private set; }
    
    [FindsBy(How = How.XPath, Using = "//div//h4")]
    public IWebElement userName { get; private set; }

    public void FindUserByUsername(String username)
    {
        searchField.SendKeys(username);
        searchButton.Click();
    }
    
}