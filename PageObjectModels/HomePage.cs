using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;


namespace GoogleMap
{
    public class HomePage
    {
   
        public IWebDriver driver;
        private object test;

        public object ExpectedConditions { get; private set; }

        protected IWebElement Way => driver.FindElement(By.CssSelector("button[aria-label='Trasa']"));
        protected IWebElement Chlodna => driver.FindElement(By.CssSelector("#directions-searchbox-0 input"));
        protected IWebElement PlacDefilad => driver.FindElement(By.CssSelector("#directions-searchbox-1 input"));
        protected IWebElement WalkButton => driver.FindElement(By.CssSelector("img[src*='walk']"));
        protected IWebElement BikeButton => driver.FindElement(By.CssSelector("img[src*='bike']"));
        protected IWebElement Time => driver.FindElement(By.CssSelector("#section-directions-trip-0 div[jsan*='fontHeadlineSmall']:nth-child(1)"));
        protected IWebElement Distance => driver.FindElement(By.CssSelector("#section-directions-trip-0 div[jsan*='fontBodyMedium']:nth-child(2)"));
        protected IWebElement Reverse => driver.FindElement(By.CssSelector("div.reverse"));
            
               
        public Tests TravelData()
        {
            string time = Time.Text;
            string distance = Distance.Text;
            string timeSplit = time.Split()[0];
            string distanceSplit = distance.Split()[0].Replace(",", ".");

            double timeValue = double.Parse(timeSplit);
            double distanceValue = double.Parse(distanceSplit);

            return new Tests(timeValue, distanceValue);


        }

        public void Setup(string browserName)
        {
            if (browserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }
            
            if (browserName.Equals("chrome"))
            {
                driver = new ChromeDriver();
            }
        }

        public static IEnumerable<string> BrowserToRunWith()
        {
            string[] browsers = { "chrome", "firefox" };

            foreach (string b in browsers)
            {
                yield return b;
            }
        }
    }
}
