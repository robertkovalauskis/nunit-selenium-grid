using OpenQA.Selenium;

namespace nunit_selenium.Utils
{
    public static class WebElementExt
    {
        /// <summary>WebElement extension methods for dropdown.</summary>
        public static DropdownUtils Dropdown(this IWebElement element)
        {
            return new DropdownUtils(element);
        }
    }
}