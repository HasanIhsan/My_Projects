using DocumentBuilderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentBuilderLibrary.XML
{
    public class leaf : IComposite
    {
        private string _leafName;
        private string _leafContent;
        private bool _hasSibling;

        public leaf(leaf leaf)
        {
            _leafName = leaf._leafName;
            _leafContent = leaf._leafContent;
            _hasSibling = true;
        }


        public leaf(string name, string content)
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
            newString += new string(' ', depth * 3);
            newString += $"<{_leafName}>{_leafContent}</{_leafName}>";

            newString += _hasSibling ? "\n" : "\n";
            return newString;
        }
    }
}
