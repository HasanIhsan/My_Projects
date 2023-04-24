using DocumentFactory.ElementProperties;
using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Markdown
{
    public class MarkdownHeader : IElement
    {
       private HeaderProperties _properties;

        public MarkdownHeader(HeaderProperties properties)
        {
            _properties = properties;
        }

        //overwritten tostring to return code for markdown headers 
        //the header go from 1- 6 so i ended up hard coding them
        public override string ToString()
        {
            if(_properties.headerType == 2)
            {
                return "## " + _properties.headerText;
            }
            else if(_properties.headerType == 3)
            {
                 return "### " + _properties.headerText;
            
            }
            else if( _properties.headerType == 4)
            {
                return "#### " + _properties.headerText;
            }
            else if(_properties.headerType == 5)
            {
                return "##### " + _properties.headerText;
            }
            else if(_properties.headerType== 6)
            {
                return "###### " + _properties.headerText;
            }

            return "# " + _properties.headerText;
        }
    }
}
