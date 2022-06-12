using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GoogleTestSearchUniwersytetGdanskiThenVerifyUniwersysteGdanskiIsDisplayed()
        {
            int waitingTime = 2000;
            By googleSearchBar = By.Name("q");
            By googleSearchButton = By.Name("btnK");
            By googleResultText = By.XPath(".//h2//span[text()='Uniwersytet Gdański']");
            By googleIAgreeButton = By.Id("L2AGLb");

            IWebDriver webDriver = new ChromeDriver();

            Thread.Sleep(waitingTime);

            webDriver.Navigate().GoToUrl("https://www.google.com");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleIAgreeButton).Click();

            webDriver.Manage().Window.Maximize();

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleSearchBar).SendKeys("Uniwersytet gdański");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleSearchButton).Click();

            Thread.Sleep(waitingTime);

            var actualResultText = webDriver.FindElement(googleResultText);

            Assert.IsTrue(actualResultText.Text.Equals("Uniwersytet Gdański"));

            webDriver.Quit();
        }

        [TestMethod]
        public void PortalEdukacyjnyLoginFailedTest()
        {
            int waitingTime = 2000;
            By zaloguj = By.Id("loginbtn");
            By userName = By.Name("username");
            By password = By.Name("password");
            By whoAreYou= By.Name("kimjestes");
            string url = "https://mdl.ug.edu.pl/login/index.php";

            IWebDriver webDriver = new ChromeDriver();

            Thread.Sleep(waitingTime);

            webDriver.Navigate().GoToUrl(url);

            Thread.Sleep(waitingTime);

            webDriver.Manage().Window.Maximize();

            Thread.Sleep(waitingTime);

            webDriver.FindElement(whoAreYou).SendKeys("s");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(userName).SendKeys("login");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(password).SendKeys("password");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(zaloguj).Click(); ;

            Thread.Sleep(waitingTime);

            string expectedUrl = webDriver.Url;

            Assert.AreEqual(url, expectedUrl);

            webDriver.Quit();
        }

        [TestMethod]
        public void VerifyYouTubeLogoTest() { 

            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.youtube.com/");
            Assert.IsTrue(webDriver.FindElement(By.Id("logo-icon")).Displayed);
            webDriver.Quit();
        }

        [TestMethod]
        public void verifyPricingPage()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://dietyodbrokula.pl/cennik?gclid=EAIaIQobChMIn-eA7Pai-AIV5gWiAx2MBQ6jEAAYASACEgLvzPD_BwE");
            IWebElement pricingPageHeader = webDriver.FindElement(By.TagName("h1"));
            Assert.IsTrue(pricingPageHeader.Text.Contains("Cennik diet"));
            webDriver.Quit();
        }
    }
}