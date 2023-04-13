
using Framework.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace PlaywrightTests
{
    [TestFixture]
    public class BaseTest : IDisposable
    {
        public IConfigurationRoot settings;
        private string baseUrl;
        public IPlaywright _playwright;
        public BrowserTypeLaunchOptions _launchOptions;
        public PlaywrightDriver _playwrightDriver;


        public BaseTest() {}



        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            //Purge logs, screenshots, and reports here using Loghandler and reporthandler
            settings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            //FileUtils.DeleteFiles(Path.GetFullPath(Path.Combine(AppDomain.
            //CurrentDomain.BaseDirectory, settings.GetSection("fileSettings").GetSection("ScreenshotDir").Value)));
            //FileUtils.DeleteFolderAndFiles(Path.GetFullPath(Path.Combine(AppDomain.
            //CurrentDomain.BaseDirectory, settings.GetSection("fileSettings").GetSection("LogDir").Value)));

        }

        [SetUp]
        public async Task Setup()
        {
            PlaywrightDriver = new PlaywrightDriver();
            BrowserTypeLaunchOptions = new BrowserTypeLaunchOptions()
            {
                Headless = false,
                SlowMo = 2000

            };
            BaseUrl = settings.GetSection("urlSettings").GetSection("url").Value;
        }

        [TearDown]
        public void Teardown()
        {

        }

        public void Dispose()
        {

        }
        protected string BaseUrl
        {
            get
            {
                return baseUrl;
            }
            set
            {
                baseUrl = value;
            }
        }
       protected PlaywrightDriver PlaywrightDriver
        {
            get
            {
                return _playwrightDriver;
            }
            set
            {
                _playwrightDriver = value;
            }
        }
        protected BrowserTypeLaunchOptions BrowserTypeLaunchOptions
        {
            get
            {
                return _launchOptions;
            }
            set
            {
                _launchOptions = value;
            }
        }

    }
}
