using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightTests.config;
using PlaywrightTests.Helpers;


namespace PlaywrightTests.page
{
    public class SignupPageObject
    {
        private readonly IPage page;
        private readonly MainFunction function;
        public SignupPageObject(IPage _page)
        {
            page = _page;
            function = new MainFunction(_page);
        }
        public ILocator passwordField => page.Locator("//div[@class='required form-group']//input[@name='password']");
        public ILocator CreateAccountBtn => page.Locator("//button[@data-qa='create-account']");
        public ILocator countryField => page.Locator("//select[@name='country']");

        public ILocator selectDateOfBirthByName(string name)
        {
            return page.Locator($"//div[@class='col-xs-4']//select[@name='{name}']");
        }

        public async Task selectDayByLabel(string label)
        {
            ILocator day = selectDateOfBirthByName("days");
            await function.scrollIntoView(day);
            await day.SelectOptionAsync([new SelectOptionValue { Label = label }]);
        }
        public async Task selectMonthByLabel(string label)
        {
            ILocator month = selectDateOfBirthByName("months");
            await function.scrollIntoView(month);
            await month.SelectOptionAsync([new SelectOptionValue { Label = label }]);
        }

        public async Task selectYearByLabel(string label)
        {
            ILocator year = selectDateOfBirthByName("years");
            await function.scrollIntoView(year);
            await year.SelectOptionAsync([new SelectOptionValue { Label = label }]);
        }

        public ILocator selectTitleByValue(string value)
        {
            return page.Locator($"//div[@class='radio-inline']//input[@value='{value}']");
        }

        public ILocator selectRequiredTextFieldByName(string name)
        {
            return page.Locator($"//p[@class='required form-group']//input[@name='{name}']");
        }
        public ILocator selectOptionalTextFieldByName(string name)
        {
            return page.Locator($"//p[@class='form-group']//input[@name='{name}']");
        }
        public async Task fillInRequiredTextField(string name, string label)
        {
            ILocator textField = selectRequiredTextFieldByName(name);
            await function.scrollIntoView(textField);
            await textField.FillAsync(label);
        }
        public async Task fillInOptionalTextField(string name, string label)
        {
            ILocator textField = selectOptionalTextFieldByName(name);
            await function.scrollIntoView(textField);
            await textField.FillAsync(label);
        }
        public async Task selectCountryByLabel(string label)
        {
            await function.scrollIntoView(countryField);
            await countryField.SelectOptionAsync([new SelectOptionValue { Label = label }]);
        }
        public async Task clickCreateAccountBtn()
        {
            await CreateAccountBtn.ClickAsync();
        }

        public async Task fillInPassword(string password)
        {
            await function.scrollIntoView(passwordField);
            await passwordField.FillAsync(password);
        }
    }
}