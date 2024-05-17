using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Xml;

namespace WebScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = args[0];

            using HttpClient client = new HttpClient();
            HtmlDocument htmlDoc = new HtmlDocument();

            try
            {
                var response = await client.GetStringAsync(url);
                htmlDoc.LoadHtml(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The was an error with the request: {ex.Message}");
            }
            
            StringWriter sw = new StringWriter();
            FileStream fs = new FileStream("htmlOut.xml", FileMode.Create);
            XmlTextWriter xw = new XmlTextWriter(sw);

            htmlDoc.OptionOutputAsXml = true; 
            htmlDoc.Save(xw);
            htmlDoc.Save(fs); // also saving here for testing

        }
    }
}
