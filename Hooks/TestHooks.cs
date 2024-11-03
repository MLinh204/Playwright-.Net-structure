using TechTalk.SpecFlow;
using BoDi;
using Microsoft.Playwright;

namespace PlaywrightTests
{
   [Binding]
    public class TestHooks
    {
        private static IPlaywright _playwright;
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        
        public TestHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static async Task BeforeAll()
        {
            _playwright = await Playwright.CreateAsync();
        }

        [AfterTestRun]
        public static void AfterAll()
        {
            _playwright?.Dispose();
            _playwright = null;
        }

        public static IPlaywright GetPlaywright()
        {
            return _playwright ?? throw new InvalidOperationException("Playwright instance not initialized");
        }
    }
}