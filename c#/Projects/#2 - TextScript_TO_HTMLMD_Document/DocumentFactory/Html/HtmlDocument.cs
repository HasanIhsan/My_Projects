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
    public class HtmlDocument : IDocument
    {
        public List<IElement> elementlist = new List<IElement>();
        public void addElement(IElement element)
        {
             
            elementlist.Add(element);
         
        }

        public void RunDocument()
        {
            
            string path = Path.GetFullPath(HtmlDocumentFactory.fname); //gets path to created file (currently located in the doc folder)
           
            
            //file exists
            if (File.Exists(path))
            {

                //string text = File.ReadAllText(path);
                using (StreamWriter sw = File.AppendText(path))
                {
                    // writing data in string
                    string dataasstring = "<!DOCTYPE html><html><head></head><body> ";

                    string endhtml = "</body></html>";
                    sw.WriteLine(dataasstring);

                    for (int i = 0; i < elementlist.Count; i++)
                    {
                        sw.WriteLine(elementlist[i]);
                    }
                    sw.WriteLine(endhtml);
                }
                 
            }

            //this only works if there is no spaces in file path 
            System.Diagnostics.Process.Start("chrome.exe", string.Format("\"{0}\"", path));
        }
    }
}
