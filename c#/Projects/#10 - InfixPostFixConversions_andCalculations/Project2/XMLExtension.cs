using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Project2
{
    public static class XMLExtension
    {
        public static void WriteStartDocument(this StreamWriter writer)
        {
            writer.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            writer.Flush();
        }

        public static void WriteStartRootElement(this StreamWriter writer)
        {
            writer.Write($"<root>");
        }

        public static void WriteEndRootElement(this StreamWriter writer)
        {
            writer.Write($"</root>");
        }

        public static void WriteStartElement(this StreamWriter writer)
        {
            writer.Write($"<element>");
        }

        public static void WriteEndElement(this StreamWriter writer)
        {
            writer.Write($"</element>");
          
        }

        public static void WriteAttribute(this StreamWriter writer, string name, string value)
        {
            writer.Write($" <{name}>{value}</{name}>");
           
        }
    }
}
