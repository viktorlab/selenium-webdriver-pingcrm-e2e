using NUnit.Framework;
using selenium_project.Pages;

namespace selenium_project.Test
{
    public class ContactTests : BaseTest
    {
        [Test]
        public void RenderContactsTable()
        {
            var contactsPage = new ContactsPage(WebDriver);
            contactsPage.NavigateToContactsPage();

            var contactsTable = contactsPage.GetContactsTable();

            Assert.AreEqual(true, contactsTable.Displayed);
        }

        [Test]
        public void ContactsTableIsNotEmpty()
        {
            var contactsPagePage = new ContactsPage(WebDriver);
            contactsPagePage.NavigateToContactsPage();

            var common = new CommonElements(WebDriver);
            var contactsTable = common.GetTableRows();

            Assert.Greater(contactsTable.Count, 1);
        }

        [Test]
        public void ContactsTableHasColumns()
        {
            var contactsPage = new ContactsPage(WebDriver);
            contactsPage.NavigateToContactsPage();

            var common = new CommonElements(WebDriver);
            var columns = common.GetTableHeaders();

            Assert.AreEqual(4, columns.Count);
        }

        [Test]
        public void ShowSingleOrganization()
        {
            var contactsPage = new ContactsPage(WebDriver);
            contactsPage.NavigateToContactsPage();

            var firstRecord = contactsPage.GetFirstElementFromContactsTable();
            firstRecord.Click();

            var contactsTitle = contactsPage.GetContactsTitle();

            Assert.AreEqual("Contacts/ Aditya Abernathy", contactsTitle.Text);
        }

        [Test]
        public void ContactCanBeUpdated()
        {
            var contactsPage = new ContactsPage(WebDriver);
            contactsPage.NavigateToContactsPage();

            var firstRecord = contactsPage.GetFirstElementFromContactsTable();
            firstRecord.Click();

            var submitUpdateContact = contactsPage.GetContactsUpdateSubmitButton();
            submitUpdateContact.Click();

            var common = new CommonElements(WebDriver);
            var successMessage = common.GetFlashMessage();

            Assert.AreEqual("Contact updated.", successMessage.Text);
        }

        [Test]
        public void ShouldRenderCreateContactView()
        {
            var contactsPage = new ContactsPage(WebDriver);
            contactsPage.NavigateToContactsPage();

            var createContactButton = contactsPage.GetContactsCreateViewButton();
            createContactButton.Click();

            var createContactsTitle = contactsPage.GetCreateContactsTitle();

            Assert.AreEqual("Contacts/ Create", createContactsTitle.Text);
        }

        [Test]
        public void ShouldTriggerValidations()
        {
            var contactsPage = new ContactsPage(WebDriver);
            contactsPage.NavigateToContactsPage();

            var createOrganizationButton = contactsPage.GetContactsCreateViewButton();
            createOrganizationButton.Click();

            var submitOrganizationButton = contactsPage.GetContactsCreateSubmitButton();
            submitOrganizationButton.Click();

            var common = new CommonElements(WebDriver);
            var errorMessages = common.GetFormErrors();

            Assert.AreEqual(2, errorMessages.Count);
        }
    }
}