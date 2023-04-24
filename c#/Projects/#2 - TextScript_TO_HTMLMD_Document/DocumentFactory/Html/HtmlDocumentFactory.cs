using DocumentFactory.ElementProperties;
using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Html
{
    public class HtmlDocumentFactory : IDocumentFactory
    {

        protected static HtmlDocumentFactory instace;
        public static string fname = "";
        //making singleton
        protected HtmlDocumentFactory() {}
        public static HtmlDocumentFactory GetInstance()
        {
            if (instace == null)
            {
                instace = new HtmlDocumentFactory();
            }
            return instace;

        }
        public IDocument CreateDocument(string fileName)
        {
            //Console.WriteLine(fileName);
         
            string[] filename = fileName.Split(';');

            // path to file this is current directory aka where ur script is located for me it was the doc folder 
            string path = filename[0];

            fname = filename[0];
           // Console.WriteLine(fname);
            

            
           // Create the file using filestream, or overwrite if the file exists.
           //i could use File.Create() but i was getting errors this worked
           using (FileStream fs = File.Create(path))
           { 
                byte[] info = new UTF8Encoding(true).GetBytes("");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
           } 

            return new HtmlDocument();
        }

        public IElement CreateElement(string elementType, string props)
        {
          
            //splits props at ";"
            string[] p = props.Split(';');

            //looks for user given element value (image, header, list, table)
            if (elementType == "Image")
            { 
                ImageProperties _imageproperties = new ImageProperties();
                _imageproperties.imgAlt = p[1];
                _imageproperties.imgSrc = p[0];
                _imageproperties.imgTitle = p[2];
                return new HTMLImage(_imageproperties);

            }
            else if(elementType == "Header")
            {
                HeaderProperties _headerProperties = new HeaderProperties();
                int headerint = Int32.Parse(p[0]);

                _headerProperties.headerType =headerint;
                _headerProperties.headerText = p[1];
                return new HTMLHeader(_headerProperties);
            }
            else if(elementType == "Table")
            {
                TableProperties _tableProperties = new TableProperties();

                //splits head at "$"
                string[] head = p[0].Split('$');
                _tableProperties.tableHead = head[0]; //head[0] = "Head"

               
                for (int i = 1; i < head.Length; i++)
                {
                    _tableProperties.tableHeadings.Add(head[i]);
                    
                }
                
                //splits row at "$"
                string[] row = p[1].Split('$'); 
                _tableProperties.tableRow = row[0]; // Row[0] = "Row"
                

                for (int i = 1; i < p.Length; i++)
                {   
                    _tableProperties.tableRows.Add(p[i]);
                } 
                return new HTMLTable(_tableProperties);
                 
            }
            else if(elementType == "List")
            {
                ListProperties _listProperties = new ListProperties();
                _listProperties.listType = p[0];
                for(int i = 1; i < p.Length; i++)
                {
                    _listProperties.ListItems.Add(p[i]);   
                }
                 
                
                return new HTMLList(_listProperties);
            }

            return new HTMLElement();
        }
    }
}
