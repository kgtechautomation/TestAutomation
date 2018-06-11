using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebDriverActions
{
    [TestFixture]
    public class FindAllTheLinks
    {
        [Test]
        public void ToFindAllTheLinksOnAWebPage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/");

            List<IWebElement> links = driver.FindElements(By.TagName("a")).ToList();

            Console.WriteLine(links.Count());

            for (int i = 0; i < links.Count(); i++)

            {
                if (links[i].Text != string.Empty)
                {
                    Console.WriteLine(links[i].Text);
                }
            }
            driver.Quit();
        }
    }
}