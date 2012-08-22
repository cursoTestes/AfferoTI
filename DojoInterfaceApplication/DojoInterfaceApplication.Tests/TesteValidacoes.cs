using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class TesteValidacoes
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:58034";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }



        [TestMethod]
        public void Retorna_para_home_quando_campos_obrigatorios_forem_informados()
        {
            Redirecionar_para_url_venda();

            driver.FindElement(By.Id("Vendedor")).SendKeys("teste");
            driver.FindElement(By.Id("DataVenda")).SendKeys("10/01/2011");
            driver.FindElement(By.Id("Valor")).SendKeys("10");

            Click_No_Botao_Add();

            Assert.AreEqual(baseURL+"/" , driver.Url);
            
        }

        [TestMethod]
        public void Retorna_para_home_quando_campos_obrigatorios_forem_informados_data_invalida()
        {
            Redirecionar_para_url_venda();

            driver.FindElement(By.Id("Vendedor")).SendKeys("teste");
            driver.FindElement(By.Id("DataVenda")).SendKeys("dasdasdsa");
            driver.FindElement(By.Id("Valor")).SendKeys("10");

            Click_No_Botao_Add();

            Assert.AreEqual(baseURL + "/", driver.Url);

        }

        private void Redirecionar_para_url_venda()
        {
          driver.Navigate().GoToUrl(baseURL + "/Venda/Add");
        }

        private void Click_No_Botao_Add()
        {            
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Thread.Sleep(1000);
        }

        

        
    }
}
