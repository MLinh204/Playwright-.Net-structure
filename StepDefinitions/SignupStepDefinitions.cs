using TechTalk.SpecFlow;
using Microsoft.Playwright;
using PlaywrightTests.page;
using PlaywrightTests.config;
using PlaywrightTests.function;
using NUnit.Framework;

namespace PlaywrightTests.StepDefinitions
{
    [Binding]
    public class SignupStepDefinitions : BaseSteps
    {
        [BeforeScenario("Signup")]
        public async Task BeforeSignupScenario()
        {
            Console.WriteLine($"BeforeScenario executed for Signup: {ScenarioContext.Current.ScenarioInfo.Title}");
            await InitializeBrowser();
        }

        [AfterScenario("Signup")]
        public async Task AfterSignupScenario()
        {
            if (ScenarioContext.Current.ScenarioInfo.Title == "Successful user registration")
            {
                await homepage.deleteUser();
            }
            await CleanupBrowser();
        }

        [Given(@"I am on the signup page")]
        public async Task GivenIAmOnTheSignupPage()
        {
            await function.GoTo(ConfigURL.SIGNUP_LOGIN_URL);
        }

        [When(@"I enter new user signup details")]
        public async Task WhenIEnterNewUserSignupDetails(Table table)
        {
            var details = table.Rows.ToDictionary(r => r["Field"], r => r["Value"]);
            await loginPage.findSignUpInputByName("name").FillAsync(ConfigElement.TEST_USER);
            await loginPage.findSignUpInputByName("email").FillAsync(ConfigElement.TEST_EMAIL);
        }

        [When(@"I enter existing user signup details")]
        public async Task WhenIEnterExistingUserSignupDetails(Table table)
        {
            var details = table.Rows.ToDictionary(r => r["Field"], r => r["Value"]);
            await loginPage.findSignUpInputByName("name").FillAsync(ConfigElement.EXISTED_USERNAME);
            await loginPage.findSignUpInputByName("email").FillAsync(ConfigElement.EXISTED_EMAIL);
        }

        [When(@"I click the signup button")]
        public async Task WhenIClickTheSignupButton()
        {
            await loginPage.signupBtn.ClickAsync();
            await page.WaitForTimeoutAsync(2000);
        }

        [When(@"I fill in the account details")]
        public async Task WhenIFillInTheAccountDetails(Table table)
        {
            await signupPage.selectTitleByValue("Mr").ClickAsync();
            await signupPage.fillInPassword(ConfigElement.TEST_PASSWORD);
            await signupPage.selectDayByLabel("1");
            await signupPage.selectMonthByLabel("January");
            await signupPage.selectYearByLabel("2020");
            await signupPage.fillInRequiredTextField(ConfigElement.SIGNUP_FIRSTNAME_NAME, ConfigElement.TEST_FIRSTNAME);
            await signupPage.fillInRequiredTextField(ConfigElement.SIGNUP_LASTNAME_NAME, ConfigElement.TEST_LASTNAME);
            await signupPage.fillInOptionalTextField(ConfigElement.SIGNUP_COMPANY_NAME, ConfigElement.TEST_COMPANY);
            await signupPage.fillInRequiredTextField(ConfigElement.SIGNUP_ADDRESS1_NAME, ConfigElement.TEST_ADDRESS);
            await signupPage.fillInRequiredTextField(ConfigElement.SIGNUP_ADDRESS2_NAME, ConfigElement.TEST_ADDRESS2);
            await signupPage.selectCountryByLabel("Canada");
            await signupPage.fillInRequiredTextField(ConfigElement.SIGNUP_STATE_NAME, ConfigElement.TEST_STATE);
            await signupPage.fillInRequiredTextField(ConfigElement.SIGNUP_CITY_NAME, ConfigElement.TEST_CITY);
            await signupPage.fillInRequiredTextField(ConfigElement.SIGNUP_ZIPCODE_NAME, ConfigElement.TEST_ZIPCODE);
            await signupPage.fillInRequiredTextField(ConfigElement.SIGNUP_PHONE_NUMBER_NAME, ConfigElement.TEST_PHONE_NUMBER);
        }

        [When(@"I click create account button")]
        public async Task WhenIClickCreateAccountButton()
        {
            await signupPage.clickCreateAccountBtn();
            await page.WaitForTimeoutAsync(2000);
        }

        [Then(@"I should see the account created message")]
        public async Task ThenIShouldSeeTheAccountCreatedMessage()
        {
            Assert.IsTrue(await accountCreatedPage.isInformMessageDisplayed());
            Assert.That(await accountCreatedPage.informMessage.InnerTextAsync(),
                Is.EqualTo(ConfigElement.ACCOUNT_CREATED_MESSAGE));
            await accountCreatedPage.clickContinueBtn();
            await page.WaitForTimeoutAsync(2000);
        }

        [Then(@"I should be logged in successfully")]
        public async Task ThenIShouldBeLoggedInSuccessfully()
        {
            Assert.That(await homepage.loggedInText.InnerTextAsync(),
                Is.EqualTo(ConfigElement.LOGGEDIN_TEXT_MESSAGE));
        }

        [Then(@"the signup page should be visible")]
        public async Task ThenTheSignupPageShouldBeVisible()
        {
            Assert.IsTrue(await loginPage.isLoginPageVisible());
        }

        [Then(@"I should see email already exists message")]
        public async Task ThenIShouldSeeEmailAlreadyExistsMessage()
        {
            Assert.That(await loginPage.emailExistedMessage.InnerTextAsync(),
                Is.EqualTo(ConfigElement.EMAIL_EXIST_MESSAGE));
        }
    }
}