using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DocumentFactory;
using DocumentFactory.Html;
using DocumentFactory.Interfaces;
using DocumentFactory.Markdown;

namespace Director
{
    class Program
    { 
        public static IDocumentFactory _fac = null;
        public static IDocument _doc = null;

        //method name: createDocument
        //Purpose: gets the file name and determines weather to create a html or markdown document
        static void CreateDocument(string filename)
        { 
            //filename splits at ;
            string[] fName = filename.Split(';');
            
            if (fName[0].Equals("Html")) // fName[0] = "Html" or "Markdown"
            { 
            
                _fac = HtmlDocumentFactory.GetInstance();
                _doc = HtmlDocumentFactory.GetInstance().CreateDocument(fName[1]); //fName[1] = "index.html"
                
            }
            else if (fName[0].Equals("Markdown")) // fName[0] = "Html" or "Markdown"
            {
                _fac = MarkdownDocumentFactory.GetInstance();
                _doc = MarkdownDocumentFactory.GetInstance().CreateDocument(fName[1]);//fName[1] = "index.md"
            }

        }
 
        static void Main(string[] args)
        {
           
            string[] commands;
            var list = File.ReadAllText("CreateDocumentScript.txt");
            commands = list.Split('#');

            foreach (var command in commands)
            {
                var strippedCommand = Regex.Replace(command, @"\t|\n|\r", "");
                var commandList = strippedCommand.Split(':');
                switch (commandList[0])
                {
                    case "Document": 
                        CreateDocument(commandList[1]); 
                        
                        break;
                    case "Element":
                        _doc.addElement(_fac.CreateElement(commandList[1], commandList[2])); 
                        break;
                    case "Run":
                       _doc.RunDocument();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
