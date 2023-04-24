using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.ElementProperties
{
    internal class HTMLList : IElement
    { 
        private ListProperties _properties;

        public HTMLList(ListProperties properties)
        {
            this._properties = properties;
        }

        public override string ToString()
        {
            //looks for listtype as either ordered or unodered
            if(_properties.listType.Equals("Ordered"))
            {
               //not properly add extra item (in coded adds extra <li></li> elements
                var result =   _properties.ListItems.Aggregate( (total, part) =>   total + "</li>" + "<li>" + part) + "</li>";
               
                 
                return "<ol>" + result + "</ol>";
            }
            else if (_properties.listType.Equals("Unordered"))
            {
                //not properly add extra item
                var result = _properties.ListItems.Aggregate((total, part) => "" + total + "</li>" + "<li>" + part + "</li>");


                return "<ul>" + result + "</ul>";
            }
            return "";
        }
        
    }
}
