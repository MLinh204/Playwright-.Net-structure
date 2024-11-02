using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightTests.function;

namespace PlaywrightTests.page
{
    public class AccountCreatedPageObject
    {
        private readonly IPage page;
        private readonly MainFunction function;
        public AccountCreatedPageObject(IPage _page){
            page = _page;
            function = new MainFunction(_page);
        }

        public ILocator informMessage => page.Locator("//b");

        public ILocator continueBtn => page.Locator("//a[@class='btn btn-primary']");

        public async Task<bool> isInformMessageDisplayed() => await informMessage.IsVisibleAsync();

        public async Task clickContinueBtn() => await continueBtn.ClickAsync();
    }
}