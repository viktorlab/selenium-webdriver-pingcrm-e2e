using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_project.Test
{
    public class BaseTest
    {
        protected WebDriver WebDriver { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            WebDriver = GetChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.Quit();
        }

        private WebDriver GetChromeDriver()
        {
            return new ChromeDriver();
        }
    }
}