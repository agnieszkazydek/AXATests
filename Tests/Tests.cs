using OpenQA.Selenium;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

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

            ExtentTest test = extent.CreateTest("CheckTravelData").Info("Test Started");

            Setup(browserName);

            driver.Navigate().GoToUrl(MapsUrl);
            test.Log(Status.Info, "Opened URL");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Way.Click();
            Chlodna.SendKeys("Chłodna 51 Warszawa" + Keys.Enter);
            PlacDefilad.SendKeys("Plac Defilad 1" + Keys.Enter);

            WalkButton.Click();
            Assert.True(TravelData().timeValue < 40 && TravelData().distanceValue < 3);
            test.Log(Status.Info, $"Expected walking time from Chłodna 51 to Plac Defilad 1 is < 40, Actual {TravelData().timeValue}");
            test.Log(Status.Info, $"Expected walking distance from Chłodna 51 to Plac Defilad 1 is < 3, Actual {TravelData().distanceValue}");

            BikeButton.Click();
            Assert.True(TravelData().timeValue < 15 && TravelData().distanceValue < 3);
            test.Log(Status.Info, $"Expected cycling time from Chłodna 51 to Plac Defilad 1 is < 15, Actual {TravelData().timeValue}");
            test.Log(Status.Info, $"Expected cycling distance from Chłodna 51 to Plac Defilad 1 is < 3, Actual {TravelData().distanceValue}");

            Reverse.Click();
            Assert.True(TravelData().timeValue < 15 && TravelData().distanceValue < 3);
            test.Log(Status.Info, $"Expected cycling time from Plac Defilad 1 to Chłodna 51  is < 15, Actual {TravelData().timeValue}");
            test.Log(Status.Info, $"Expected cycling distance from Plac Defilad 1 to Chłodna 51 1 is < 3, Actual {TravelData().distanceValue}");

            WalkButton.Click();
            Assert.True(TravelData().timeValue < 40 && TravelData().distanceValue < 3);
            test.Log(Status.Info, $"Expected walking time from Plac Defilad 1 to Chłodna 51  is < 40, Actual {TravelData().timeValue}");
            test.Log(Status.Info, $"Expected walking distance from Plac Defilad 1 to Chłodna 51 1 is < 3, Actual {TravelData().distanceValue}");

            driver.Dispose();

            test.Log(Status.Pass, "Test Passed");
           
        }
     }
}
