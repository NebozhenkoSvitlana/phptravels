using AutoTest.Suite.Pages;
using OpenQA.Selenium;

namespace AutoTest.Suite
{
    public class PageManager
    {
        private readonly IWebDriver _driver;
        private readonly Navigator _navigator;

        public AdminAccountsPage AdminAccountsPage => new AdminAccountsPage(_driver, _navigator);
        public LoginPage LoginPage => new LoginPage(_driver, _navigator);
        public PageManager(IWebDriver driver, Navigator navigator)
        {
            _driver = driver;
            _navigator = navigator;
        }
    }
}
