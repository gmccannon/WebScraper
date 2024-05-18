using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Xml;

namespace Scraper
{
    class HtmlScraper
    {
        public static async Task<HtmlDocument> Scrape(string url)
        {
            var client = new HttpClient();
            var htmlDoc = new HtmlDocument();

            try
            {
                var response = await client.GetStringAsync(url);
                htmlDoc.LoadHtml(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The was an error with the request: {ex.Message}");
            }

            return htmlDoc;
        }
    }
}
