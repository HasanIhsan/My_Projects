/*
 * FIleName: IRack.cs
 * Purpose: this is a interface that hold the IRACK method and propterties
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
    public interface IRack
    {
        //total point 
       public uint totalPoints { get; }

        //test word
        public uint testWord(string word);
        //play word
        public bool playWord(string word);
        
        //add tiles
        public  uint addTiles();
        //to string 
        public string ToString();

    }
}
