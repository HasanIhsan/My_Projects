/*
 * FIleName: Tiles.cs
 * Purpose: this is a internal class  that stores a letters enum 
 * NOTE:
 * Programmer: Hassan Ihsan
 * DATE: ....
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrabbleLibrary
{
    public enum letters { a , b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z }
     
    internal class TIles
    {
        //letter property so it can be called in other classes
        public letters letter { get; init; }

        /*
      * method name: Tiles
      * purpose: Default constructor
      *             //things
      * Programmer: HI
      * DATE...
      */
        internal TIles(letters l)
        {
            letter = l;
            
        }


    }
}
