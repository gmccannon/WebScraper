﻿using System;
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
            
            StringWriter sw = new StringWriter();
            FileStream fs = new FileStream("htmlOut.xml", FileMode.Create);
            XmlTextWriter xw = new XmlTextWriter(sw);

            try
            {
                var response = await client.GetStringAsync(url);

                htmlDoc.LoadHtml(response);

                htmlDoc.OptionOutputAsXml = true; 
                htmlDoc.Save(xw);
                htmlDoc.Save(fs); // also saving here for testing
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
