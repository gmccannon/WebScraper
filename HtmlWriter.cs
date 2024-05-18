using System;
using HtmlAgilityPack;

namespace Writer
{
    class HtmlWriter
    {
        public static void Write(HtmlDocument htmlDoc, string path)
        {
            var sw = new StringWriter();
            var fs = new FileStream(path, FileMode.Create);

            htmlDoc.OptionOutputAsXml = true; 
            htmlDoc.Save(fs);
        }
    }
}
