using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WebDriverActions
{
    [TestFixture]
    public class IFramesTests
    {
        [Test]
        public void ToCountTotalNumberOfFrames()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/iframe-practice-page/");

            //By executing a java script
            IJavaScriptExecutor exe = (IJavaScriptExecutor)driver;
            int numberOfFrames = int.Parse(exe.ExecuteScript("return window.length").ToString());
            Console.WriteLine("Number of iframes on the page are " + numberOfFrames);

            //By finding all the web elements using iframe tag
            List<IWebElement> iframeElements = driver.FindElements(By.TagName("iframe")).ToList();
            Console.WriteLine("The total number of iframes are " + iframeElements.Count);
        }

        [Test]
        public void ToSwitchToFrameByIndex()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/iframe-practice-page/");

            //Switch by Index
            driver.SwitchTo().Frame(1);

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        public void ToSwitchToFrameByName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/iframe-practice-page/");

            //Switch by Index
            driver.SwitchTo().Frame("iframe2");
            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        public void ToSwitchToFrameByID()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/iframe-practice-page/");

            //Switch by Index
            driver.SwitchTo().Frame("IF1");
            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        public void ToSwitchToFrameByElement()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/iframe-practice-page/");
            //First find the element using any of locator stratedgy
            IWebElement iframeElement = driver.FindElement(By.Id("IF1"));

            //now use the switch command
            driver.SwitchTo().Frame(iframeElement);
            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        public void ToSwitchBackToMainWindow()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/iframe-practice-page/");
            //First find the element using any of locator stratedgy
            IWebElement iframeElement = driver.FindElement(By.Id("IF1"));

            //now use the switch command
            driver.SwitchTo().Frame(0);

            //Do all the required tasks in the frame 0
            //Switch back to the main window
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}