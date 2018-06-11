using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverActions
{
    [TestFixture]
    public class SimulatingKeyboardActions
    {
        [Test]
        public void KeyboardSimulationTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://toolsqa.com/automation-practice-form/";

            var firstName = driver.FindElement(By.Name("firstname"));

            firstName.SendKeys("TEST TEST TEST");
            firstName.SendKeys(Keys.Control);
            firstName.SendKeys(Keys.Backspace);
        }
    }
}