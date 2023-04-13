using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObjects
{
    public class GoogleHome : BasePage
    {
        private IPage _page;
        string searchBox => "xpath=//input[contains(@name, 'q')]";

        public GoogleHome(IPage page) : base(page) {}

        public async Task<GoogleResults> PerformSearch(string searchText)
        {
            await Page.FillAsync(searchBox, searchText);
            await Page.Keyboard.PressAsync("Enter");
            return new GoogleResults(Page);

        }
    }
}
