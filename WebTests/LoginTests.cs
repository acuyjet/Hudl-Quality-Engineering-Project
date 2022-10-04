using System;
using System.IO;
using System.Reflection;
using System.Threading;
using HudlTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HudlTests
{
    [TestClass]
    public class LoginTests
    {
        //IWebDriver driver;

        LoginPage loginPage = new LoginPage();

        [TestMethod]
        public void LoginSuccess()
        {
            var email = "";
            var password = "";

            loginPage.Setup();
            loginPage.Login(email, password);
            Thread.Sleep(1000);  //Replace this with better wait method

            Assert.IsTrue(loginPage.driver.Url.Contains("hudl.com/home"), "Login unsuccessful.");
        }

        [TestMethod]
        public void LoginUnsuccessfulIncorrectEmail()
        {
            var email = "asdf";
            var password = "";
            loginPage.Setup();
            loginPage.Login(email, password);
            Thread.Sleep(1000);  //Replace this with better wait method

            Assert.IsTrue(loginPage.driver.FindElement(By.CssSelector("p[data-qa-id='error-display']")).Displayed, "Unrecognized email/password message not displayed.");
        }

        [TestMethod]
        public void LoginUnsuccessfulIncorrectPassword()
        {
            var email = "";
            var password = "asdf";
            loginPage.Setup();
            loginPage.Login(email, password);
            Thread.Sleep(1000);  //Replace this with better wait method

            Assert.IsTrue(loginPage.driver.FindElement(By.CssSelector("p[data-qa-id='error-display']")).Displayed, "Unrecognized email/password message not displayed.");
        }

        [TestCleanup]
        public void Cleanup()
        {
            loginPage.driver.Quit();
        }
    }
}

