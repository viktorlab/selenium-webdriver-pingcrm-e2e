using OpenQA.Selenium;

namespace selenium_project.Pages
{
    public class HomePage
    {
        private WebDriver _webDriver { get; set; } = null!;

        public HomePage(WebDriver Driver)
        {
            _webDriver = Driver;
        }


        public IWebElement GetDashboardHeader()
        {
            return _webDriver.FindElement(By.Id("dashboard_header"));
        }

        public IWebElement GetUserFirstName()
        {
            return _webDriver.FindElement(By.Id("user_first_name"));
        }

        public IWebElement GetHeaderDropdown()
        {
            return _webDriver.FindElement(By.Id("header_dropdown"));
        }

        public IWebElement GetLogoutButton()
        {
            return _webDriver.FindElement(By.Id("logout_button"));
        }
    }
}