using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Xml;

namespace Writer
{
    class HtmlWriter
    {
        public static void Write(HtmlDocument htmlDoc, string path)
        {
            StringWriter sw = new StringWriter();
            FileStream fs = new FileStream(path, FileMode.Create);

            htmlDoc.OptionOutputAsXml = true; 
            htmlDoc.Save(fs);
        }
    }
}
