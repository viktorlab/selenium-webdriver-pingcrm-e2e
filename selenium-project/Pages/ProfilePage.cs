using OpenQA.Selenium;

namespace selenium_project.Pages
{
    public class ProfilePage
    {
        private WebDriver _webDriver { get; set; } = null!;

        public ProfilePage(WebDriver Driver)
        {
            _webDriver = Driver;
        }

        public void NavigateToProfilePage(string slug)
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
            
            input = _webDriver.FindElement(By.Id("header_dropdown"));
            input.Click();
            
            input = _webDriver.FindElement(By.Id("my_profile"));
            input.Click();
        }

        public IWebElement GetProfileTitle()
        {
            return _webDriver.FindElement(By.Id("profile_title"));
        }
        
        public IWebElement GetUpdateProfileButton()
        {
            return _webDriver.FindElement(By.Id("update_profile"));
        }
    }
}