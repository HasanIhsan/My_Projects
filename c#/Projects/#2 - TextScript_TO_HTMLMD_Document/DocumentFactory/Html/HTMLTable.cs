using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.ElementProperties
{
    


    public class HTMLTable : IElement
    {
        private TableProperties _properties;

        public HTMLTable(TableProperties properties)
        {
            this._properties = properties;
        }

        public override string ToString()
        {
            string headdone = "";
            string rowdone = "";
            string[] rowvalue = { };
            string[] newrowvalue = { };
            string str = "";
            string newstr = "";
            List<string> joinstr = new List<string>();

            //looks for property that is labled as head
            if (_properties.tableHead.Equals("Head"))
            {
                string headstart = "<thead><tr>";
                string headend = "</tr></thead>";
                var result = _properties.tableHeadings.Aggregate((total, part) => "<th>" + total + "</th>" + "<th>" + part.ToLower() + "</th>");
                 
                 headdone = "<table>" + headstart + result + headend;
                
            }
            
            for (int i = 0; i < _properties.tableRows.Count; i++)
            {
                 
                if (_properties.tableRows[i].Contains("Row"))
                {
                    
                    rowvalue = _properties.tableRows[i].Split('$');

                    //build a new string (prob an eaiser way of doing this rather then building a string this sort of works)
                    StringBuilder bdr = new StringBuilder();
                    foreach (string value in rowvalue)
                    {
                        
                       if(value.Equals("Row"))
                       {
                          
                            bdr.Append("<tr>");
                       }
                        bdr.Append("<td>");
                        bdr.Append(value);
                        bdr.Append("</td>");
                      

                    }
                     str = bdr.ToString();
                     joinstr.Add(str);  
               
                    //replace "Row" with ""
                    //overcomplicated but works
                    newrowvalue = joinstr.Select(x => x.Replace("Row", "")).ToArray();
                  
                    newstr = string.Join("", newrowvalue);
                 
                    rowdone =   newstr   + "</table>";
                } 

            }

            //Console.Write(strs);

            return headdone + rowdone;
        }
    }
}
