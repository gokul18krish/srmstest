using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace SR_NewMSTestCI
{
    [TestClass]
    public class Login
    {
        private IWebDriver driver;
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        [TestInitialize()]
        public void SetupTest()
        {
            //string browser = TestContext.Properties["browser"].ToString();
            string browser = "Chrome"; //Edge can also be used
            switch (browser)
            {
                case "Chrome":
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("no-sandbox");
                        driver = new ChromeDriver(); //check chrome version drivers here
                    }
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Edge":
                    {
                        var options = new EdgeOptions
                        {
                            PageLoadStrategy = PageLoadStrategy.Normal
                            //BinaryLocation = @"C:\Program Files (x86)\Microsoft\Edge Dev\Application\msedge.exe"
                        };
                        driver = new EdgeDriver(options);
                    }
                    break;
            }
        }
        [TestMethod]
        public void TestLogin()
        {
            driver.Navigate().GoToUrl("https://qa1.myhcl.com/smartrecruit_CBT");
        }
        [TestCleanup()]
        public void SeleniumTestCleanup()
        {
            driver.Quit();
        }
    }
}
