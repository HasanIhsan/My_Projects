using DocumentBuilderLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentBuilderLibrary.XML
{
    public class Builder : IBuilder
    {
        //the branch root aand the stack where the roots and childnodes are held
        private Branch _root;
        private Stack<Branch> _nodeStack;

        public Builder()
        {
            //create a new brach and push it to stack
            _root = new Branch("", true);
            _nodeStack = new Stack<Branch>();
            _nodeStack.Push(_root);
        }

        public void BuildBranch(string name)
        {
            //look at the top object in stack and push a child to that node (child branch)
            var newNode = new Branch(name);
            _nodeStack.Peek().AddChild(newNode);
            _nodeStack.Push(newNode);
        }

        public void BuildLeaf(string name, string content)
        {
            //add a child node to top of stack
            var newNode = new leaf(name, content);
            _nodeStack.Peek().AddChild(newNode);

        }

        public void CloseBranch()
        {
            //if the top of stack is not root then use pop() to remove and return the object at the top of the stack
            if (_nodeStack.Peek() != _root)
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
