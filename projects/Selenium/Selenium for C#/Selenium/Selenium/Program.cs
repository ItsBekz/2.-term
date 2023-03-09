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
            getDataFromTV2();
            LogIn("beksen0@gmail.com", "test123");
            
        }
        public static void getDataFromTV2()
        {
            //*[@id="CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"]
            driver.Navigate().GoToUrl("https://tv2.dk/");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            driver.FindElement(By.ClassName("tc_icon__login")).Click();
        }
        public static void LogIn(string username, string password)
        {
            Thread.Sleep(300);
            IWebElement enterUsername = driver.FindElement(By.XPath("//*[@data-testid=\"auth0-field-email\"]"));
            IWebElement enterPassword = driver.FindElement(By.XPath("//*[@data-testid=\"auth0-field-password\"]"));
            enterUsername.SendKeys(username);
            enterPassword.SendKeys(password);
            bool loginButtonPresent = driver.FindElement(By.XPath("//*[@data-testid=\"auth0-field-password\"]")).Displayed;
            bool loginIconEnabled = driver.FindElement(By.XPath("//*[@data-testid=\"auth0-field-password\"]")).Enabled;
            if (loginButtonPresent && loginIconEnabled)
            {
                Console.WriteLine("Login button is present and enabled");
                driver.FindElement(By.XPath("//*[@data-testid=\"auth0-button-login\"]")).Click();
            }
            else
            {
                Console.WriteLine("Login button is not present or enabled");
            }
            Console.WriteLine("-----------------");
            Console.WriteLine("PRINTER VÆRDIEN I EMAIL BOKS");
            Console.WriteLine("-----------------");
            Console.WriteLine(driver.FindElement(By.XPath("//*[@data-testid=\"auth0-field-email\"]")).GetAttribute("value"));
            Console.WriteLine("-----------------");
            Console.WriteLine("PRINTER VÆRDIEN I PASSWORD BOKS");
            Console.WriteLine("-----------------");
            Console.WriteLine(driver.FindElement(By.XPath("//*[@data-testid=\"auth0-field-password\"]")).GetAttribute("value"));

        }
    }
}