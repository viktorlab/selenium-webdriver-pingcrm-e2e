using OpenQA.Selenium;

namespace selenium_project.Pages
{
    public class OrganizationsPage
    {
        private WebDriver _webDriver { get; set; } = null!;
        private readonly string _baseUrl = Constants.Constants.BaseUrl;

        public OrganizationsPage(WebDriver Driver)
        {
            _webDriver = Driver;
        }

        public void NavigateToOrganizationsPage()
        {
            _webDriver.Navigate().GoToUrl($"{_baseUrl}/login");

            var input = _webDriver.FindElement(By.Id("email_field"));
            input.Clear();
            input.SendKeys("johndoe@example.com");

            input = _webDriver.FindElement(By.Id("password_field"));
            input.Clear();
            input.SendKeys("secret");

            input = _webDriver.FindElement(By.Id("login_submit"));
            input.Click();

            input = _webDriver.FindElement(By.Id("organization_menu_item"));
            input.Click();
        }

        public IWebElement GetOrganizationsTable()
        {
            return _webDriver.FindElement(By.Id("organizations_table"));
        }

        public IWebElement GetFirstElementFromOrganizationsTable()
        {
            return _webDriver.FindElement(By.CssSelector("#organization_table_body > tr:nth-child(1)"));
        }
        
        public IWebElement GetFirstElementFromOrganizationContactsTable()
        {
            return _webDriver.FindElement(By.CssSelector("#organization_contacts_table > tr:nth-child(2) > td:nth-child(1)"));
        }

        public IWebElement GetOrganizationsTitle()
        {
            return _webDriver.FindElement(By.Id("organization_title"));
        }

        public IWebElement GetUpdateOrganizationButton()
        {
            return _webDriver.FindElement(By.Id("submit_update_organization"));
        }
        
        public IWebElement GetCreateOrganizationButton()
        {
            return _webDriver.FindElement(By.Id("submit_organization_button"));
        }
        
        public IWebElement GetCreateOrganizationViewButton()
        {
            return _webDriver.FindElement(By.Id("create_organization_button"));
        }

        public IWebElement GetOrganizationCreateTitle()
        {
            return _webDriver.FindElement(By.Id("create_organizations_title"));
        }
    }
}