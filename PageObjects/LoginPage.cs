using System;
using System.IO;
using System.Reflection;
using System.Threading;
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            EmailField.Clear();
            PasswordField.Clear();
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            wait.Until(ExpectedConditions.ElementToBeClickable(LoginButton));
            LoginButton.Click();
        }

        public void ResetPassword(string email)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            NeedHelpLink.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(PasswordResetEmailField));
            PasswordResetEmailField.Click();
            PasswordResetEmailField.Clear();
            PasswordResetEmailField.SendKeys(email);
            PasswordResetButton.Click();

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

        private IWebElement NeedHelpLink
        {
            get
            {
                return driver.FindElement(By.CssSelector("a[data-qa-id='need-help-link']"));
            }
        }

        private IWebElement PasswordResetEmailField
        {
            get
            {
                return driver.FindElement(By.CssSelector("input[data-qa-id='password-reset-input']"));
            }
        }

        private IWebElement PasswordResetButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("button[data-qa-id='password-reset-submit-btn']"));
            }
        }
    }

}

