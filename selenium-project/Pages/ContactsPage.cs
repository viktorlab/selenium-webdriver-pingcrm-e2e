using OpenQA.Selenium;

namespace selenium_project.Pages
{
    public class ContactsPage
    {
        private WebDriver _webDriver { get; set; } = null!;
        private readonly string _baseUrl = Constants.Constants.BaseUrl;

        public ContactsPage(WebDriver driver)
        {
            _webDriver = driver;
        }

        public void NavigateToContactsPage()
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
            
            input = _webDriver.FindElement(By.Id("contact_menu_item"));
            input.Click();
        }

        public IWebElement GetContactsTable()
        {
            return _webDriver.FindElement(By.Id("contacts_table"));
        }

        public IWebElement GetFirstElementFromContactsTable()
        {
            return _webDriver.FindElement(By.CssSelector("#contacts_table > tr:nth-child(2)"));
        }

        public IWebElement GetContactsTitle()
        {
            return _webDriver.FindElement(By.Id("contacts_title"));
        }
        
        public IWebElement GetContactsUpdateSubmitButton()
        {
            return _webDriver.FindElement(By.Id("submit_update_contact"));
        }
        
        public IWebElement GetContactsCreateSubmitButton()
        {
            return _webDriver.FindElement(By.Id("submit_contact_button"));
        }
        
        public IWebElement GetContactsCreateViewButton()
        {
            return _webDriver.FindElement(By.Id("create_contact_button"));
        }
        
        public IWebElement GetCreateContactsTitle()
        {
            return _webDriver.FindElement(By.Id("create_contacts_title"));
        }
    }
}