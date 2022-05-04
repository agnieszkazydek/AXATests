using Class;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Xunit;


namespace GoogleMap
{
    public class Tests : Utilis.Selectors

    {
        private const string MapsUrl = "https://www.google.pl/maps/";

        [Fact]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(MapsUrl);
                // Thread.Sleep(500000);
                // driver.FindElement(By.CssSelector("div > form")).Click();
                



                Thread.Sleep(10000);
                driver.FindElement(By.CssSelector("button[aria-label='Trasa']")).Click();
                Thread.Sleep(10000);


                driver.FindElement(By.CssSelector("#directions-searchbox-0 input")).SendKeys("Chłodna 51 Warszawa" + Keys.Enter);
                Thread.Sleep(10000);
                driver.FindElement(By.CssSelector("#directions-searchbox-1 input")).SendKeys("Plac Defilad 1" + Keys.Enter);
                Thread.Sleep(15000);

                driver.FindElement(By.CssSelector("img[aria-label='Pieszo']")).Click();
                Thread.Sleep(15000);


                IWebElement time = driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.Fk3sm.fontHeadlineSmall"));
                string timeValue = time.Text;
                Thread.Sleep(15000);
                Console.WriteLine("timeVale" + timeValue);
                Thread.Sleep(15000);
                IWebElement distance =  driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.ivN21e.tUEI8e.fontBodyMedium"));
                string distanceValue = time.Text;
                Thread.Sleep(15000);
                Console.WriteLine("distanceVale" + distanceValue);


                driver.FindElement(By.CssSelector("img[aria-label='Na rowerze']")).Click();
                Thread.Sleep(15000);

                IWebElement time2 = driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.Fk3sm.fontHeadlineSmall"));
                string timeValue2 = time2.Text;
                Thread.Sleep(15000);
                Console.WriteLine("timeVale" + timeValue2);
                Thread.Sleep(15000);
                IWebElement distance2 = driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.ivN21e.tUEI8e.fontBodyMedium"));
                string distanceValue2 = distance2.Text;
                Thread.Sleep(15000);
                Console.WriteLine("distanceVale" + distanceValue2);

                driver.FindElement(By.ClassName("reverse")).Click();

                Thread.Sleep(15000);

                driver.FindElement(By.CssSelector("img[aria-label='Pieszo']")).Click();
                Thread.Sleep(15000);


                IWebElement time = driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.Fk3sm.fontHeadlineSmall"));
                string timeValue = time.Text;
                Thread.Sleep(15000);
                Console.WriteLine("timeVale" + timeValue);
                Thread.Sleep(15000);
                IWebElement distance = driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.ivN21e.tUEI8e.fontBodyMedium"));
                string distanceValue = time.Text;
                Thread.Sleep(15000);
                Console.WriteLine("distanceVale" + distanceValue);


                driver.FindElement(By.CssSelector("img[aria-label='Na rowerze']")).Click();
                Thread.Sleep(15000);

                IWebElement time2 = driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.Fk3sm.fontHeadlineSmall"));
                string timeValue2 = time2.Text;
                Thread.Sleep(15000);
                Console.WriteLine("timeVale" + timeValue2);
                Thread.Sleep(15000);
                IWebElement distance2 = driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.ivN21e.tUEI8e.fontBodyMedium"));
                string distanceValue2 = distance2.Text;
                Thread.Sleep(15000);
                Console.WriteLine("distanceVale" + distanceValue2);




            }
        }
    }
}
