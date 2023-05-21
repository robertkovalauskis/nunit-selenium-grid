using Microsoft.Extensions.Configuration;
using nunit_selenium.Core;
using nunit_selenium.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

#pragma warning disable CS8618

namespace nunit_selenium.Pages
{
    public class LoginPage : PageBase
    {
        [FindsBy(How = How.Id, Using = "company")]
        public IWebElement Company { get; private set; }

        [FindsBy(How = How.Id, Using = "identity")]
        public IWebElement UserName { get; private set; }

        [FindsBy(How = How.Id, Using = "credential")]
        public IWebElement Password { get; private set; }

        [FindsBy(How = How.Id, Using = "signinButton")]
        public IWebElement ContinueButton { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#primary-box > div.box-error > span")]
        public IWebElement ErrorMsg { get; private set; }

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage Login()
        {
            NavigateTo();
            TypeCompany();
            ContinueButton.Click();
            Driver.WaitForNavigation();
            TypeUserName();
            TypePassword();
            ContinueButton.Click();
            Driver.WaitForNavigation();
            return this;
        }

        public LoginPage LoginWithNewUser(string username, string password = null)
        {
            NavigateTo();
            TypeCompany();
            ContinueButton.Click();
            TypeUserName(username);
            TypePassword(password);
            ContinueButton.Click();

            return this;
        }

        private void TypePassword(string pwd)
        {
            var password = String.IsNullOrEmpty(pwd) ? config.GetValue<string>("Password") : pwd;
            Password.SendKeys(password);
            Console.WriteLine("Password is: " + password);
        }

        private void TypeUserName(string username)
        {
            UserName.SendKeys(username);
        }

        private void NavigateTo()
        {
            string base_url = config.GetValue<string>("ApplicationBaseUrl");
            Driver.Navigate().GoToUrl(base_url);
            Console.WriteLine("ApplicationBaseUrl is: " + config.GetValue<string>("ApplicationBaseUrl"));
        }

        private void TypeCompany()
        {
            string company_url = config.GetValue<string>("ClientLoginName");
            Company.SendKeys(company_url);
        }

        private void TypeUserName()
        {
            string username = config.GetValue<string>("EasycruitUsername");
            Console.WriteLine("EasycruitUsername is: " + username);
            Driver.WaitForPageUntilIWebElementIsClickable(UserName);
            UserName.SendKeys(username);
        }

        private LoginPage TypePassword()
        {
            string password = config.GetValue<string>("Password");
            Driver.WaitForPageUntilIWebElementIsClickable(Password);
            Password.SendKeys(password);
            return this;
        }
    }
}