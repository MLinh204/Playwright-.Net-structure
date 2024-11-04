using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightTests.Helpers;
using PlaywrightTests.page;

namespace PlaywrightTests
{
    public class TestContext
    {
        public IBrowser Browser { get; set; }
        public IPage Page { get; set; }
        public PageFactory Factory { get; set; }
        public MainFunction Function { get; set; }
        public LoginPageObject LoginPage { get; set; }
        public SignupPageObject SignupPage { get; set; }
        public AccountCreatedPageObject AccountCreatedPage { get; set; }
        public HomepageObject Homepage { get; set; }

        public async Task Initialize()
        {
            Browser = await TestHooks.GetPlaywright().Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var contextOptions = new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1920, Height = 1080 },
            };

            var context = await Browser.NewContextAsync(contextOptions);
            Page = await context.NewPageAsync();

            Page.SetDefaultTimeout(10000);

            Page.SetDefaultNavigationTimeout(10000);

            Factory = new PageFactory(Page);
            Function = new MainFunction(Page);
            LoginPage = new LoginPageObject(Page);
            SignupPage = new SignupPageObject(Page);
            AccountCreatedPage = new AccountCreatedPageObject(Page);
            Homepage = new HomepageObject(Page);
        }

        public async Task Cleanup()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
                Browser = null;
            }
        }
    }
}