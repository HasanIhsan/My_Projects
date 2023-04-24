using DocumentFactory.ElementProperties;
using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Markdown
{
    public class MarkdownDocumentFactory : IDocumentFactory
    {
        protected static MarkdownDocumentFactory instace;
        public static string fname = "";
        protected MarkdownDocumentFactory() { }
        public static MarkdownDocumentFactory GetInstance()
        {
            if (instace == null)
            {
                instace = new MarkdownDocumentFactory();
            }
            return instace;

        }

        public IDocument CreateDocument(string fileName)
        {
            string[] filename = fileName.Split(';');

            // path to file this is current directory aka where ur script is located for me it was the doc folder 
            string path = filename[0];

            fname = filename[0]; 

            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
             

            return new MarkdownDocument();
        }

        public IElement CreateElement(string elementType, string props)
        {
           //splits the props string at ";"
            string[] p = props.Split(';');

            //looks for the entered elementtype (image, header table, list)
            if (elementType == "Image")
            {
                ImageProperties _imageproperties = new ImageProperties();
                _imageproperties.imgAlt = p[1];
                _imageproperties.imgSrc = p[0];
                _imageproperties.imgTitle = p[2];
                return new MarkdownImage(_imageproperties);

            }
            else if (elementType == "Header")
            {
                HeaderProperties _headerProperties = new HeaderProperties();
                int headerint = Int32.Parse(p[0]);

                _headerProperties.headerType = headerint;
                _headerProperties.headerText = p[1];
                return new MarkdownHeader(_headerProperties);
            }
            else if (elementType == "List")
            {
                ListProperties _listProperties = new ListProperties();
                _listProperties.listType = p[0];
                for (int i = 1; i < p.Length; i++)
                {
                    _listProperties.ListItems.Add(p[i]);
                }
                return new MarkdownList(_listProperties);

            }
            else if (elementType == "Table")
            {
                TableProperties _tableProperties = new TableProperties();

                string[] head = p[0].Split('$');
                _tableProperties.tableHead = head[0]; //head[0] = Head
              
                for (int i = 1; i < head.Length; i++)
                {
                    _tableProperties.tableHeadings.Add(head[i]);

                } 
                
                //splits the row at "$" value
                string[] row = p[1].Split('$'); 
                _tableProperties.tableRow = row[0]; //row[0] = Row
               

                for (int i = 1; i < p.Length; i++)
                {
                    _tableProperties.tableRows.Add(p[i]);
                }

                return new MarkdownTable(_tableProperties);

            }

            return new MarkdownElement();
        }
    }
}
