using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace GoogleMap
{
    public class Tests : HomePage

    {
        private const string MapsUrl = "https://www.google.pl/maps/";

        ExtentReports extent = null;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\a.zydek\source\repos\Class\ExtentReports\GoogleMap.html");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }


        [Test]
        public void LoadApplicationPage()
        {
            // ExtentTest test = extent.CreateTest("Fact").Info("Test Started");
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(MapsUrl);

            // driver.FindElement(By.CssSelector("div > form")).Click();

            Way.Click();
            Chlodna.SendKeys("Chłodna 51 Warszawa" + Keys.Enter);
            PlacDefilad.SendKeys("Plac Defilad 1" + Keys.Enter);
            WalkButton.Click();

            /*var time = Time.Text;
            var distance = Distance.Text;
            time = time.Split()[0];
            distance = distance.Split()[0];*/

            


            var walkTime = Time.Text;
            var walkTimeValue = walkTime.Split()[0];
            TestContext.Out.WriteLine("dddd");
            var walkDistance = Distance.Text;
            var walkDistanceValue = walkDistance.Split()[0];

            BikeButton.Click();
            var bikeTime = Time.Text;
            var bikeTimeValue = bikeTime.Split()[0];
            var bikeDistance = Distance.Text;
            var bikeDistanceValue = bikeDistance.Split()[0];

            Reverse.Click();
            var bikeReverseTime = Time.Text;
            var bikeReverseTimeValue = bikeReverseTime.Split()[0];
            var bikeReverseDistance = Distance.Text;
            var bikeReverseDistanceValue = bikeReverseDistance.Split()[0];

            /* WalkButton.Click();
            string walkReverseTime = Time.Text;
            string walkReverseTimeValue = walkReverseTime.Split()[0];
            string walkReverseDistance = Distance.Text;
            string walkReverseDistanceValue = walkReverseDistance.Split()[0]; */
            driver.Quit();

             Assert.True(double.Parse(time) < 40 && double.Parse(distance) > 3);
            //Assert.True(double.Parse(bikeTimeValue) < 15 && double.Parse(bikeDistanceValue) < 3);
            //Assert.True(double.Parse(bikeReverseTimeValue) < 15 && double.Parse(bikeReverseDistanceValue) < 3);
            // Assert.True(Convert.ToInt32(walkReverseTimeValue) < 40 && Convert.ToInt32(walkReverseDistanceValue) > 3);

            
        }
    }
}
