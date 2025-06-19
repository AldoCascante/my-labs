using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UIAutomationTests
{
    public class Tests
    {
        IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(); 
        }

        [Test]
        public void Test1()
        {
            var URL = "http://localhost:8080/";

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(URL);

            string _paisBtnSelector = "#app > div.row.justify-content-end > div > a > button";
            string _nameFormSelector = "#name";
            string _continenteFormSelector = "#continente";
            string _continenteAsiaFormSelector = "#continente > option:nth-child(3)";
            string _idiomaFormSelector = "#idioma";
            string _submitFormPaisSelector = "#app > div.d-flex.justify-content-center.align-items-center.vh-100 > div > form > div:nth-child(4) > button";
            string _namePais = "Prueba";
            string _idiomaPais = "Español";


            IWebElement _paisBtnElement = _driver.FindElement(By.CssSelector(_paisBtnSelector));
            _paisBtnElement.Click();

            IWebElement _nameFormElement = _driver.FindElement(By.CssSelector(_nameFormSelector));
            _nameFormElement.SendKeys(_namePais);
            IWebElement _idiomaFormElement = _driver.FindElement(By.CssSelector(_idiomaFormSelector));
            _idiomaFormElement.SendKeys(_idiomaPais);
            IWebElement _continenteFormElement = _driver.FindElement(By.CssSelector(_continenteFormSelector));
            _continenteFormElement.Click();
            IWebElement _continenteAsiaFormElement = _driver.FindElement(By.CssSelector(_continenteAsiaFormSelector));
            _continenteAsiaFormElement.Click();
            IWebElement _submitFormPaisElement = _driver.FindElement(By.CssSelector(_submitFormPaisSelector));
            _submitFormPaisElement.Click();

            IAlert _alert = _driver.SwitchTo().Alert();
            string _alertText = _alert.Text;


            Assert.AreEqual(_alertText, "País agregado correctamente.");
        }
    }
}