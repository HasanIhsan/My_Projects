//Program Name: consolseDirector
//Purpose: this connects the documentbuilder libaray files 
//Programmer: Hassan Ihsan
//Date: ..../../..

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocumentBuilderLibrary.Interfaces;

namespace Project2
{
    public class ConsoleDirector : IDirector
    {
        private IBuilder _builder;

        public string Name { get; set; }
        public string Content { get; set; }

        public ConsoleDirector(IBuilder builder)
        {
            _builder = builder;
        }

        //get the document
        public IComposite GetDocument()
        {
            return _builder.GetDocument();
        }

        //build a new branch
        public void BuildBranch()
        {
            _builder.BuildBranch(Name);
        }

        //build a new leaf
        public void BuildLeaf()
        {
            _builder.BuildLeaf(Name, Content);
        }

        //close the branch
        public void CloseBranch()
        {
            _builder.CloseBranch();
        }

    }
}
