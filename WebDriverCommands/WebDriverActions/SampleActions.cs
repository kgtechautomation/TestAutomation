using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WebDriverActions
{
    [TestFixture]
    public class SampleActions
    {
        private IWebDriver _driver = null;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://toolsqa.com/automation-practice-form/");

            string windowHandleName = _driver.CurrentWindowHandle;

            var elements = _driver.FindElements(By.Id("join")).ToList();

            var cookies = _driver.Manage().Cookies;

            _driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(120);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);

            _driver.Navigate().GoToUrl("https://www.xyz.com");

            Uri myURL = new Uri("https://www.xyz.com");

            _driver.Navigate().GoToUrl(myURL);

            _driver.Navigate().Refresh();

            var frame = _driver.SwitchTo().Frame("myFrame1");
            var defaultContent = _driver.SwitchTo().DefaultContent();

            var myWindow = _driver.SwitchTo().Window("Downloads");

            var currentURL = _driver.Url;
            _driver.Url = "https://www.xyz.com";

            var allWindows = _driver.WindowHandles.ToList();
        }

        [Test]
        public void Test1()
        {
            string actualPagName = _driver.Title;
            Assert.AreEqual("Google", actualPagName);

            IWebElement searchBox = _driver.FindElement(By.Id("lst-ib"));
            Assert.IsNotNull(searchBox);

            //searchBox.SendKeys("THIS IS FOR TESTING, PLEASE IGNORE");
            //searchBox.Clear();
            //searchBox.SendKeys("Selenium");

            //IWebElement searchBtn = _driver.FindElement(By.Name("btnK"));
            //searchBtn.Click();

            string currentWindowHandle = _driver.CurrentWindowHandle;
            Console.WriteLine(currentWindowHandle);

            _driver.Close();
        }

        [Test]
        public void FormFillingTest()
        {
            IWebElement elementToPartialLinkText = _driver.FindElement(By.PartialLinkText("Partial Link Test"));
            elementToPartialLinkText.Click();

            //List<IWebElement> linkTextElements = _driver.FindElements(By.LinkText("Link Test")).ToList();
            //linkTextElements[0].Click();

            IWebElement continentsDropDownList = _driver.FindElement(By.Id("continents"));

            SelectElement selectElement1 = new SelectElement(continentsDropDownList);
            if (!selectElement1.IsMultiple)
            {
                selectElement1.SelectByText("Australia");
            }

            IWebElement seleniumCommands = _driver.FindElement(By.Id("selenium_commands"));

            SelectElement selectElement2 = new SelectElement(seleniumCommands);
            if (selectElement2.IsMultiple)
            {
                selectElement2.SelectByText("Navigation Commands");
                selectElement2.SelectByText("Wait Commands");
            }

            IWebElement automationTool = _driver.FindElement(By.Id("tool-0"));
            if (!automationTool.Selected)
            {
                automationTool.Click();
            }

            //You the same for Radio Button as well.

            IWebElement genderMale = _driver.FindElement(By.CssSelector(".control-group #sex-0"));
            if (!genderMale.Selected)
            {
                genderMale.Click();
            }
        }

        [Test]
        public void HandlingDynamicWebElements()
        {
            // WebPage which contains a WebTable
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites");
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();

            // xpath of html table
            var elemTable = _driver.FindElement(By.XPath("//div[@id='mw-content-text']//table[1]"));

            // Fetch all Row of the table
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
            String strRowData = "";

            // Traverse each row
            foreach (var elemTr in lstTrElem)
            {
                // Fetch the columns from a particuler row
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    // Traverse each column
                    foreach (var elemTd in lstTdElem)
                    {
                        // "\t\t" is used for Tab Space between two Text
                        strRowData = strRowData + elemTd.Text + "\t\t";
                    }
                }
                else
                {
                    // To print the data into the console
                    Console.WriteLine("This is Header Row");
                    Console.WriteLine(lstTrElem[0].Text.Replace(" ", "\t\t"));
                }
                Console.WriteLine(strRowData);
                strRowData = String.Empty;
            }
        }

        //Simple Alert Simple alerts just have a OK button on them.
        //They are mainly used to display some information to the user.
        //The first alert on our test page is a simple alert.
        //Following code will read the text from the Alert and then accept the alert.
        //Important point to note is that we can switch from main window to an alert using the driver.SwitchTo().Alert().
        [Test]
        public void HandlingAlerts1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Window.Maximize();

            //This step produce an alert on screen
            driver.FindElement(By.XPath("//*[@id='content']/p[4]/button")).Click();

            // Switch the control of 'driver' to the Alert from main Window
            IAlert simpleAlert = driver.SwitchTo().Alert();

            // '.Text' is used to get the text from the Alert
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is " + alertText);

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            simpleAlert.Accept();

            driver.Dispose();
        }

        //Confirmation Alert :: This alert comes with an option to accept or dismiss the alert.
        //To accept the alert you can use IAlert.Accept() and to dismiss you can use the IAlert.Dismiss().
        //Here is the code to dismiss a confirmation alert.
        public void HandlingAlerts2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Window.Maximize();

            //This step produce an alert on screen
            driver.FindElement(By.XPath("//*[@id='content']/p[4]/button")).Click();

            // Switch the control of 'driver' to the Alert from main Window
            IAlert simpleAlert = driver.SwitchTo().Alert();

            // '.Text' is used to get the text from the Alert
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is " + alertText);

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            simpleAlert.Accept();
        }

        //Prompt Alerts :
        //In prompt alerts you get an option to add text to the alert box.
        //This is specifically used when some input is required from the user.
        //We will use the SendKeys() method to type something in the Prompt alert box.
        //Here is the code

        public void HandlingAlerts3()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Window.Maximize();

            //This step produce an alert on screen
            IWebElement element = driver.FindElement(By.XPath("//*[@id='content']/p[11]/button"));

            // 'IJavaScriptExecutor' is an 'interface' which is used to run the 'JavaScript code' into the webdriver (Browser)
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

            // Switch the control of 'driver' to the Alert from main window
            IAlert promptAlert = driver.SwitchTo().Alert();

            // Get the Text of Alert
            String alertText = promptAlert.Text;
            Console.WriteLine("Alert text is " + alertText);

            //'.SendKeys()' to enter the text in to the textbox of alert
            promptAlert.SendKeys("Accepting the alert");

            Thread.Sleep(4000); //This sleep is not necessary, just for demonstration

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            promptAlert.Accept();
        }

        [Test]
        public void ToCaptureScreenshotTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://www.google.com";

            var ss = ((ITakesScreenshot)(_driver)).GetScreenshot();
            try
            {
                Assert.AreEqual("XYZ", _driver.Title);
            }
            catch (Exception e)
            {
                ss.SaveAsFile(@"D:\TEST1.jpeg", ScreenshotImageFormat.Jpeg);
                Assert.Fail(e.Message);
            }
        }

        [TearDown]
        public void CleanUp()
        {
            //_driver.Dispose();
        }
    }
}