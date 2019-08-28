using System;
using AutomationPOC.PageObjects;
using AutomationPOC.TestCaseObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationPOC
{
    [TestFixture]
    public class AutomateAllTheThings
    {
        private static IWebDriver _chromeWebDriver;
        private static INavigation _chromeNavigation;
        private static string _baseUrl;

        [SetUp]
        public static void Setup()
        {
            _chromeWebDriver = new ChromeDriver(@"C:\Users\burchettj\Desktop\WebDrivers");
            _chromeNavigation = _chromeWebDriver.Navigate();
            _baseUrl = "http://qa50calphaap.brinkpos.net";
        }

        [Test(Description = "Login")]
        [TestCaseSource(typeof(TestCaseDataProvider), nameof(TestCaseDataProvider.LoginTestCaseData) )]
        public void CanLogin(LoginPageTestCase testCase)
        {
            string username = testCase.username;
            string pw = testCase.password;
            _chromeNavigation.GoToUrl(_baseUrl);
            
            //WebDriverWait wait = new WebDriverWait(_chromeWebDriver, TimeSpan.FromSeconds(15));
            //wait.Until(driver => driver.FindElement(By.TagName("button")));

            var loginPage = new LoginPageObject(_chromeWebDriver);
            loginPage.SetUsername(username);
            loginPage.SetPassword(pw);
            loginPage.Submit();

            // If the logout button is visible then that probably means we logged in successfully
            IWebElement logoutButton = _chromeWebDriver.FindElementSafe(By.CssSelector("a[href='/Public/Logout/']"));
            Assert.NotNull(logoutButton);
        }

        [TearDown]
        public void TearDownTest()
        {
            _chromeWebDriver.Close();
            _chromeWebDriver.Quit();
        }
    }
}
