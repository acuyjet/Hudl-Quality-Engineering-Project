using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HudlTests.PageObjects
{
    public class LoginPage
    {
        public IWebDriver driver;

        public void Setup()
        {
            
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(outputDirectory);
            driver.Navigate().GoToUrl("https://www.hudl.com/login");

        }

        public void Login(string email, string password)
        {
            EmailField.Clear();
            PasswordField.Clear();
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }

        private IWebElement EmailField
        {
            get
            {
                return driver.FindElement(By.Id("email"));
            }
        }

        private IWebElement PasswordField
        {
            get
            {
                return driver.FindElement(By.Id("password"));
            }
        }

        private IWebElement LoginButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("button[data-qa-id='login-btn']"));
            }
        }

        private IWebElement ErrorDisplayMessage
        {
            get
            {
                return driver.FindElement(By.CssSelector("p[data-qa-id='error-display']"));
            }
        }
    }

}

