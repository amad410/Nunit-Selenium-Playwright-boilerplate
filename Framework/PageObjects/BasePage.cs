using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObjects
{
    public class BasePage
    {
        private IBrowser _browser;
        private IPage _page;
        public BasePage(IPage page) {

            Page = page;
        }

        public IPage Page { get; set; }

    }
}
