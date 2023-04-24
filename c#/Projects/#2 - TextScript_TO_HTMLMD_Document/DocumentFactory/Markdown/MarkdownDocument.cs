using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Markdown
{
    internal class MarkdownDocument : IDocument
    {
        public List<IElement> elementlist = new List<IElement>();

        public void addElement(IElement element)
        {
            elementlist.Add(element); 
        }

        public void RunDocument()
        {
            string path = Path.GetFullPath(MarkdownDocumentFactory.fname);
            

            //file exists
            if (File.Exists(path))
            { 
                using (StreamWriter sw = File.AppendText(path))
                {
                     
                    for (int i = 0; i < elementlist.Count; i++)
                    {
                        sw.WriteLine(elementlist[i] + "\n");
                    }
                    
                }
                
            }

            //this only works if there is no spaces in file path 
            System.Diagnostics.Process.Start("chrome.exe", string.Format("\"{0}\"", path));
        }
    }
}
