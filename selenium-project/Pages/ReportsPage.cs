using OpenQA.Selenium;

namespace selenium_project.Pages
{
    public class ReportsPage
    {
        private WebDriver _webDriver { get; set; } = null!;

        public ReportsPage(WebDriver Driver)
        {
            _webDriver = Driver;
        }

        public void NavigateToReportsPage(string slug)
        {
            _webDriver.Navigate().GoToUrl("https://whale-app-8lpe3.ondigitalocean.app/login");
            
            var input = _webDriver.FindElement(By.Id("email_field"));
            input.Clear();
            input.SendKeys("johndoe@example.com");
            
            input = _webDriver.FindElement(By.Id("password_field"));
            input.Clear();
            input.SendKeys("secret");
            
            input = _webDriver.FindElement(By.Id("login_submit"));
            input.Click();
            
            input = _webDriver.FindElement(By.Id("report_menu_item"));
            input.Click();
        }

        public IWebElement GetReportsTitle()
        {
            return _webDriver.FindElement(By.Id("reports_title"));
        }
    }
}