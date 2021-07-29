using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace IncompleteMarkupFedToXDocumentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var xml = @"<root><section><p>Paragraph 1.</p><p>Paragraph 2";

            XDocument doc = new XDocument();

            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    using (XmlReader xr = XmlReader.Create(sr))
                    {
                        using (XmlWriter xw = doc.CreateWriter())
                        {
                            xw.WriteNode(xr, false);
                        }
                    }
                }
                Console.WriteLine("Assembled XML without parsing error: {0}", doc);
            }
            catch (XmlException e)
            {
                Console.WriteLine("XML parsing error: {0}", e.Message);
                Console.WriteLine("Assembled XML before parsing error: {0}", doc);
            }
        }
    }
}
