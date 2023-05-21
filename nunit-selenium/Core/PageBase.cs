using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace nunit_selenium.Core
{
    public abstract class PageBase
    {
        static string[] args = null;

        // Use ASPNETCORE_ENVIRONMENT env variable to choose env for test execution
        private static IHost host = Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((context, builder) =>
        {
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    optional: true,
                    reloadOnChange: true)
                .AddEnvironmentVariables();
        }).Build();

        // initialize IConfiguration to retrieve parameters from appsettings.json files
        protected IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

        protected readonly IWebDriver Driver;

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