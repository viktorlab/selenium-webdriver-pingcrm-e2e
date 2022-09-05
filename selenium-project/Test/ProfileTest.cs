using NUnit.Framework;
using selenium_project.Pages;

namespace selenium_project.Test
{
    public class ProfileTests : BaseTest
    {
        private readonly string _baseUrl = Constants.Constants.BaseUrl;

        [Test]
        public void RenderProfileView()
        {
            var profilePage = new ProfilePage(WebDriver);
            profilePage.NavigateToProfilePage(_baseUrl);

            var profileTitle = profilePage.GetProfileTitle();
            Assert.AreEqual("Users/ John Doe", profileTitle.Text);
        }

        [Test]
        public void CanUpdateProfile()
        {
            var profilePage = new ProfilePage(WebDriver);
            profilePage.NavigateToProfilePage(_baseUrl);

            var updateProfileButton = profilePage.GetUpdateProfileButton();
            updateProfileButton.Click();

            var common = new CommonElements(WebDriver);
            var successMessage = common.GetFlashMessage();
            Assert.AreEqual("User updated.", successMessage.Text);
        }
    }
}