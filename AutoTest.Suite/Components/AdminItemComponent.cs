using AutoTest.Suite.Utilities;
using OpenQA.Selenium;

namespace AutoTest.Suite.Models
{
    public class AdminItemComponent: PageBase
    {
        private const string FirstName = "fname";
        private WebElement FirstNameField => GetByName(FirstName);

        private const string LastName = "lname";
        private WebElement LastNameField => GetByName(LastName);

        private const string Email = "email";
        private WebElement EmailField => GetByName(Email);

        private const string Password = "password";
        private WebElement PasswordField => GetByName(Password);

        private const string MobileNumber = "password";
        private WebElement MobileNumberField => GetByName(MobileNumber);

        private const string Country = "country";
        private WebElement CountryField => GetByName(Country);

        private const string Address1 = "address1";
        private WebElement Address1Field => GetByName(Address1);

        private const string Address2 = "address1";
        private WebElement Address2Field => GetByName(Address2);

        private const string EmailNewsletterSubstriber = "newssub";
        private WebElement EmailNewsletterSubstriberCheckBox => GetByName(EmailNewsletterSubstriber);

        public AdminItemComponent(IWebDriver driver, Navigator navigator)
                : base(driver, navigator)
        {
        }

        public void SetOnlyRequiredFields(string fname, string lname, string email, string password, string country)
        {
            //WaitPredicate(() => FirstNameField.Enabled, Timeouts.AdminAccountsPage);
            WaitElementIsClickable(By.Name(FirstName), Timeouts.AdminAccountsPage);
            FirstNameField.EnterText(fname);
            WaitPredicate(() => FirstNameField.GetAttribute("value") == fname, Timeouts.AdminAccountsPage);
            LastNameField.EnterText(lname);
            WaitPredicate(() => LastNameField.GetAttribute("value") == lname, Timeouts.AdminAccountsPage);
            EmailField.EnterText(email);
            WaitPredicate(() => EmailField.GetAttribute("value") == email, Timeouts.AdminAccountsPage);
            PasswordField.EnterText(password);
            WaitPredicate(() => PasswordField.GetAttribute("value") == password, Timeouts.AdminAccountsPage);
            SelectCountryOption(country);
        }

        private void SelectCountryOption(string country) 
        {
            CountryField.SelectDropDownItem(country);
        }
    }
}
