using OpenQA.Selenium;
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

        private double timeValue;
        private double distanceValue;
        public Tests(double timeValue, double distanceValue)
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
        [TestCaseSource(typeof(HomePage), "BrowserToRunWith")]
        public void CheckTravelData(string browserName)
        {
            var travelWayList = new List<string>();
            travelWayList.Add("Walking");
            travelWayList.Add("Cycling");

            var travelDataList = new List<string>();
            travelDataList.Add("time");
            travelDataList.Add("distance");

            var streetsList = new List<string>();
            streetsList.Add("Chłodna 51");
            streetsList.Add("Plac Defilad 1");

            ExtentTest test = extent.CreateTest("CheckTravelData").Info("Test Started");

            Setup(browserName);

            driver.Navigate().GoToUrl(MapsUrl);
            test.Log(Status.Info, "Opened URL");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Way.Click();
            Chlodna.SendKeys(streetsList[0] + Keys.Enter);
            PlacDefilad.SendKeys(streetsList[1] + Keys.Enter);

            WalkButton.Click();
            Assert.True(TravelData().timeValue < 40 && TravelData().distanceValue < 3);
            test.Log(Status.Info, $"{travelWayList[0]} {travelDataList[0]} from {streetsList[0]} to {streetsList[1]} is < 40 min and {travelDataList[1]} < 3 km");

            BikeButton.Click();
            Assert.True(TravelData().timeValue < 15 && TravelData().distanceValue < 3);
            test.Log(Status.Info, $"{travelWayList[1]} {travelDataList[0]} from {streetsList[0]} to {streetsList[1]} is < 15 min and {travelDataList[1]} < 3 km");

            Reverse.Click();
            Assert.True(TravelData().timeValue < 15 && TravelData().distanceValue < 3);
            test.Log(Status.Info, $"{travelWayList[1]} {travelDataList[0]} from {streetsList[1]} to {streetsList[0]} is < 15 min and {travelDataList[1]} < 3 km");

            WalkButton.Click();
            Assert.True(TravelData().timeValue < 40 && TravelData().distanceValue < 3);
            test.Log(Status.Info, $"{travelWayList[0]} {travelDataList[0]} from {streetsList[1]} to {streetsList[0]} is < 40 min and {travelDataList[1]} < 3 km");

            driver.Dispose();

            test.Log(Status.Pass, "Test Passed");
           
        }
     }
}
