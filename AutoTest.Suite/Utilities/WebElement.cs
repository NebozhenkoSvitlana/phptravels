using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace AutoTest.Suite.Utilities
{
    public class WebElement
    {
        private readonly IWebElement _webElement;
        public string Text => _webElement.Text;

        public bool Enabled => _webElement.Enabled;
        public bool Displayed => _webElement.Displayed;

        public WebElement(IWebElement webElement)
        {
            _webElement = webElement;
        }

        public WebElement Clear()
        {
            _webElement.Clear();

            return this;
        }

        public WebElement Click()
        {
            _webElement.Click();

            return this;
        }

        public WebElement EnterText(string text)
        {
            foreach (var ch in text)
            {
                _webElement.SendKeys(ch.ToString());
            }
                
            return this;
        }

        public WebElement SendKeys(string text)
        {
            _webElement.SendKeys(text);

            return this;
        }

        public string GetAttribute(string attribute)
        {
            return _webElement.GetAttribute(attribute);
        }

        public void SelectDropDownItem(string option)
        {
            SelectElement oSelect = new SelectElement(_webElement);
            oSelect.SelectByText(option);
        }
    }
}
