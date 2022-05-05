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

            Way.Click();
            Chlodna.SendKeys("Chłodna 51 Warszawa" + Keys.Enter);
            PlacDefilad.SendKeys("Plac Defilad 1" + Keys.Enter);
            WalkButton.Click();
            string walkTimeValue = Time.Text;
            string walkDistanceValue = Distance.Text;

            BikeButton.Click();
            string bikeTimeValue = Time.Text;
            string bikeDistanceValue = Distance.Text;

            Reverse.Click();
            string bikeReverseTimeValue = Time.Text;
            string bikeReverseDistanceValue = Distance.Text;

            WalkButton.Click();
            string walkReverseTimeValue = Time.Text;
            string walkReverseDistanceValue = Distance.Text;


            Assert.True(Convert.ToInt32(walkTimeValue) < 40 && Convert.ToInt32(walkDistanceValue)  < 3);
            Assert.True(Convert.ToInt32(bikeTimeValue) < 15 && Convert.ToInt32(bikeDistanceValue) < 3);
            Assert.True(Convert.ToInt32(bikeReverseTimeValue) < 15 && Convert.ToInt32(bikeReverseDistanceValue) < 3);
            Assert.True(Convert.ToInt32(walkReverseTimeValue) < 40 && Convert.ToInt32(walkReverseDistanceValue) < 3);

        }
    }
}
