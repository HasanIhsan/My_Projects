using DocumentFactory.ElementProperties;
using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Markdown
{
    public class MarkdownList : IElement
    {
        private ListProperties _properties;

        public MarkdownList(ListProperties properties)
        {
            this._properties = properties;
        }

        public override string ToString()
        {
            List<string> newlist = new List<string>();
            int valuenum = 0;
            
            //checks if user wants a ordered or undordered list
            if (_properties.listType.Equals("Ordered"))
            { 
                //increments the list number and adds the values to a newlist valriable
                for(int i = 0; i < _properties.ListItems.Count; i++)
                {
                    valuenum++; 
                    newlist.Add(valuenum + ". "+ _properties.ListItems[i]);
                } 

                //combines the values of newlist making it returnable as string
                var result = newlist.Aggregate((total, part) =>  total + "\n" + "" + part.ToLower() + "");
                 
                return  result;
            }
            else if (_properties.listType.Equals("Unordered"))
            {
                //add values to newlist but adds a * for unorderedlist
                for (int i = 0; i < _properties.ListItems.Count; i++)
                {  
                    newlist.Add( "* " + _properties.ListItems[i]);
                }  
                var result = newlist.Aggregate((total, part) => total + "\n" + "" + part.ToLower() + "");
                 
                return result;
            }
            return "";
        }
    }
}
