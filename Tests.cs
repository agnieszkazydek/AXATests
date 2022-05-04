using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Xunit;


namespace GoogleMap
{
    public class Tests

    {
        [Fact]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl("https://www.google.pl/maps/");
                // Thread.Sleep(500000);
                driver.FindElement(By.CssSelector("div > form")).Click();
                



                Thread.Sleep(5000);

                IWebElement searchBox = driver.FindElement(By.Id("searchboxinput"));
                searchBox.Click();
                driver.FindElement(By.CssSelector("button[aria-label='Trasa']")).Click();
                driver.FindElement(By.CssSelector("img[aria-label='Na rowerze']")).Click();
                driver.FindElement(By.CssSelector("input[aria - label = 'Wybierz punkt początkowy lub kliknij mapę...']")).Click();



            }
        }
    }
}
