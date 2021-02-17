using AutoTest.Suite.Utilities;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace AutoTest.Suite.Pages
{
    public class AdminAccountsPage : PageBase
    {
        private const string AddNewAdminButtonXPath = "//button[@type='submit']";
        private WebElement AddNewAdminButton => GetByXPath(AddNewAdminButtonXPath);

        private const string RemoveSelectedAdminsButtonId = "deleteAll";
        private WebElement RemoveSelectedAdminsButton => GetById(RemoveSelectedAdminsButtonId);

        private const string AdminListRowsXPath = "//tbody/tr";
        private IList<WebElement> AdminListRows => GetElementsByXPath(AdminListRowsXPath);

        private const string AdminListCheckboxesXPath = "//input[@class='checkboxcls']";
        private IList<WebElement> AdminListCheckboxes => GetElementsByXPath(AdminListCheckboxesXPath);

        private const string EmptyListStateXPath = "//td[contains(text(), 'Entries not found.')]";
        private WebElement EmptyListState => GetByXPath(EmptyListStateXPath);

        private string CreatedAdminColumnXPath(string adminEmail) => $"//td[contains(., '{adminEmail})]";
        private WebElement CreatedAdminColumn(string adminEmail) => GetByXPath(CreatedAdminColumnXPath(adminEmail));

        public AddAdminSection addAdminSection;
        public MainSettingsSection mainSettinsSection;
        public AdminAccountsPage(IWebDriver driver, Navigator navigator)
        : base(driver, navigator)
        {
            addAdminSection = new AddAdminSection(driver, navigator);
            mainSettinsSection = new MainSettingsSection(driver, navigator);
        }

        public void ClickOnAddNewAdminButton()
        {
            WaitElementIsClickable(By.XPath(AddNewAdminButtonXPath), Timeouts.AdminAccountsPage);
            AddNewAdminButton.Click();
        }

        public int GetCountOfAdminInList()
        {
            if (IsElementVisible(By.XPath(EmptyListStateXPath)))
            {
                return 0;
            }
            return AdminListRows.Count;
        }

        public string CreatedAdminDataInList()
        {
            WebElement newAdminRow = AdminListRows.ElementAt(0);
            return newAdminRow.Text;
        }

        public void RemoveLastCreatedAdmin() 
        {
            WebElement firstAdminCheckbox = AdminListCheckboxes.ElementAt(0);
            firstAdminCheckbox.Click();
            ClickOnRemoveAllSelectedButton();
        }

        public void ClickOnRemoveAllSelectedButton() 
        {
            RemoveSelectedAdminsButton.Click();
        }
    }
}
