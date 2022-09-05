using NUnit.Framework;
using selenium_project.Pages;

namespace selenium_project.Test
{
    public class ReportTests : BaseTest
    {
        private readonly string _baseUrl = Constants.Constants.BaseUrl;

        [Test]
        public void RenderReportsView()
        {
            var reportsPage = new ReportsPage(WebDriver);
            reportsPage.NavigateToReportsPage($"{_baseUrl}/reports");

            var reportsTitle = reportsPage.GetReportsTitle();
            Assert.AreEqual("Reports", reportsTitle.Text);
        }
    }
}