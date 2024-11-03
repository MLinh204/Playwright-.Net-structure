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
        public SignupStepDefinitions(TestContext context, ScenarioContext scenarioContext) 
            : base(context, scenarioContext)
        {
        }

        [BeforeScenario("Signup")]
        public async Task BeforeSignupScenario()
        {
            Console.WriteLine($"BeforeScenario executed for Signup: {ScenarioContext.ScenarioInfo.Title}");
            await Context.Initialize();
        }

        [AfterScenario("Signup")]
        public async Task AfterSignupScenario()
        {
            if (ScenarioContext.ScenarioInfo.Title == "Successful user registration")
            {
                await Homepage.deleteUser();
            }
            await Context.Cleanup();
        }

        [Given(@"I am on the signup page")]
        public async Task GivenIAmOnTheSignupPage()
        {
            await Function.GoTo(ConfigURL.SIGNUP_LOGIN_URL);
        }

        [When(@"I enter new user signup details")]
        public async Task WhenIEnterNewUserSignupDetails(Table table)
        {
            var details = table.Rows.ToDictionary(r => r["Field"], r => r["Value"]);
            await LoginPage.findSignUpInputByName("name").FillAsync(ConfigElement.TEST_USER);
            await LoginPage.findSignUpInputByName("email").FillAsync(ConfigElement.TEST_EMAIL);
        }

        [When(@"I enter existing user signup details")]
        public async Task WhenIEnterExistingUserSignupDetails(Table table)
        {
            var details = table.Rows.ToDictionary(r => r["Field"], r => r["Value"]);
            await LoginPage.findSignUpInputByName("name").FillAsync(ConfigElement.EXISTED_USERNAME);
            await LoginPage.findSignUpInputByName("email").FillAsync(ConfigElement.EXISTED_EMAIL);
        }

        [When(@"I click the signup button")]
        public async Task WhenIClickTheSignupButton()
        {
            await LoginPage.signupBtn.ClickAsync();
            await Page.WaitForTimeoutAsync(2000);
        }

        [When(@"I fill in the account details")]
        public async Task WhenIFillInTheAccountDetails(Table table)
        {
            await SignupPage.selectTitleByValue("Mr").ClickAsync();
            await SignupPage.fillInPassword(ConfigElement.TEST_PASSWORD);
            await SignupPage.selectDayByLabel("1");
            await SignupPage.selectMonthByLabel("January");
            await SignupPage.selectYearByLabel("2020");
            await SignupPage.fillInRequiredTextField(ConfigElement.SIGNUP_FIRSTNAME_NAME, ConfigElement.TEST_FIRSTNAME);
            await SignupPage.fillInRequiredTextField(ConfigElement.SIGNUP_LASTNAME_NAME, ConfigElement.TEST_LASTNAME);
            await SignupPage.fillInOptionalTextField(ConfigElement.SIGNUP_COMPANY_NAME, ConfigElement.TEST_COMPANY);
            await SignupPage.fillInRequiredTextField(ConfigElement.SIGNUP_ADDRESS1_NAME, ConfigElement.TEST_ADDRESS);
            await SignupPage.fillInRequiredTextField(ConfigElement.SIGNUP_ADDRESS2_NAME, ConfigElement.TEST_ADDRESS2);
            await SignupPage.selectCountryByLabel("Canada");
            await SignupPage.fillInRequiredTextField(ConfigElement.SIGNUP_STATE_NAME, ConfigElement.TEST_STATE);
            await SignupPage.fillInRequiredTextField(ConfigElement.SIGNUP_CITY_NAME, ConfigElement.TEST_CITY);
            await SignupPage.fillInRequiredTextField(ConfigElement.SIGNUP_ZIPCODE_NAME, ConfigElement.TEST_ZIPCODE);
            await SignupPage.fillInRequiredTextField(ConfigElement.SIGNUP_PHONE_NUMBER_NAME, ConfigElement.TEST_PHONE_NUMBER);
        }

        [When(@"I click create account button")]
        public async Task WhenIClickCreateAccountButton()
        {
            await SignupPage.clickCreateAccountBtn();
            await Page.WaitForTimeoutAsync(2000);
        }

        [Then(@"I should see the account created message")]
        public async Task ThenIShouldSeeTheAccountCreatedMessage()
        {
            Assert.IsTrue(await AccountCreatedPage.isInformMessageDisplayed());
            Assert.That(await AccountCreatedPage.informMessage.InnerTextAsync(),
                Is.EqualTo(ConfigElement.ACCOUNT_CREATED_MESSAGE));
            await AccountCreatedPage.clickContinueBtn();
            await Page.WaitForTimeoutAsync(2000);
        }

        [Then(@"I should be logged in successfully")]
        public async Task ThenIShouldBeLoggedInSuccessfully()
        {
            Assert.That(await Homepage.loggedInText.InnerTextAsync(),
                Is.EqualTo(ConfigElement.LOGGEDIN_TEXT_MESSAGE));
        }

        [Then(@"the signup page should be visible")]
        public async Task ThenTheSignupPageShouldBeVisible()
        {
            Assert.IsTrue(await LoginPage.isLoginPageVisible());
        }

        [Then(@"I should see email already exists message")]
        public async Task ThenIShouldSeeEmailAlreadyExistsMessage()
        {
            Assert.That(await LoginPage.emailExistedMessage.InnerTextAsync(),
                Is.EqualTo(ConfigElement.EMAIL_EXIST_MESSAGE));
        }
    }
}