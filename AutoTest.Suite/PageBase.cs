using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoTest.Suite.Utilities;

namespace AutoTest.Suite
{
    public class PageBase
    {
        protected readonly IWebDriver _driver;
        private readonly Navigator _navigator;

        protected PageBase(IWebDriver driver, Navigator navigator)
        {
            _driver = driver;
            _navigator = navigator;
        }

        protected WebElement GetByXPath(string xPath)
        {
            return new WebElement(_driver.FindElement(By.XPath(xPath)));
        }
        protected WebElement GetByName(string name)
        {
            return new WebElement(_driver.FindElement(By.Name(name)));
        }

        protected WebElement GetById(string id)
        {
            return new WebElement(_driver.FindElement(By.Id(id)));
        }

        protected IList<WebElement> GetElementsByXPath(string xPath)
        {
            return _driver.FindElements(By.XPath(xPath))
                .Select(o => new WebElement(o))
                .ToList();
        }

        protected void WaitPredicate(Func<bool> func, int seconds)
        {
            var waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            waiter.Until(driver =>
            {
                var leftAttempts = 6;
                var result = false;

                while (leftAttempts > 0)
                {
                    try
                    {
                        result = func();
                        break;
                    }
                    catch (Exception e)
                    {
                        leftAttempts--;

                        if (leftAttempts == 0)
                        {
                            throw e;
                        }

                        Thread.Sleep(500);
                    }
                }

                return result;
            });
        }

        protected void WaitElementIsClickable(By locator, int seconds)
        {
            var waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            waiter.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected void WaitElementIsVisible(By locator, int seconds)
        {
            var waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            waiter.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected bool IsElementVisible(By locator)
        {
            try
            {
                _driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element was not found" + ex.Message);
                return false;
            }
        }
    }
}
