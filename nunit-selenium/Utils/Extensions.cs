using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace nunit_selenium.Utils
{
    public static class Extensions
    {
        private static readonly int Timeout = 10;

        public static void WaitForNavigation(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeout));
            wait.Until(driver1 =>
                ((IJavaScriptExecutor)driver1).ExecuteScript("return document.readyState").Equals("complete"));
        }


        public static IWebElement WaitForPageUntilElementIsClickable(this IWebDriver driver, By locator)
        {
            driver.WaitForNavigation();
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Timeout))
                .Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static IWebElement WaitForPageUntilIElementIsVisible(this IWebDriver driver, By element)
        {
            driver.WaitForNavigation();
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Timeout))
                .Until(ExpectedConditions.ElementIsVisible(element));
        }

        public static IWebElement WaitForPageUntilIWebElementIsClickable(this IWebDriver driver, IWebElement element)
        {
            driver.WaitForNavigation();
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Timeout))
                .Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitUntilTextValueHasChanged(this IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string initialText = element.Text;
            
            wait.Until((d) =>
            {
                string currentText = element.Text;
                return !currentText.Equals(initialText);
            });
        }


        public static IWebElement WaitForPageUntilIWebElementIsClickable(this IWebDriver driver, IWebElement element,
            int setTimeout)
        {
            driver.WaitForNavigation();
            return new WebDriverWait(driver, TimeSpan.FromSeconds(setTimeout))
                .Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static bool TextIsPresentInIwebElementsValue(this IWebDriver driver, IWebElement element, string text)
        {
            driver.WaitForNavigation();
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Timeout))
                .Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
        }

        public static IWebElement FindElementFor(this IWebDriver driver, int timeoutInSeconds, By locator)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }

            return driver.FindElement(locator);
        }

        public static void WaitUntilElementDisappeared(this IWebDriver driver, By by)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public static IWebElement AllocateShadowDOMIWebElement(this IWebDriver driver, IWebElement element)
        {
            IWebElement shadow =
                (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].shadowRoot", element);
            return shadow;
        }
    }
}