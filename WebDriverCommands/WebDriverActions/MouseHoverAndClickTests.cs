using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverActions
{
    [TestFixture]
    public class MouseHoverAndClickTests
    {
        private IWebDriver _driver = null;

        [SetUp]
        public void SetUpTests()
        {
            //Navigate to AUT
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=kishore&Password=kishore&Login=Login");

            ////Login with Username and Password
            //IWebElement userName = _driver.FindElement(By.Name("UserName"));
            //IWebElement password = _driver.FindElement(By.Name("Password"));
            //IWebElement loginButton = _driver.FindElement(By.Name("Login"));

            //userName.SendKeys("kishore");
            //password.SendKeys("kishore");
            //loginButton.Click();
            //loginButton.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Automation Tools")));
        }

        [Test]
        public void MouseHoverTest()
        {
            IWebElement automationToolsMenuItem = _driver.FindElement(By.Id("Automation Tools"));
            Actions action = new Actions(_driver);
            action.MoveToElement(automationToolsMenuItem).Perform();
        }

        [Test]
        public void MouseHoverAndClick()
        {
            IWebElement automationToolsMenuItem = _driver.FindElement(By.Id("Automation Tools"));
            Actions action = new Actions(_driver);
            action.MoveToElement(automationToolsMenuItem).Perform();

            IWebElement seleniumSubMenuItem = _driver.FindElement(By.Id("Selenium"));
            IWebElement seleniumRCChildItem = _driver.FindElement(By.Id("Selenium RC"));

            action.MoveToElement(seleniumSubMenuItem).Click(seleniumRCChildItem).Build().Perform();
        }

        public void DragAndDropTest()
        {
            IWebElement sourceElement = _driver.FindElement(By.Id("item1"));
            IWebElement destinationElement = _driver.FindElement(By.Id("item2"));

            Actions action = new Actions(_driver);
            action.DragAndDrop(sourceElement, destinationElement).Perform();
        }

        public void MouseHover_LeftAndRightClick()
        {
            IWebElement automationToolsMenuItem = _driver.FindElement(By.Id("Automation Tools"));
            IWebElement seleniumSubMenuItem = _driver.FindElement(By.Id("Selenium"));
            Actions action = new Actions(_driver);
            action.ContextClick(seleniumSubMenuItem); //Right clicks the mouse action
        }
    }
}