using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace WebDriverActions
{
    [TestFixture]
    internal class HandleCertificateErrors
    {
        [Test]
        public void HandleChromeCertificateError()
        {
            ChromeOptions chromeOptions = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };

            IWebDriver driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.xyz.com";
        }

        [Test]
        public void HandleFirefoxCertificateError()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            IWebDriver driver = new FirefoxDriver(firefoxOptions);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void HandleIECertificateError()
        {
            InternetExplorerOptions ieOptions = new InternetExplorerOptions
            {
                AcceptInsecureCertificates = true
            };

            IWebDriver driver = new InternetExplorerDriver(ieOptions);
            driver.Manage().Window.Maximize();
        }
    }
}