using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace TrainingCsharpSelenium
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            string driverPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\browserDrivers\";
            
            driver = new ChromeDriver(driverPath);
            // driver = new FirefoxDriver(driverPath);
            // driver = new OperaDriver(driverPath);
            // driver = new EdgeDriver(driverPath);

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test]
        public void Test1()
        {
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
            driver.Quit();
        }
    }
}