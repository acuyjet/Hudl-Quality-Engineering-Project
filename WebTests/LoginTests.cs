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

        LoginPage loginPage = new LoginPage();

        public string email = "allison@cuyjet.com";
        public string password = "hudl9hudl";

        [TestMethod]
        public void LoginSuccess()
        {
            loginPage.Setup();
            loginPage.Login(email, password);
            Thread.Sleep(1000);  //Replace this with a better wait method

            Assert.IsTrue(loginPage.driver.Url.Contains("hudl.com/home"), "Login unsuccessful.");
        }

        [TestMethod]
        public void LoginUnsuccessfulIncorrectEmail()
        {
            loginPage.Setup();
            loginPage.Login("asdf", password);
            Thread.Sleep(1000);  //Replace this with a better wait method

            Assert.IsTrue(loginPage.driver.FindElement(By.CssSelector("p[data-qa-id='error-display']")).Displayed, "Unrecognized email/password message not displayed.");
        }

        [TestMethod]
        public void LoginUnsuccessfulIncorrectPassword()
        {
            loginPage.Setup();
            loginPage.Login(email, "asdf");
            Thread.Sleep(1000);  //Replace this with better wait method

            Assert.IsTrue(loginPage.driver.FindElement(By.CssSelector("p[data-qa-id='error-display']")).Displayed, "Unrecognized email/password message not displayed.");
        }

        [TestMethod]
        public void ResetPasswordSuccess()
        {
            loginPage.Setup();
            loginPage.ResetPassword(email);

            Assert.IsTrue(loginPage.driver.Url.Contains("hudl.com/login/check-email"), "Reset password request not sent.");
        }

        [TestCleanup]
        public void Cleanup()
        {
            loginPage.driver.Quit();
        }
    }
}

