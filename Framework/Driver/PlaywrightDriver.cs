
//using PlaywrightSharp;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using IBrowser = Microsoft.Playwright.IBrowser;
using IPage = Microsoft.Playwright.IPage;
using Playwright = Microsoft.Playwright.Playwright;


namespace Framework.Driver
{
    public enum TargetedBrowser
    {
        Chromium,
        firefox,
        WebKit
    }

    public class PlaywrightDriver
    {
        public IPage Page { get; set; }
        public IBrowser Browser { get; set; }
        public async Task InitializePlaywright(IPlaywright playwright, TargetedBrowser browser, BrowserTypeLaunchOptions launchOptions)
        {
            //await Playwright.InstallAsync();

            IBrowser pBrowser = null;
            if (browser == TargetedBrowser.Chromium)
                pBrowser = (IBrowser)await playwright.Chromium.LaunchAsync(launchOptions);
            if (browser == TargetedBrowser.firefox)
                pBrowser = (IBrowser)await playwright.Firefox.LaunchAsync(launchOptions);

            Browser = pBrowser;
         

        }
        
    }
}
