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

        protected IWebElement Way => driver.FindElement(By.CssSelector("button[aria-label='Trasa']"));
        protected IWebElement Chlodna => driver.FindElement(By.CssSelector("#directions-searchbox-0 input"));
        protected IWebElement PlacDefilad => driver.FindElement(By.CssSelector("#directions-searchbox-1 input"));
        protected IWebElement WalkButton => driver.FindElement(By.CssSelector("img[src*='walk']"));
        protected IWebElement BikeButton => driver.FindElement(By.CssSelector("img[src*='bike']"));
        protected IWebElement Time => driver.FindElement(By.CssSelector("#section-directions-trip-0 div[jsan*='fontHeadlineSmall']:nth-child(1)"));
        protected IWebElement Distance => driver.FindElement(By.CssSelector("#section-directions-trip-0 div[jsan*='fontBodyMedium']:nth-child(2)"));
        protected IWebElement Reverse => driver.FindElement(By.ClassName("reverse"));
        public void Browser()
        {
            driver = new ChromeDriver();
        }

        

        private const string PageUrl = "https://www.google.pl/maps/";
        private const string PageTitle = "Mapy Google";


        
            

        }

    internal class SetUpAttribute : Attribute
    {
    }

    public void NavigateTo()
        {
            driver.Navigate().GoToUrl(PageUrl);

            EnsurePageLoaded();
        }

        public void EnsurePageLoaded()
        {
            bool pageHasLoaded = (driver.Url == PageUrl) && (driver.Title == PageTitle);

            if (!pageHasLoaded)
            {
                driver.FindElement(By.CssSelector("div > form")).Click();
            }
        }
 
    }
}
