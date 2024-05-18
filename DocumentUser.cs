using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace User
{
    class DocumentUser
    {
        private static readonly Lazy<DocumentUser> lazy =
            new Lazy<DocumentUser>(() => new DocumentUser());

        public static DocumentUser Instance { get { return lazy.Value; } }

        private HtmlDocument htmlDoc;

        private DocumentUser()
        {
            htmlDoc = new HtmlDocument();
        }

        public void Write(string path)
        {
            using (var fs = new FileStream(path, FileMode.Create))
            {
                htmlDoc.OptionOutputAsXml = true; 
                htmlDoc.Save(fs);
            }
        }

        public async Task Scrape(string url)
        {
            using (var client = new HttpClient())

            try
            {
                var response = await client.GetStringAsync(url);
                htmlDoc.LoadHtml(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The was an error with the request: {ex.Message}");
            }
        }
    }
}
