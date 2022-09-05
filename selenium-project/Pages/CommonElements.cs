using OpenQA.Selenium;

namespace selenium_project.Pages
{
    public class CommonElements
    {
        private WebDriver _webDriver { get; set; } = null!;

        public CommonElements(WebDriver driver)
        {
            _webDriver = driver;
        }

        public IReadOnlyCollection<IWebElement> GetTableRows()
        {
            return _webDriver.FindElements(By.CssSelector("tr"));
        }

        public IReadOnlyCollection<IWebElement> GetTableHeaders()
        {
            return _webDriver.FindElements(By.CssSelector("th"));
        }

        public IWebElement GetFlashMessage()
        {
            return _webDriver.FindElement(By.Id("flash_message"));
        }
        
        public IReadOnlyCollection<IWebElement> GetFormErrors()
        {
            return _webDriver.FindElements(By.ClassName("form-error"));
        }
    }
}