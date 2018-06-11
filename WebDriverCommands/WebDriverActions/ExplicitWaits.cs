using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverActions
{
    [TestFixture]
    public class ExplicitWaits
    {
        [Test]
        public void WebDriverWait1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(45));

            Func<IWebDriver, bool> waitForElement1 = new Func<IWebDriver, bool>((IWebDriver web) =>
             {
                 var attribute = web.FindElement(By.Id("colorVar")).GetAttribute("style");
                 if (attribute.Contains("red"))
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
             });
            wait1.Until(waitForElement1);

            //Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            //{
            //    Console.WriteLine(Web.FindElement(By.Id("target")).GetAttribute("innerHTML"));
            //    return true;
            //});
            //wait.Until(waitForElement);
            driver.Quit();
        }

        [Test]
        public void WebDriverWait2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Console.WriteLine("Waiting for color to change");
                IWebElement element = Web.FindElement(By.Id("target"));
                if (element.GetAttribute("style").Contains("red"))
                {
                    return true;
                }
                return false;
            });

            wait.Until(waitForElement);
            driver.Quit();
        }

        public void WebDriverWait3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, IWebElement> waitForElement = new Func<IWebDriver, IWebElement>((IWebDriver Web) =>
            {
                Console.WriteLine("Waiting for color to change");
                IWebElement element = Web.FindElement(By.Id("target"));
                if (element.GetAttribute("style").Contains("red"))
                {
                    return element;
                }
                return null;
            });

            IWebElement targetElement = wait.Until(waitForElement);
            Console.WriteLine("Inner HTML of element is " + targetElement.GetAttribute("innerHTML"));
        }

        [Test]
        public void DefaultWait1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
            IWebElement element = driver.FindElement(By.Id("colorVar"));
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                String styleAttrib = element.GetAttribute("style");
                if (styleAttrib.Contains("red"))
                {
                    return true;
                }
                Console.WriteLine("Color is still " + styleAttrib);
                return false;
            });
            wait.Until(waiter);
        }

        [Test]
        public void DefaultWait2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");

            IWebElement element = driver.FindElement(By.Id("clock"));
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                String styleAttrib = element.Text;
                if (styleAttrib.Contains("Buzz"))
                {
                    return true;
                }
                Console.WriteLine("Current time is " + styleAttrib);
                return false;
            });
            wait.Until(waiter);
            driver.Quit();
        }
    }
}