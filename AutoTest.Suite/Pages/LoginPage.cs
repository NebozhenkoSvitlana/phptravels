using AutoTest.Suite.Utilities;
using OpenQA.Selenium;

namespace AutoTest.Suite.Pages
{
    public class LoginPage : PageBase
    {
        private const string UserEmailName = "email";
        private WebElement UserEmailField => GetByName(UserEmailName);

        private const string UserPasswordName = "password";
        private WebElement UserPasswordField => GetByName(UserPasswordName);

        private const string SubmitButtonXPath = "//button[@type='submit']";
        private WebElement SubmitButton => GetByXPath(SubmitButtonXPath);

        private const string MainAppSidebarId = "sidebar";
        private WebElement MainAppSidebar => GetById(MainAppSidebarId);

        private const string BuyNowButtonXPath = "//div[@class='animated fadeIn']";
        private WebElement BuyNowButton => GetByXPath(BuyNowButtonXPath);


        public LoginPage(IWebDriver driver, Navigator navigator)
                : base(driver, navigator)
        {
        }

        public void LoginToAdminPortal(string userEmail, string userPassword)
        {
            FillUserEmailField(userEmail);
            FillUserPasswordField(userPassword);
            ClickOnSubmitButton();
            WaitElementIsClickable(By.Id(MainAppSidebarId), Timeouts.AdminAccountsPage);
        }

        public void WaitBuyButtonVisible() 
        {
            WaitElementIsVisible(By.XPath(BuyNowButtonXPath), Timeouts.AdminAccountsPage);
        }

        private void FillUserEmailField(string userEmail)
        {
            WaitElementIsClickable(By.Name(UserEmailName), Timeouts.LoginPageLoad);
            UserEmailField.Clear();
            UserEmailField.EnterText(userEmail);
        }

        private void FillUserPasswordField(string userPassword)
        {
            WaitElementIsClickable(By.Name(UserPasswordName), Timeouts.LoginPageLoad);
            UserPasswordField.Clear();
            UserPasswordField.EnterText(userPassword);
        }

        private void ClickOnSubmitButton()
        {
            WaitElementIsClickable(By.XPath(SubmitButtonXPath), Timeouts.LoginPageLoad);
            SubmitButton.Click();
        }
    }
}
