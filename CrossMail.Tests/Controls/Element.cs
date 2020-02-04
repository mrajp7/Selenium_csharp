using System;
using System.Threading;
using CrossMail.Tests.Enum;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CrossMail.Tests.Controls
{
    public class Element
    {
        protected static IWebDriver Driver { get; set; }
        protected By Selector { get; set; }

        public Element(By selector) => Selector = selector;

        public static void InitDriver(IWebDriver driver) => Driver = driver;

        public bool isEnabled() => Driver.FindElement(Selector).Enabled;

        public string Text => Driver.FindElement(Selector).Text;

        public virtual void Click() => Driver.FindElement(Selector).Click();

        public void WaitForElement(Enum.WaitForElement seconds)
        {
            WebDriverWait _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds((int)seconds));
            _wait.Until(ExpectedConditions.ElementExists(Selector));
        }

    }
}
