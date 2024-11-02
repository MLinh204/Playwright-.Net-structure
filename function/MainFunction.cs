using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.function
{
    public class MainFunction
    {
        private readonly IPage _page;
        public MainFunction(IPage page){
            _page = page;
        }

        public async Task forceClick(ILocator element){
            await _page.EvaluateAsync(@"(element) =>{
                element.click();

            }", await element.ElementHandleAsync());
        }
        
        public async Task scrollIntoView(ILocator element){
            await _page.EvaluateAsync(@"(element) =>{
                element.scrollIntoView({behavior: 'smooth', block: 'center'})
            }", await element.ElementHandleAsync());
        }

        public async Task hoverOnElement(ILocator element){
            await element.HoverAsync();
        }

        public async Task waitForCondition(string script, int timeout = 10000){
            await _page.WaitForFunctionAsync(script, new PageWaitForFunctionOptions{
                Timeout = timeout
            });
        }
        public async Task GoTo(string url) => await _page.GotoAsync(url);
    }
}