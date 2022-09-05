using NUnit.Framework;
using selenium_project.Pages;

namespace selenium_project.Test
{
    public class OrganizationTests : BaseTest
    {
        [Test]
        public void RenderOrganizationsTable()
        {
            var organizationsPage = new OrganizationsPage(WebDriver);
            organizationsPage.NavigateToOrganizationsPage();

            var organizationsTable = organizationsPage.GetOrganizationsTable();
            Assert.AreEqual(true, organizationsTable.Displayed);
        }

        [Test]
        public void OrganizationsTableIsNotEmpty()
        {
            var organizationsPage = new OrganizationsPage(WebDriver);
            organizationsPage.NavigateToOrganizationsPage();
            
            var common = new CommonElements(WebDriver);
            var organizationsTable = common.GetTableRows();
            
            Assert.Greater(organizationsTable.Count, 1);
        }

        [Test]
        public void OrganizationsTableHasColumns()
        {
            var organizationsPage = new OrganizationsPage(WebDriver);
            organizationsPage.NavigateToOrganizationsPage();

            var common = new CommonElements(WebDriver);
            var columns = common.GetTableHeaders();

            Assert.AreEqual(3, columns.Count);
        }

        [Test]
        public void ShowSingleOrganization()
        {
            var organizationPage = new OrganizationsPage(WebDriver);
            organizationPage.NavigateToOrganizationsPage();

            var firstRecord = organizationPage.GetFirstElementFromOrganizationsTable();
            firstRecord.Click();

            var organizationTitle = organizationPage.GetOrganizationsTitle();
            
            Assert.AreEqual("Organizations/ Baumbach PLC", organizationTitle.Text);
        }

        [Test]
        public void OrganizationCanBeUpdated()
        {
            var organizationPage = new OrganizationsPage(WebDriver);
            organizationPage.NavigateToOrganizationsPage();

            var firstRecord = organizationPage.GetFirstElementFromOrganizationsTable();
            firstRecord.Click();

            var submitUpdateOrganization = organizationPage.GetUpdateOrganizationButton();
            submitUpdateOrganization.Click();

            var common = new CommonElements(WebDriver);
            var successMessage = common.GetFlashMessage();

            Assert.AreEqual("Organization updated.", successMessage.Text);
        }

        [Test]
        public void RelatedContactShouldBeDisplayed()
        {
            var organizationPage = new OrganizationsPage(WebDriver);
            organizationPage.NavigateToOrganizationsPage();

            var firstRecord = organizationPage.GetFirstElementFromOrganizationsTable();
            firstRecord.Click();

            var organizationContactsTable = organizationPage.GetFirstElementFromOrganizationContactsTable();

            Assert.AreEqual("Harmony Reinger", organizationContactsTable.Text);
        }

        [Test]
        public void ShouldRenderCreateOrganizationView()
        {
            var organizationPage = new OrganizationsPage(WebDriver);
            organizationPage.NavigateToOrganizationsPage();

            var createOrganizationButton = organizationPage.GetCreateOrganizationViewButton();
            createOrganizationButton.Click();

            var createOrganizationsTitle = organizationPage.GetOrganizationCreateTitle();

            Assert.AreEqual("Organizations/ Create", createOrganizationsTitle.Text);
        }

        [Test]
        public void ShouldTriggerValidations()
        {
            var organizationPage = new OrganizationsPage(WebDriver);
            organizationPage.NavigateToOrganizationsPage();

            var createOrganizationButton = organizationPage.GetCreateOrganizationViewButton();
            createOrganizationButton.Click();

            var submitOrganizationButton = organizationPage.GetCreateOrganizationButton();
            submitOrganizationButton.Click();

            var common = new CommonElements(WebDriver);
            var errorMessage = common.GetFormErrors();

            Assert.AreEqual(1, errorMessage.Count);
        }
    }
}