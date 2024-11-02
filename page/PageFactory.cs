using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;


namespace PlaywrightTests.page
{
    public class PageFactory
    {
        private readonly IPage page;
        public PageFactory(IPage _page){
            page = _page;
        }
        public LoginPageObject loginPage => new LoginPageObject(page);
        public SignupPageObject signupPage => new SignupPageObject(page);
        public AccountCreatedPageObject accountCreatedPage => new AccountCreatedPageObject(page);
        public HomepageObject homepage => new HomepageObject(page);
    }
}