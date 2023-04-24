using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.ElementProperties
{
    

    public class HTMLHeader : IElement
    {
        private HeaderProperties _properties;

       public HTMLHeader(HeaderProperties properties)
       {
           this._properties = properties;
       }

        //overwritten tostring return html code for header
        public override string ToString()
        {
            return "<h" + _properties.headerType + ">" + _properties.headerText + "</h" + _properties.headerType +">";
        }
    }
}
