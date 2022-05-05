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

        protected IWebElement Distance => driver.FindElement(By.CssSelector("button[aria-label='Trasa']"));
        protected IWebElement Chlodna => driver.FindElement(By.CssSelector("#directions-searchbox-0 input"));
        IWebElement PlacDefilad => driver.FindElement(By.CssSelector("#directions-searchbox-1 input"));
        IWebElement GoImg => driver.FindElement(By.CssSelector("img[aria-label='Pieszo']"));
        IWebElement GoingTime => driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.Fk3sm.fontHeadlineSmall"));
        IWebElement GoingDistance => driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.MespJc > div:nth-child(3) > div.XdKEzd > div.ivN21e.tUEI8e.fontBodyMedium"));

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
