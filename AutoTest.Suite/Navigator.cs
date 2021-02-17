using AutoTest.Suite.Utilities;
using System;

namespace AutoTest.Suite
{
    public class Navigator : IDisposable
    {
        private readonly Browser _browser;

        public Navigator(Browser browser)
        {
            _browser = browser;
        }

        public void GoToPHPTravelsAdminPage()
        {
            _browser.Navigate(new Uri("https://www.phptravels.net/admin"));
        }

        public void GoToAdminAccounts()
        {
            _browser.Navigate(new Uri("https://www.phptravels.net/admin/accounts/admins/"));
        }

        public void Logout() 
        {
            _browser.Navigate(new Uri("https://www.phptravels.net/admin/logout/"));
        }

        public void AcceptAlert() 
        {
            _browser.AlertAccept();
        }

        public void Dispose()
        {
            _browser?.Dispose();
        }
    }
}
