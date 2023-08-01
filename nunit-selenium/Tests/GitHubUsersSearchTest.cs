using Allure.Net.Commons;
using nunit_selenium.Core;
using nunit_selenium.Pages;
using nunit_selenium.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace nunit_selenium.Tests;

[TestFixture]
[AllureNUnit]
public class GitHubUsersSearchTest : TestBase
{
    private GitHubUserSearchPage _gitHubUserSearchPage;
    
    [SetUp]
    public void InitializePageObjects()
    {
        _gitHubUserSearchPage = new GitHubUserSearchPage(Driver);
    }
    
    [Test]
    [Category("Smoke")]
    [AllureTag("Smoke")]
    [AllureSuite("Smoke tests")]
    [AllureSeverity(SeverityLevel.normal)]
    public void GitHubUsersSearch()
    {
        Driver.Navigate().GoToUrl(Constants.GITHUB_USER_SEARCH_URL);
        _gitHubUserSearchPage.FindUserByUsername("robertkovalauskis");

        Driver.WaitUntilTextValueHasChanged(_gitHubUserSearchPage.userName);
        Assert.That(_gitHubUserSearchPage.userName.Text, Is.EqualTo("Roberts Kovalauskis"));
    }
}