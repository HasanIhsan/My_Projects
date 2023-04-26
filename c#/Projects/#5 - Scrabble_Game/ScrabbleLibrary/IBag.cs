
/*
 * FIleName: IBag.cs
 * Purpose: interface that contains method to be implmentded into a class
 * NOTE:
 * Programmer: Hassan Ihsan
 * DATE: ....
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleLibrary
{
    public interface IBag
    {
        //author of program name
        public string author { get; }
        //tile count
        public uint tileCount { get; }
        //generaterack
        public IRack GenerateRack();
        //to string
        public string ToString();
        
    }
}
