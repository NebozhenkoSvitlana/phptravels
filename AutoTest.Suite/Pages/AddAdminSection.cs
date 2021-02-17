using AutoTest.Suite.Models;
using AutoTest.Suite.Utilities;
using OpenQA.Selenium;

namespace AutoTest.Suite.Pages
{
    public class AddAdminSection : PageBase
    {
        private const string SaveAdminButtonXPath = "//div[@class='panel-footer']/button";
        private WebElement SaveAdminButton => GetByXPath(SaveAdminButtonXPath);

        private const string BannerXPath = "//h4[@class='ui-pnotify-title']";
        private WebElement Banner => GetByXPath(BannerXPath);

        public AdminItemComponent adminItem;

        public AddAdminSection(IWebDriver driver, Navigator navigator)
        : base(driver, navigator)
        {
            adminItem = new AdminItemComponent(driver, navigator);
        }
        public void ClickOnSaveNewAdminButton()
        {
            var bannerText = "Changes Saved!";

            WaitElementIsClickable(By.XPath(SaveAdminButtonXPath), Timeouts.AdminAccountsPage);
            SaveAdminButton.Click();
            WaitElementIsVisible(By.XPath(BannerXPath), Timeouts.AdminAccountsPage);
            WaitPredicate(() => Banner.Text == bannerText.ToUpper(), Timeouts.AdminAccountsPage);
        }

    }
}
