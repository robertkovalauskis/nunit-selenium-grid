using Microsoft.Extensions.Configuration;
using nunit_selenium.Core;
using OpenQA.Selenium;

namespace nunit_selenium.Utils
{
    public class Utils : PageBase
    {
        private static Random _rnd = new Random();

        public static void UploadFileOnRemoteMachine(IWebElement webElement, string file)
        {
            /* make sure that the Local file detector is enabled (in the TestBase.cs)
            for more info check Selenium documentation (Remote Web Driver) */

            webElement.SendKeys(file);
            Console.WriteLine("File path is: " + file);
        }

        public static string GenerateRandomEmail(int length)
        {
            string generatedString = GenerateRandomStringWithoutSpecialChar(length);
            generatedString += "@dummy.com";
            return generatedString;
        }

        public static string GenerateRandomNumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(1111111, 99999999);
            return number.ToString();
        }

        public static string GenerateRandomString(int length)
        {
            int charSpecial;
            char[] chars = GenerateRandomStringWithoutSpecialChar(length).ToCharArray();
            charSpecial = _rnd.Next(223, 256);
            chars[length - 1] = Convert.ToChar(charSpecial);
            string generatedString = new string(chars);
            return generatedString;
        }

        public static string GenerateRandomPassword(int length)
        {
            string password;
            string specialChar;
            int randomDigit;
            password = GenerateRandomString(length);
            specialChar = "!@";
            randomDigit = _rnd.Next(1, 9);
            password = password + randomDigit + specialChar;
            return password;
        }

        private static string GenerateRandomStringWithoutSpecialChar(int length)
        {
            int charCaps;
            int charSmall;
            char[] chars = new char[length];
            string generatedString;
            charCaps = _rnd.Next(65, 91);
            chars[0] = Convert.ToChar(charCaps);
            for (int i = 1; i < (length - 1); i++)
            {
                charSmall = _rnd.Next(97, 123);
                chars[i] = Convert.ToChar(charSmall);
            }

            generatedString = new string(chars);
            return generatedString;
        }

        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("(yyyy MMMM dd - HH:mm)");
        }

        public string GetDepartmentNameFromConfig()
        {
            string companyName = config.GetValue<string>("CompanyName");
            return companyName;
        }

        public void FillIframe(IWebDriver driver, string iframe, IWebElement element, string text)
        {
            driver.SwitchTo().Frame(iframe);
            element.SendKeys(text);
            driver.SwitchTo().DefaultContent();
        }

        public static bool GetHeaders(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string ChromeLastDownloadedFileName(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open('');");
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Navigate().GoToUrl("chrome://downloads/");
            IWebElement root1 = driver.FindElement(By.TagName("downloads-manager"));
            IWebElement shadow1 = driver.AllocateShadowDOMIWebElement(root1);
            IWebElement root2 = shadow1.FindElement(By.CssSelector("downloads-item"));
            IWebElement shadow2 = driver.AllocateShadowDOMIWebElement(root2);
            IWebElement file = shadow2.FindElement(By.Id("file-link"));
            string filename = file.Text.ToString();
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);

            return filename;
        }
    }
}