using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverActions
{
    [TestFixture]
    internal class HandlingDynamicElements
    {
        private IWebDriver driver;

        [Test]
        public void ManagingVariablesInXPath()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://toolsqa.com/automation-practice-switch-windows/");

            WaitUntilTextIsVisible("toolsqa");
        }

        private void WaitUntilTextIsVisible(string text, int waitTime = 60)
        {
            string locatorText = string.Format("//*[contains(text(),'{0}')]", text);
            By locator = By.XPath(locatorText);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
    }
}