using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;

namespace CrossMail.Tests
{
    public class Testbase : IDisposable
    {

        private readonly IWebDriver _browserDriver;
        public IWebDriver BrowserDriver
        {
            get;
        }
        
        public IConfiguration Config
        {
            get;
            set;
        }

        public Testbase()
        {
            Config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
            _browserDriver = Driver.DriverFactory.createDriverInstance(Config["browser"]);
            Controls.Element.InitDriver(_browserDriver);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool managed)
        {
            if (managed)
            {
                _browserDriver.Quit();
                _browserDriver.Dispose();
            }
        }

        public void LoadGmail()
        {
            _browserDriver.Navigate().GoToUrl(new Uri("https://mail.google.com/"));
        }

    }
}
