using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightTests.function;
using PlaywrightTests.page;
using TechTalk.SpecFlow;


namespace PlaywrightTests.StepDefinitions
{
    public abstract class BaseSteps
    {
        protected static IPlaywright playwright;
        protected IBrowser browser;
        protected IPage page;
        protected PageFactory factory;
        protected MainFunction function;
        protected LoginPageObject loginPage;
        protected SignupPageObject signupPage;
        protected AccountCreatedPageObject accountCreatedPage;
        protected HomepageObject homepage;

        protected async Task InitializeBrowser()
        {
            if (playwright == null)
            {
                lock (typeof(BaseSteps))
                {
                    if (playwright == null)
                    {
                        playwright = Task.Run(async () => await Playwright.CreateAsync()).Result;
                    }
                }
            }

            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var contextOptions = new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1920, Height = 1080 }
            };
            var context = await browser.NewContextAsync(contextOptions);
            page = await context.NewPageAsync();

            factory = new PageFactory(page);
            function = new MainFunction(page);
            loginPage = new LoginPageObject(page);
            signupPage = new SignupPageObject(page);
            accountCreatedPage = new AccountCreatedPageObject(page);
            homepage = new HomepageObject(page);
        }

        protected async Task CleanupBrowser()
        {
            if (browser != null)
            {
                await browser.CloseAsync();
            }
        }

        [AfterTestRun]
        public static async Task AfterAll()
        {
            if (playwright != null)
            {
                playwright.Dispose();
                playwright = null;
            }
        }
    }
}