using Microsoft.Playwright;
using PlaywrightTests.function;

namespace PlaywrightTests.page
{
    public class LoginPageObject
    {
        private readonly IPage page;
        private readonly MainFunction function;
        public LoginPageObject(IPage _page){
            page = _page;
            function = new MainFunction(_page);
        }
        public ILocator LoginForm => page.Locator("//div[@class='login-form']");
        public ILocator findLoginInputByName(string name){
            return page.Locator($"//div[@class='login-form']//input[@name='{name}']");
        }
        public ILocator loginBtn => page.Locator("//div[@class='login-form']//button");
        public ILocator SignupForm => page.Locator("//div[@class='signup-form']");
        public ILocator emailExistedMessage => page.Locator("//div[@class='signup-form']//p");
        public ILocator errorMessage => page.Locator("//form[@action]//p[1]");
        public ILocator findSignUpInputByName(string name){
            return page.Locator($"//div[@class='signup-form']//input[@name='{name}']");
        }
        public ILocator signupBtn => page.Locator("//div[@class='signup-form']//button");

        public async Task<bool> isLoginPageVisible(){
            try{
                var isLoginFormDisplayed = await LoginForm.IsVisibleAsync();
                var isSignupFormDisplayed = await SignupForm.IsVisibleAsync();
                return isLoginFormDisplayed && isSignupFormDisplayed;
            } catch (Exception e){
                return false;
            }
        }
    }
}