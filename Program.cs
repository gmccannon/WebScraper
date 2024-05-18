using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Xml;

namespace WebScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                Console.WriteLine("Usage: dotnet run <url> <output_file_name(optional)>");
                return;
            }
            
            string url = args[0];
            string path = args.Length > 1 ? args[1] : "output.xml";

            User.DocumentUser documentUser = User.DocumentUser.Instance;

            await documentUser.Scrape(url);

            documentUser.Write(path);
        }
    }
}
