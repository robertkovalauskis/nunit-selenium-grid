using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace nunit_selenium.Core
{
    public abstract class PageBase : TestBase
    {
        public PageBase(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        protected PageBase()
        {
        }
    }
}