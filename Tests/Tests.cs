using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System.Collections.Generic;

namespace GoogleMap
{
    [TestFixture]
    public class Tests : HomePage

    {
        public Tests() { }

        private string timeValue;
        private string distanceValue;
        public Tests(string timeValue, string distanceValue)
        {
            this.timeValue = timeValue;
            this.distanceValue = distanceValue;
        }

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
        public void CheckTravelData()
        {
            ExtentTest test = extent.CreateTest("CheckTravelData").Info("Test Started");
            driver = new ChromeDriver();
            
            driver.Navigate().GoToUrl(MapsUrl);
            test.Log(Status.Info, "Opened URL");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Way.Click();
            Chlodna.SendKeys("Chłodna 51 Warszawa" + Keys.Enter);
            PlacDefilad.SendKeys("Plac Defilad 1" + Keys.Enter);
            WalkButton.Click();

            string timeWalk = TravelData().timeValue;
            string distanceWalk = TravelData().distanceValue;
            Assert.True(double.Parse(timeWalk) < 40 && double.Parse(distanceWalk) < 3);
            test.Log(Status.Info, "Way from Chłodna 51 to Plac Defilad 1 takes less than 3 km and less than 40 minutes on foot");

            BikeButton.Click();
            string timeBike = TravelData().timeValue;
            string distanceBike = TravelData().distanceValue;
            Assert.True(double.Parse(timeBike) < 15 && double.Parse(distanceBike) < 3);
            test.Log(Status.Info, "Way from Chłodna 51 to Plac Defilad 1 takes less than 3 km and less than 15 minutes using a bike");

            Reverse.Click();
            string timeBikeReverse = TravelData().timeValue;
            string distanceBikeReverse = TravelData().distanceValue;
            Assert.True(double.Parse(timeBikeReverse) < 15 && double.Parse(distanceBikeReverse) < 3);
            test.Log(Status.Info, "Way from Plac Defilad 1 to Chłodna 51 takes less than 3 km and less than 15 minutes using a bike");

            WalkButton.Click();
            string timeWalkReverse = TravelData().timeValue;
            string distanceWalkReverse = TravelData().distanceValue;
            Assert.True(double.Parse(timeWalkReverse) < 40 && double.Parse(distanceWalkReverse) < 3);
            test.Log(Status.Info, "Way from Plac Defilad 1 to Chłodna 51 takes less than 3 km and less than 40 minutes on foot");

            driver.Quit();

            test.Log(Status.Pass, "Test Passed");
           
        }
    }
}
