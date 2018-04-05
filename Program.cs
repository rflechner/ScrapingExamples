using System;
using System.Threading.Tasks;
using ScrapySharp;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using static System.Console;

namespace ScrapingExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var query = "scrapysharp";
            WriteLine($"Searching '{query}' on google");

            var browser = new ScrapingBrowser();
            var resultsPage = await browser.NavigateToPageAsync(new Uri($"https://www.google.fr/search?q={query}"));
            
            WriteLine($"Results");

            foreach (var link in resultsPage.Html.CssSelect("h3.r a"))
            {
                WriteLine($"- {link.InnerText}");
            }

        }
    }
}
