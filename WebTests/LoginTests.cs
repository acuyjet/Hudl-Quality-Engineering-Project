using System;
using System.IO;
using System.Reflection;
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

            Assert.IsTrue(loginPage.driver.Url.Contains("hudl.com/home"), "Login unsuccessful.");
        }

        [TestCleanup]
        public void Cleanup()
        {
            loginPage.driver.Quit();
        }
    }
}

