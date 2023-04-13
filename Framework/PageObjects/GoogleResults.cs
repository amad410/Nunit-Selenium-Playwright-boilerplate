using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObjects
{
    public class GoogleResults : BasePage
    {
        private IPage _page;
        string resultLinks => "xpath=//h1";
        public GoogleResults(IPage page) : base(page) { }

        public async Task<Boolean> IsResultsDisplayed()
        {
            var results = await Page.Locator(resultLinks).CountAsync();
            return results > 0;

        }
    }
}
