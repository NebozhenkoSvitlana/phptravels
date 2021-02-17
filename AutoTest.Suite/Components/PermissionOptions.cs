using AutoTest.Suite.Utilities;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutoTest.Suite.Models
{
    public class PermissionOptions : PageBase
    {
        string action;
        private string HotelsXPath(string action) => $"//input[@value='{action}Hotels']";
        private WebElement HotelsCheckbox(string action) => GetByXPath(HotelsXPath(action));

        private string RentalsXPath(string action) => $"//input[@value='{action}Rentals']";
        private WebElement RentalsCheckbox(string action) => GetByXPath(RentalsXPath(action));

        private string CarsXPath(string action) => $"//input[@value='{action}Cars']";
        private WebElement CarsCheckbox(string action) => GetByXPath(CarsXPath(action));

        private string ToursXPath(string action) => $"//input[@value='{action}Tours']";
        private WebElement ToursCheckbox(string action) => GetByXPath(ToursXPath(action));

        private string BookingsXPath(string action) => $"//input[@value='{action}booking']";
        private WebElement BookingsCheckbox(string action) => GetByXPath(BookingsXPath(action));
        private string LocationsXPath(string action) => $"//input[@value='{action}locations']";
        private WebElement LocationsCheckbox(string action) => GetByXPath(LocationsXPath(action));


        public PermissionOptions(IWebDriver driver, Navigator navigator, string action)
        : base(driver, navigator)
        {
            this.action = action;
        }

        public void SetRandomPermissionOptions(int countOfEnabledOptions) 
        {
            var list = GetListOfPermissionOptions(action);
            System.Random rnd = new System.Random();

            for (int i = 1; i <= countOfEnabledOptions; i++)
            {
                int index = rnd.Next(list.Count);
                list[index].Click();
            }
        }

        private List<WebElement> GetListOfPermissionOptions(string action) 
        {
            var permissionOptions = new List<WebElement>();
            permissionOptions.Add(HotelsCheckbox(action));
            permissionOptions.Add(RentalsCheckbox(action));
            permissionOptions.Add(CarsCheckbox(action));
            permissionOptions.Add(ToursCheckbox(action));
            permissionOptions.Add(BookingsCheckbox(action));
            permissionOptions.Add(LocationsCheckbox(action));
            return permissionOptions;
        }
    }
}
