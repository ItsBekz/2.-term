using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
namespace Selenium // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static IWebDriver driver;
        static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            getDataFromBT();
            LogIn("JENSPETERHANSEN", "MITSEJEKODEORD");
            
        }
        public static void getDataFromBT()
        {
            //*[@id="CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"]
            driver.Navigate().GoToUrl("http://www.bt.dk");
            driver.FindElement(By.XPath("//*[@id=\"CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll\"]")).Click();
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.ClassName("dre-item__text"));
            int counter = 1;
            foreach (IWebElement element in elements)
            {

                if (counter <= 5)
                {
                    Console.WriteLine(element.Text);
                    Console.WriteLine("-------------------------");

                }
                else
                {
                    break;
                }
                counter++;
            }
        }
        public static void LogIn(string username, string password)
        {
            driver.FindElement(By.XPath("//*[@id=\"siteHeader\"]/div/div/ul/li[1]/div/div[1]")).Click();
            IWebElement enterUsername = driver.FindElement(By.XPath("//*[@id=\"email\"]"));
            IWebElement enterPassword = driver.FindElement(By.XPath("//*[@id=\"password\"]"));
            enterUsername.SendKeys(username);
            enterPassword.SendKeys(password);
            Console.WriteLine("-----------------");
            Console.WriteLine("PRINTER VÆRDIEN I EMAIL BOKS");
            Console.WriteLine("-----------------");
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id=\"email\"]")).GetAttribute("value"));
            Console.WriteLine("-----------------");
            Console.WriteLine("PRINTER VÆRDIEN I PASSWORD BOKS");
            Console.WriteLine("-----------------");
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id=\"password\"]")).GetAttribute("value"));

        }
    }
}