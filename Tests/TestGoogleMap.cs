using OpenQA.Selenium;
using System;
using Xunit;



namespace GoogleMap
{
    public class Tests : HomePage

    {
        private const string MapsUrl = "https://www.google.pl/maps/";


    [Fact]
        public void CheckDistance()
        {
 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(MapsUrl);
            
            driver.FindElement(By.CssSelector("div > form")).Click();

            Distance.Click();
            Chlodna.SendKeys("Chłodna 51 Warszawa" + Keys.Enter);

            driver.FindElement(By.CssSelector("#directions-searchbox-1 input")).SendKeys("Plac Defilad 1" + Keys.Enter);

            driver.FindElement(By.CssSelector("img[aria-label='Pieszo']")).Click();

            IWebElement goingTime = driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.Fk3sm.fontHeadlineSmall"));
                string goingTimeValue = goingTime.Text;

            IWebElement goingDistance =  driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.ivN21e.tUEI8e.fontBodyMedium"));
                string goingDistanceValue = goingDistance.Text;

            // ----------------- 

            driver.FindElement(By.CssSelector("img[aria-label='Na rowerze']")).Click();

            IWebElement bicycleTime = driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.Fk3sm.fontHeadlineSmall"));
                string bicycleTimeValue = bicycleTime.Text;


            IWebElement bicycleDistance = driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.ivN21e.tUEI8e.fontBodyMedium"));
                string bicycleDistanceValue = bicycleDistance.Text;

            driver.FindElement(By.ClassName("reverse")).Click();

            driver.FindElement(By.CssSelector("img[aria-label='Pieszo']")).Click();


            string reserveGoingTimeValue = goingTime.Text;
            string reserveGoingDistanceValue = goingDistance.Text;


            driver.FindElement(By.CssSelector("img[aria-label='Na rowerze']")).Click();

            string reserveBicycleTimeValue = bicycleTime.Text;
            string reserveBicycleDistanceValue = bicycleDistance.Text;

            Assert.True(Convert.ToInt32(bicycleTimeValue) < 40 && Convert.ToInt32(bicycleDistanceValue)  < 3);
            Assert.True(Convert.ToInt32(bicycleTimeValue) < 40 && Convert.ToInt32(bicycleDistanceValue) < 3);
            Assert.True(Convert.ToInt32(reserveGoingTimeValue) < 40 && Convert.ToInt32(reserveGoingDistanceValue) < 3);
            Assert.True(Convert.ToInt32(reserveBicycleTimeValue) < 40 && Convert.ToInt32(reserveBicycleDistanceValue) < 3);

        }
    }
}
