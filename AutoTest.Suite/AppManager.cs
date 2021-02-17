using System;
using AutoTest.Suite.Utilities;
using OpenQA.Selenium;

namespace AutoTest.Suite
{
    public class AppManager: IDisposable
    {
        public PageManager PageManager { get; }
        public Navigator Navigator { get; }

        private readonly IWebDriver _driver;

        public AppManager()
        {
            var browser = new Browser();
            _driver = browser.Start();
            Navigator = new Navigator(browser);
            PageManager = new PageManager(_driver, Navigator);
        }

        public void Dispose()
        {
            Navigator?.Dispose();
        }
    }
}
