using AutoTest.Suite.Models;
using AutoTest.Suite.Utilities;
using OpenQA.Selenium;

namespace AutoTest.Suite.Pages
{
    public class MainSettingsSection : PageBase
    {
        private const string Status = "status";
        private WebElement StatusField => GetByName(Status);

        private const string Comission = "commission";
        private WebElement ComissionField => GetByName(Comission);

        public PermissionOptions AddSection;
        public PermissionOptions EditSection;
        public PermissionOptions DeleteSection;

        public MainSettingsSection(IWebDriver driver, Navigator navigator)
            : base(driver, navigator)
        {
            AddSection = new PermissionOptions(driver, navigator, "add");
            EditSection = new PermissionOptions(driver, navigator, "edit");
            DeleteSection = new PermissionOptions(driver, navigator, "delete");
        }

        public void SetStatusField(string status)
        {
            StatusField.SelectDropDownItem(status);
        }

        public void SetComissionField(string comission)
        {
            ComissionField.EnterText(comission);
            WaitPredicate(() => ComissionField.GetAttribute("value") == comission, Timeouts.AdminAccountsPage);
        }
    }
}
