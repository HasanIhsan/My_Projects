using DocumentBuilderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentBuilderLibrary.JSON
{
    public class Leaf : IComposite
    {
        private string _leafName;
        private string _leafContent;
        private bool _hasSibling;

        public Leaf(Leaf leaf)
        {
            _leafName = leaf._leafName;
            _leafContent = leaf._leafContent;
            _hasSibling = true;
        }


        public Leaf(string name, string content)
        {
            _leafName = name;
            _leafContent = content;
            _hasSibling = false;
        }

        public void AddChild(IComposite child)
        {
        }

        public string Print(int depth)
        {
            string newString = "";
            newString += new string(' ', depth * 4);
            newString += $"'{_leafName}' : '{_leafContent}'";

            newString += _hasSibling ? ",\n" : "\n";
            return newString;
        }
    }
}
