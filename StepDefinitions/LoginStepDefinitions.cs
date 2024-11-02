using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightTests.config;
using TechTalk.SpecFlow;

namespace PlaywrightTests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions : BaseSteps
    {
        [BeforeScenario("Login")]
        public async Task BeforeLoginScenario()
        {
            Console.WriteLine($"BeforeScenario executed for Login: {ScenarioContext.Current.ScenarioInfo.Title}");
            await InitializeBrowser();
        }

        [AfterScenario("Login")]
        public async Task AfterLoginScenario()
        {
            await CleanupBrowser();
        }

        [Given(@"I am on the login page")]
        public async Task IAmOnTheLoginPage()
        {
            await function.GoTo(ConfigURL.SIGNUP_LOGIN_URL);
        }

        [When(@"I enter valid values")]
        public async Task WhenIEnterValidValues(Table table)
        {
            var dictionary = table.Rows.ToDictionary(row => row["Field"], row => row["Value"]);

            foreach (var entry in dictionary)
            {
                string value = entry.Value
                    .Replace("{EXISTED_EMAIL}", ConfigElement.EXISTED_EMAIL)
                    .Replace("{EXISTED_PASSWORD}", ConfigElement.EXISTED_USER_PASSWORD);

                await loginPage.findLoginInputByName(entry.Key.ToLower()).FillAsync(value);
            }
        }
        [When(@"I click the login button")]
        public async Task clickLoginButton()
        {
            await loginPage.loginBtn.ClickAsync();
        }

        [Then(@"I should be logged in")]
        public async Task IShouldBeLoggedIn()
        {
            Assert.That(await homepage.loggedInText.InnerTextAsync(),
                Is.EqualTo(ConfigElement.LOGGEDIN_TEXT_EXISTED_USER_MESSAGE));
        }
        [When(@"I enter wrong email and correct Password")]
        public async Task WrongEmailOrPassword(Table table)
        {
            var dictionary = table.Rows.ToDictionary(row => row["Field"], row => row["Value"]);
            foreach (var entry in dictionary)
            {
                string value = entry.Value
                    .Replace("{EXISTED_PASSWORD}", ConfigElement.EXISTED_USER_PASSWORD);

                await loginPage.findLoginInputByName(entry.Key.ToLower()).FillAsync(value);
            }

        }
        [Then(@"The error message should be displayed")]
        public async Task IsErrorMessageDisplayed()
        {
            Assert.IsTrue(await loginPage.errorMessage.IsVisibleAsync());
            Assert.That(await loginPage.errorMessage.InnerTextAsync(), Is.EqualTo(ConfigElement.WRONG_AUTHENTICATION_MESSAGE));
        }
    }
}