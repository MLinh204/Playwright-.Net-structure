using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightTests.function;

namespace PlaywrightTests.page
{
    public class HomepageObject
    {
        private readonly IPage page;
        private readonly MainFunction function;
        public HomepageObject(IPage _page){
            page = _page;
            function = new MainFunction(_page);
        }
        public ILocator loggedInText => page.Locator("//a[i[contains(@class, 'fa fa-user')]]");
        public ILocator deleteUserBtn => page.Locator("//a[i[contains(@class, 'fa fa-trash-o')]]");

        public async Task<string> getLoggedInText() {
            return await loggedInText.InnerTextAsync();
        }

        public ILocator deleteAccountMessage => page.Locator("//b");

        public async Task deleteUser(){
            try{
            await deleteUserBtn.ClickAsync();
            await page.WaitForTimeoutAsync(2000);
            Assert.IsTrue(await deleteAccountMessage.IsVisibleAsync());
            } catch (Exception e){
                Console.WriteLine($"Failed to delete test user: {e.Message}");
            }
        }          
    }
}