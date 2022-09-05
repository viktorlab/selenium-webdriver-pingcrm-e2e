using NUnit.Framework;
using selenium_project.Pages;

namespace selenium_project.Test
{
    public class AuthenticationTests : BaseTest
    {
        private readonly string _baseUrl = Constants.Constants.BaseUrl;

        [Test]
        public void LoginFailedTest()
        {
            var loginPage = new LoginPage(WebDriver);
            loginPage.NavigateToLoginPage($"{_baseUrl}/login");
            
            var emailField = loginPage.GetEmailField();
            emailField.Clear();
            emailField.SendKeys("test@test.com");
            
            var passwordField = loginPage.GetPasswordField();
            passwordField.Clear();
            passwordField.SendKeys("test");
            
            var submitButton = loginPage.GetLoginSubmitButton();
            submitButton.Click();

            var loginFormError = loginPage.GetLoginFormError();
            Assert.AreEqual("These credentials do not match our records.", loginFormError.Text);
        }

        [Test]
        public void LoginSuccessTest()
        {
            var loginPage = new LoginPage(WebDriver);
            loginPage.NavigateToLoginPage($"{_baseUrl}/login");
            
            var emailField = loginPage.GetEmailField();
            emailField.Clear();
            emailField.SendKeys("johndoe@example.com");
            
            var passwordField = loginPage.GetPasswordField();
            passwordField.Clear();
            passwordField.SendKeys("secret");
            
            var submitButton = loginPage.GetLoginSubmitButton();
            submitButton.Click();
            
            var homePage = new HomePage(WebDriver);

            var dashboardHeader = homePage.GetDashboardHeader();
            Assert.AreEqual("Dashboard", dashboardHeader.Text);

            var userFirstName = homePage.GetUserFirstName();
            Assert.AreEqual("John", userFirstName.Text);
        }

        [Test]
        public void LogoutSuccessTest()
        {
            var loginPage = new LoginPage(WebDriver);
            loginPage.NavigateToLoginPage($"{_baseUrl}/login");
            
            var emailField = loginPage.GetEmailField();
            emailField.Clear();
            emailField.SendKeys("johndoe@example.com");
            
            var passwordField = loginPage.GetPasswordField();
            passwordField.Clear();
            passwordField.SendKeys("secret");
            
            var submitButton = loginPage.GetLoginSubmitButton();
            submitButton.Click();
            
            var homePage = new HomePage(WebDriver);
            var headerDropdown = homePage.GetHeaderDropdown();
            headerDropdown.Click();

            var logOutButton = homePage.GetLogoutButton();
            logOutButton.Click();

            Assert.AreEqual("Welcome Back!", loginPage.GetLoginTitle().Text);
        }
    }
}