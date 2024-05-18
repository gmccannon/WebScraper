using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Xml;
using Scraper;

namespace WebScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                Console.WriteLine("Usage: dotnet run <url> <output_file_name>");
                return;
            }
            string url = args[0];

            string path = "output.xml";
            if (args.Length > 1)
            {
                path = args[1];
            }


            HtmlDocument htmlDoc = await Scraper.HtmlScraper.Scrape(url);
            
            Writer.HtmlWriter.Write(htmlDoc, path);
        }
    }
}
