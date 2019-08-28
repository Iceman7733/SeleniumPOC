using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationPOC.PageObjects
{
    public class LoginPageObject
    {
        private IWebDriver _webDriver;
        private IWebElement _usernameField;
        private IWebElement _passwordField;
        private IWebElement _submitButton;

        public LoginPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _usernameField = _webDriver.FindElement(By.Id("Username"));
            _passwordField = _webDriver.FindElement(By.Id("Password"));
            _submitButton = webDriver.FindElement(By.TagName("button"));
        }

        public void SetUsername(string user)
        {
            _usernameField.SendKeys(user);
        }

        public void SetPassword(string password)
        {
            _passwordField.SendKeys(password);
        }

        public void Submit()
        {
            _submitButton.Click();
        }
    }
}
