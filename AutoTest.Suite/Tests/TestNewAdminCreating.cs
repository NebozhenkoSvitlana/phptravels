using AutoTest.Suite.Models;
using NUnit.Framework;

namespace AutoTest.Suite.Tests
{
    [TestFixture]
    public class TestNewAdminCreating : TestBase
    {
        private string adminPortalUserName;
        private string adminPortalUserPassword;

        public TestNewAdminCreating()
        {
            adminPortalUserName = "admin@phptravels.com";
            adminPortalUserPassword = "demoadmin";
        }

        [SetUp]
        public void OnTestMethodStart()
        {
            Navigator.GoToPHPTravelsAdminPage();
            Pages.LoginPage.LoginToAdminPortal(adminPortalUserName, adminPortalUserPassword);
            Navigator.GoToAdminAccounts();
        }

        [Test]
        public void CheckFourthLineOfSearchResultInGoogle()
        {
            //Arrange
            var newAdmin = AdminAccountMapper.GetOnlyRequiredFieldsNewAdminDto();
            var newMainSettings = MainSettingsMapper.GetMainSettingsDto();
            int countOfAdminsBefore = Pages.AdminAccountsPage.GetCountOfAdminInList();

            //Act
            Pages.AdminAccountsPage.ClickOnAddNewAdminButton();
            Pages.AdminAccountsPage.addAdminSection.adminItem.SetOnlyRequiredFields(newAdmin.FirstName, newAdmin.LastName, newAdmin.Email, newAdmin.Password, newAdmin.Country);
            Pages.AdminAccountsPage.mainSettinsSection.SetComissionField(newMainSettings.Comission);
            Pages.AdminAccountsPage.mainSettinsSection.SetStatusField(newMainSettings.Status);
            Pages.AdminAccountsPage.mainSettinsSection.AddSection.SetRandomPermissionOptions(newMainSettings.CountOfAdd);
            Pages.AdminAccountsPage.mainSettinsSection.EditSection.SetRandomPermissionOptions(newMainSettings.CountOfEdit);
            Pages.AdminAccountsPage.mainSettinsSection.DeleteSection.SetRandomPermissionOptions(newMainSettings.CountOfDelete);
            Pages.AdminAccountsPage.addAdminSection.ClickOnSaveNewAdminButton();
            int countOfAdminsAfter = Pages.AdminAccountsPage.GetCountOfAdminInList();

            //Assert  
            string createdAdminData = Pages.AdminAccountsPage.CreatedAdminDataInList();
            Assert.Multiple(() =>
            {
                Assert.That(countOfAdminsAfter - countOfAdminsBefore == 1, Is.True, "Amount of admin items was increased");
                Assert.That(createdAdminData.Contains(newAdmin.FirstName), Is.True, "New admin in list contains correct FirstName");
                Assert.That(createdAdminData.Contains(newAdmin.LastName),  Is.True, "New admin in list contains correct LastName");
                Assert.That(createdAdminData.Contains(newAdmin.Email),     Is.True, "New admin in list contains correct Email");
            });

            //Cleanup
            Pages.AdminAccountsPage.RemoveLastCreatedAdmin();
            Navigator.AcceptAlert();
            Pages.LoginPage.WaitBuyButtonVisible();
            int countOfAdminsAfterCleaUp = Pages.AdminAccountsPage.GetCountOfAdminInList();
            Assert.That(countOfAdminsAfter - countOfAdminsAfterCleaUp  == 1, Is.True);
            Assert.That(countOfAdminsAfterCleaUp - countOfAdminsBefore == 0, Is.True);
            Navigator.Logout();
        }
    }
}
