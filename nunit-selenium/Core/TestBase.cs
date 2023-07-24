using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace nunit_selenium.Core;

public class TestBase
{
    protected IWebDriver Driver;

    [SetUp]
    public void SetupDriver()
    {
        /* Choose WebDriver initialization method */
        SetupDriverToRunTestsOnSeleniumGrid();
        // SetupDriverToRunTestsLocally();
    }

    [TearDown]
    public void QuitBrowser()
    {
        Driver.Quit();
    }

    /* DON'T delete this method */
    public void SetupDriverToRunTestsLocally()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
    }

    /* DON'T delete this method */
    public void SetupDriverToRunTestsOnSeleniumGrid()
    {
        string host = "localhost";
        DriverOptions options;

        if (Environment.GetEnvironmentVariable("BROWSER") != null &&
            Environment.GetEnvironmentVariable("BROWSER")
                .Equals("firefox", StringComparison.OrdinalIgnoreCase))
        {
            options = new FirefoxOptions();
        }
        else
        {
            options = new ChromeOptions(); // use Chrome by default
        }

        if (Environment.GetEnvironmentVariable("HUB_HOST") != null)
        {
            host = Environment.GetEnvironmentVariable("HUB_HOST");
        }

        string completeUrl = "http://" + host + ":4444/wd/hub";

        // RemoteWebDriver doesn't know what browser we need to use 
        // that's why we specify options (DriverOptions) 
        Driver = new RemoteWebDriver(new Uri(completeUrl), options);

        /* The Local File Detector allows the transfer of files
        from the client machine to the remote server. */
        var allowsDetection = Driver as IAllowsFileDetection;
        if (allowsDetection != null)
        {
            allowsDetection.FileDetector = new LocalFileDetector();
        }

        Driver.Manage().Window.Maximize();
    }
}