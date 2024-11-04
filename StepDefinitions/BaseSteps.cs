using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightTests.Helpers;
using PlaywrightTests.page;
using TechTalk.SpecFlow;


namespace PlaywrightTests.StepDefinitions
{
    public abstract class BaseSteps
    {
        protected readonly TestContext Context;
        protected readonly ScenarioContext ScenarioContext;

        protected BaseSteps(TestContext context, ScenarioContext scenarioContext)
        {
            Context = context;
            ScenarioContext = scenarioContext;
        }

        protected IPage Page => Context.Page;
        protected PageFactory Factory => Context.Factory;
        protected MainFunction Function => Context.Function;
        protected LoginPageObject LoginPage => Context.LoginPage;
        protected SignupPageObject SignupPage => Context.SignupPage;
        protected AccountCreatedPageObject AccountCreatedPage => Context.AccountCreatedPage;
        protected HomepageObject Homepage => Context.Homepage;
    }
}