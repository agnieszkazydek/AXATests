using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GoogleMap
{
    public class HomePage
    {
   
        public IWebDriver driver;

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
            string timeValue = Time.Text;
            string distanceValue = Distance.Text;
            timeValue = timeValue.Split()[0];
            distanceValue = distanceValue.Split()[0].Replace(",", ".");

            return new Tests (timeValue, distanceValue);

        }
    }
}
