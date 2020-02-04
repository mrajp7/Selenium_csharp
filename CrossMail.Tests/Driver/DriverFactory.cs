using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;

namespace CrossMail.Tests.Driver
{
    public static class DriverFactory
    {
         public static IWebDriver createDriverInstance(string browserName)
        {
            switch (browserName)
            {
                case "chrome":
                    return new ChromeDriver("./");
                case "edge":
                    //EdgeOptions opts = new EdgeOptions();
                    return new EdgeDriver("./");
                case "firefox":
                    return new FirefoxDriver("./");
                default:
                    throw new Exception("invalid driver request");
            }
        }

    }
}
