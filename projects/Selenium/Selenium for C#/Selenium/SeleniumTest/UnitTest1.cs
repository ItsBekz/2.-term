using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // browser driver
            IWebDriver webDriver = new ChromeDriver();

            // navigate to url
            webDriver.Navigate().GoToUrl("https://www.google.com");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}