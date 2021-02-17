using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics.Contracts;

namespace AutoTest.Suite.Utilities
{
    public class Browser : IDisposable
    {
        private IWebDriver _webDriver;

        private IWebDriver WebDriver => _webDriver ?? StartWebDriver();

        public IWebDriver Start()
        {
            _webDriver = StartWebDriver();
            return _webDriver;
        }

        private IWebDriver StartWebDriver()
        {
            if (_webDriver != null)
            {
                return _webDriver;
            }

            _webDriver = StartChrome();
            _webDriver.Manage().Window.Maximize();

            return WebDriver;
        }

        private ChromeDriver StartChrome()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("lang=en-GB"); //this is for the locale setting, have impact on the 'Search' XPath input

            var driver = new ChromeDriver(chromeOptions);
            return driver;
        }

        public void Navigate(Uri url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public void AlertAccept()
        {
            WebDriver.SwitchTo().Alert().Accept();
            WebDriver.SwitchTo().DefaultContent();
        }

        public void Dispose()
        {
            _webDriver?.Quit();
            _webDriver?.Dispose();

        }
    }
}
