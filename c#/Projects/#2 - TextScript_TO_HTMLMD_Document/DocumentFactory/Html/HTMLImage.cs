using DocumentFactory.Html;
using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.ElementProperties
{
    public class HTMLImage  : IElement
    {
        private ImageProperties _properties;

        public HTMLImage(ImageProperties properties)
        {
            this._properties = properties;
        }
      

        //overwritten tostring return code for html image
        public override string ToString()
        { 
            return "<img  alt='" + _properties.imgAlt +"'  title='" + _properties.imgTitle+"' src='"+ _properties.imgSrc+ "'/><br/>";
        }
    }
}
