using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace OBBSCucember.Steps
{
    [Binding]
    public class ObssSiteSteps
    {
        WebDriver driver;
        List<IWebElement> elements;
        public ObssSiteSteps()
        {
            driver = new ChromeDriver();
            elements = new List<IWebElement>();
        }
        [Given(@"Obss sayfasına Girilir")]
        public void GivenObssisOpen()
        {
            string url = "https://obss.com.tr/en/";
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"Çerez Kabul edilir")]
        public void FindAndClickCookieAcceptButton()
        {
            driver.FindElement(By.XPath($"//*[@id='cookieAcceptance']")).Click();
        }

        [Given(@"Search Ikonuna Tiklanir")]
        public void SearchIkonunaTiklanir()
        {
            driver.FindElement(By.XPath($"//*[@id='search-obss']")).Click();
        }

        [Given(@"Text Alanına Automation Yazilir Ve Enter Tusuna Basilir(.*)")]
        public void TextAlanınaAutomationYazilirVeEnteraBasilir(string Key)
        {
            driver.FindElement(By.XPath($"//*[@id='search-box']")).SendKeys(Key);
            driver.FindElement(By.XPath($"//*[@id='search-box']")).SendKeys(Keys.Enter);
        }
        [Then(@"Sonuclarin Geldigi Dogrulanir")]
        public void SonuclarinGeldigiDogrulanir()
        {
            elements = driver.FindElements(By.TagName("article")).ToList();
        }
        [When(@"Cikan Sonuclardan İlkine Tiklanir")]
        public void CikanSonuclardanIlkineTiklanir()
        {
            elements.FirstOrDefault().FindElement(By.TagName("a")).Click();
        }
        [Then(@"Testing Autamation sayfasi oldugu dogurlanir")]
        public void TestingAutamationSayfasiOlduguDogurlanir()
        {
            if (driver.Url == "https://obss.com.tr/en/yetkinlikler/yetenekler/yazilim-testi-otomasyonu/")
            {
                var footer = driver.FindElement(By.ClassName("footer-copyright-container"));
                if (footer != null)
                {
                    var location = footer.Location;
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript($"window.scrollBy({location.X},{location.Y})", "");
                }

            }
        }

    }
}
