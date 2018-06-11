using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace WebDriverActions
{
    [TestFixture]
    public class WebDriverWaitsTests
    {
        [Test]
        public void ImplicitWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement element = driver.FindElement(By.Id("target"));
            driver.Quit();
        }

        [Test]
        public void PageLoadTimeOutTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3000);
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
            IWebElement element = driver.FindElement(By.Id("target"));
        }

        [Test]
        public void ScriptTimeOutTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(500);
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
            IWebElement element = driver.FindElement(By.Id("target"));
        }
    }
}