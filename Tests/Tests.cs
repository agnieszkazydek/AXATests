using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public void LoadApplicationPage()
        {
            ExtentTest test = extent.CreateTest("Fact").Info("Test Started");
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(MapsUrl);

            // driver.FindElement(By.CssSelector("div > form")).Click();

            Way.Click();
            Chlodna.SendKeys("Chłodna 51 Warszawa" + Keys.Enter);
            PlacDefilad.SendKeys("Plac Defilad 1" + Keys.Enter);
            WalkButton.Click();

            string timeWalk = TravelData().timeValue;
            string distanceWalk = TravelData().distanceValue;
            Assert.True(double.Parse(timeWalk) < 40);
            Assert.True(double.Parse(distanceWalk) < 3);

            BikeButton.Click();
            string timeBike = TravelData().timeValue;
            string distanceBike = TravelData().distanceValue;
            Assert.True(double.Parse(timeBike) < 15);
            Assert.True(double.Parse(distanceBike) < 3);

            Reverse.Click();
            string timeBikeReverse = TravelData().timeValue;
            string distanceBikeReverse = TravelData().distanceValue;
            Assert.True(double.Parse(timeBikeReverse) < 15);
            Assert.True(double.Parse(distanceBikeReverse) < 3);

            WalkButton.Click();
            string timeWalkReverse = TravelData().timeValue;
            string distanceWalkReverse = TravelData().distanceValue;
            Assert.True(double.Parse(timeWalkReverse) < 40);
            Assert.True(double.Parse(distanceWalkReverse) < 3);

            driver.Quit();            
        }
    }
}
