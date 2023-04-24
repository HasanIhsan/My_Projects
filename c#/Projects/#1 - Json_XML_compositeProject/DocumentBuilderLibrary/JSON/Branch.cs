using DocumentBuilderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentBuilderLibrary.JSON
{
    public class Branch : IComposite
    {
        //variables
        private List<IComposite> _rootChildren;
        private string _branchName;
        private bool _isRoot;
        private bool _hasSibling;

        public Branch(Branch composite)
        {
            //check branch for name, root child if it is root and set has siblings to true
            _branchName = composite._branchName;
            _rootChildren = composite._rootChildren;
            _isRoot = composite._isRoot;
            _hasSibling = true ;
        }

        public Branch(string name, bool isRoot = false)
        {
            _branchName = name;
            _rootChildren = new List<IComposite>();
            _isRoot = isRoot;
            _hasSibling = false;
        }

        public void AddChild(IComposite child)
        {
            //aadd a child to brack weather it is a leaf or branch
            if (_rootChildren.Any())
            {
                if(_rootChildren.Last() is Branch)
                {
                    _rootChildren[_rootChildren.Count - 1] = new Branch(_rootChildren[_rootChildren.Count - 1] as Branch);
                }
                else
                {
                    _rootChildren[_rootChildren.Count - 1] = new Leaf(_rootChildren[_rootChildren.Count - 1] as Leaf);
                }
            }

             _rootChildren.Add(child);
        }

        public string Print(int depth)
        {
            //print the items in the stack 
            //formatted to look like a json document
            string newString = "";

            if(_isRoot)
            {
                newString += new string(' ', depth * 4);
                newString += "{\n";

                foreach (var child in _rootChildren)
                {
                    newString += child.Print(depth + 1);
                }

                newString += new string (' ', depth * 4);
                newString += "}";
                return newString;
            }

            newString += new string(' ', depth * 4);
            newString += $"'{_branchName}' :\n";
            newString += new string(' ', depth * 4);
            newString += "{\n";

            foreach(var child in _rootChildren)
            {
                newString += child.Print(depth + 1);
            }
            newString += new string(' ', depth * 4);
            newString += "}";

            newString += _hasSibling ? ",\n" : "\n";
            return newString;
        }
    }
}
