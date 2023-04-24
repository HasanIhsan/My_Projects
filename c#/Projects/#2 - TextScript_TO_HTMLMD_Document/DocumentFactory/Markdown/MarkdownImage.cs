using DocumentFactory.ElementProperties;
using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Markdown
{
    public class MarkdownImage : IElement
    {
        private ImageProperties _properties;

        public MarkdownImage(ImageProperties properties)
        {
            this._properties = properties;
        }


        //overwritten tostring to return code for markdown image code
        public override string ToString()
        { 
            return "![" + _properties.imgAlt + "](" + _properties.imgSrc + " \"" + _properties.imgTitle + "\")";
        }
    }
}
