using OpenQA.Selenium;

namespace selenium_project.Pages
{
    public class LoginPage
    {
        private WebDriver _webDriver { get; set; } = null!;

        public LoginPage(WebDriver Driver)
        {
            _webDriver = Driver;
        }

        public void NavigateToLoginPage(string slug)
        {
            _webDriver.Navigate().GoToUrl(slug);
        }

        public IWebElement GetLoginTitle()
        {
            return _webDriver.FindElement(By.Id("login_title"));
        }

        public IWebElement GetEmailField()
        {
            return _webDriver.FindElement(By.Id("email_field"));
        }

        public IWebElement GetPasswordField()
        {
            return _webDriver.FindElement(By.Id("password_field"));
        }

        public IWebElement GetLoginSubmitButton()
        {
            return _webDriver.FindElement(By.Id("login_submit"));
        }

        public IWebElement GetLoginFormError()
        {
            return _webDriver.FindElement(By.ClassName("form-error"));
        }
    }
}