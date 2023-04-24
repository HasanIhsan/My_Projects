using DocumentBuilderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentBuilderLibrary.JSON
{
    public class Builder : IBuilder
    {
        private Branch _root;
        private Stack<Branch> _nodeStack;

        public Builder()
        {
            _root = new Branch("", true);
            _nodeStack = new Stack<Branch>();
            _nodeStack.Push(_root);
        }

        public void BuildBranch(string name)
        {
            var newNode = new Branch(name);
            _nodeStack.Peek().AddChild(newNode);
            _nodeStack.Push(newNode);
        }

        public void BuildLeaf(string name, string content)
        {
            var newNode = new Leaf(name, content);
            _nodeStack.Peek().AddChild(newNode);
            
        }

        public void CloseBranch()
        {
            if(_nodeStack.Peek() != _root)
            {
                _nodeStack.Pop();
            }
        }

        public IComposite GetDocument()
        {
            return _root;
        }
    }
}
