using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TrainingCsharpSelenium
{
    public class Tests
    {
        IWebDriver driver;

        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        [SetUp]
        public void Setup()
        {
            logger.Info("Set up");

            // string driverPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\browserDrivers\";

            // driver = new ChromeDriver(driverPath);
            // driver = new FirefoxDriver(driverPath);
            // driver = new OperaDriver(driverPath);
            // driver = new EdgeDriver(driverPath);

            //new DriverManager().SetUpDriver(new ChromeConfig());
            new DriverManager().SetUpDriver(new FirefoxConfig());
            //new DriverManager().SetUpDriver(new OperaConfig());
            //new DriverManager().SetUpDriver(new EdgeConfig());

            //driver = new ChromeDriver();
            driver = new FirefoxDriver();
            //driver = new OperaDriver();
            //driver = new EdgeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Navigate().GoToUrl("https://www.google.com/");
            Assert.True(driver.Title.Contains("Google"));
        }

        [Test]
        public void Test1()
        {
            logger.Info("Test");

            IWebElement searchTextbox;
            string searchText = "C# Tutorial";

            // Find by xpath
            searchTextbox  = driver.FindElement(By.XPath("//input[@name='q']"));
            Assert.IsTrue(searchTextbox.Displayed);

            // Find by CSS
            searchTextbox = driver.FindElement(By.CssSelector("input[name='q']"));
            Assert.IsTrue(searchTextbox.Displayed);

            // Find by Name
            searchTextbox = driver.FindElement(By.Name("q"));
            Assert.IsTrue(searchTextbox.Displayed);

            searchTextbox.SendKeys(searchText);
            searchTextbox.SendKeys(Keys.Enter);

            Assert.IsTrue(driver.FindElement(By.XPath("(//div[@id=\"search\"]//a//h3)[1]")).Text.Contains(searchText));
        }

        [TearDown]
        public void TearDown()
        {
            logger.Info("Tear Down");
            NLog.LogManager.Shutdown();
            driver.Quit();
        }
    }
}