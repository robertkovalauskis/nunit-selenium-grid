using Allure.Net.Commons;
using nunit_selenium.Core;
using nunit_selenium.Pages;
using nunit_selenium.Utils;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace nunit_selenium.Tests;

[TestFixture]
public class GitHubUsersSearchTest : TestBase
{
    private GitHubUserSearchPage _gitHubUserSearchPage;
    
    [SetUp]
    public new void InitializePageObjects()
    {
        _gitHubUserSearchPage = new GitHubUserSearchPage(Driver);
    }
    
    [AllureEpic("Epic Name")]
    [AllureFeature("Feature Name")]
    [AllureStory("User Story Name")]
    [AllureSeverity(SeverityLevel.normal)]
    [Test]
    [Category("Smoke")]
    public void GitHubUsersSearch()
    {
        Driver.Navigate().GoToUrl(Constants.GITHUB_USER_SEARCH_URL);
        _gitHubUserSearchPage.FindUserByUsername("robertkovalauskis");

        Driver.WaitUntilTextValueHasChanged(_gitHubUserSearchPage.userName);
        Assert.That(_gitHubUserSearchPage.userName.Text, Is.EqualTo("Roberts Kovalauskis"));
    }
}