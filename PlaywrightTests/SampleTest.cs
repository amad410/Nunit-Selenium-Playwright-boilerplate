// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using FluentAssertions;
using Framework.Driver;
using Framework.PageObjects;
using Microsoft.Playwright;
using NUnit.Framework;
///using PlaywrightSharp;
using System;
using System.Threading.Tasks;
using IPage = Microsoft.Playwright.IPage;
using Playwright = Microsoft.Playwright.Playwright;

namespace PlaywrightTests
{

    [TestFixture(TargetedBrowser.Chromium)]
    //[TestFixture(TargetedBrowser.WebKit)]
    //[TestFixture(TargetedBrowser.firefox)]
    [Parallelizable(ParallelScope.All)]
    public class SampleTest : BaseTest, IDisposable
    {
        public TargetedBrowser _browser;
        public GoogleHome _googleHome;
        public GoogleResults _googleResults;
        public IPlaywright _playwright;
        public BrowserTypeLaunchOptions launchOptions;
        PlaywrightDriver _playwrightDriver;
        public IBrowserContext _context;

        public SampleTest(TargetedBrowser browser) : base() {
            _browser = browser;
        
        }

        [Test]
        public async Task TestMethod1()
        {
            _playwright = await Playwright.CreateAsync();

            await PlaywrightDriver.InitializePlaywright(_playwright, _browser, BrowserTypeLaunchOptions);
            _context = await PlaywrightDriver.Browser.NewContextAsync();
           var page = await _context.Browser.NewPageAsync();
           await page.SetViewportSizeAsync(1920, 1080);
            await page.GotoAsync(BaseUrl, new PageGotoOptions
            {
                WaitUntil = WaitUntilState.Load,
                Timeout = 60000

            });

            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = String.Format("ScreenShot_{0}.png", DateTime.Now.ToString("yyyyMMddHHmmssfff"))
            });

            _googleHome = new GoogleHome(page);
            _googleResults = await _googleHome.PerformSearch("Playwright");
            _googleResults.IsResultsDisplayed().Should().Equals(true);
           
        }

        [Test]
        public async Task TestMethod2()
        {
            _playwright = await Playwright.CreateAsync();

            await PlaywrightDriver.InitializePlaywright(_playwright, _browser, BrowserTypeLaunchOptions);
            _context = await PlaywrightDriver.Browser.NewContextAsync();
            var page = await _context.Browser.NewPageAsync();
            await page.SetViewportSizeAsync(1920, 1080);
            // await page.GotoAsync(BaseUrl);
            await page.GotoAsync(BaseUrl, new PageGotoOptions
            {
                WaitUntil = WaitUntilState.Load,
                Timeout = 60000

            });

            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = String.Format("ScreenShot_{0}.png", DateTime.Now.ToString("yyyyMMddHHmmssfff"))
            });

            _googleHome = new GoogleHome(page);
            _googleResults = await _googleHome.PerformSearch("Selenium");
            _googleResults.IsResultsDisplayed().Should().Equals(true);
        }


        public async Task Dispose()
        {
            //dispose here
            await _context.CloseAsync();
        }
    }
}
