using DocumentFactory.ElementProperties;
using DocumentFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Markdown
{
    public class MarkdownTable : IElement
    {
        private TableProperties _properties;

        public MarkdownTable(TableProperties properties)
        {
            this._properties = properties;
        }

        //tostring for table same as html i'm propably over complicating things but this sort of works so here we are
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
                //fortable slots depending on the number of headings
                List<string> NumTableRow = new List<string>();
                string joinnumtableRow = "";

                 
                var result = _properties.tableHeadings.Aggregate((total, part) =>   total + " | "  + part.ToLower() ) + " |";

                for(int i = 0; i < _properties.tableHeadings.Count; i++)
                {
                    NumTableRow.Add("| --- ");
                }
              
                joinnumtableRow = string.Join("", NumTableRow);  //and converts that list<string> to string
                 
                headdone = "| " +  result + "\n"+ joinnumtableRow;

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
                        if (value.Equals("Row"))
                        { 
                            bdr.Append("\n");  
                        }
                       
                        bdr.Append(value);
                        bdr.Append("| ");
                    }
                    str = bdr.ToString();
                    joinstr.Add(str); 

                    newstr = string.Join("", joinstr);
 

                    //replace "Row" with ""
                    //again prob overcomplicated but works 
                    newrowvalue = joinstr.Select(x => x.Replace("Row", "")).ToArray(); 
                    newstr = string.Join("", newrowvalue);  //and converts that string[] to string

                    rowdone = newstr;
                } 

            } 

            return headdone + rowdone;
        }
    }
}
 
