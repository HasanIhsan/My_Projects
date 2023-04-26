
/*
 * FIleName: Rack.cs
 * Purpose: this is a internal class  that implments the method from the IRack interface
 * NOTE:
 * Programmer: Hassan Ihsan
 * DATE: ....
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Word;

namespace ScrabbleLibrary
{
    internal class Rack : IRack
    {

        //doing 2 lists 
        //one for bag
        //and one for rack
        public List<TIles> _BagOfTiles = new();
        public List<TIles> _rackOfTiles = new();

        // public uint totalPoints => 0;
        uint TotalPoint = 0;

        
        Application wordChecker = new();
       

        /*
        * method name: Rack
        * purpose: Default constructor
        *             //adds tiles to rack from the var giving by the bag.cs
        * Programmer: HI
        * DATE...
        */
        public Rack(List<TIles> bag)
        {
            //adds items  from the list in the bag class
            this._BagOfTiles.AddRange(bag);

            //once the bag is full this method is called to add tiles to the rack
            addTiles();
           
        }

        //total points return the var totalpoint which contains the total point count
        public uint totalPoints => TotalPoint;

    
        /*
       * method name: addTiles
       * purpose:  this method is created to take items from the bag and add them to the rack (of 7)
       * Programmer: HI
       * DATE...
       */
        public uint addTiles()
        {
            //random var (so that we take random items and add them to the rack)  
            Random r = new();
 
            //vars
            int now; 
            int maxTileCount = 7;
           
            //gets the rack count (to make sure its 7)
            uint rackCount = (uint)_rackOfTiles.Count;

             

            //if the rack count is less then 7 and the bag count is not 0
            if (rackCount < 7 && _BagOfTiles.Count > 0)
            {
                //run through the loop of max tiles that are allowed in the rack 
                for (int i = 0; i < maxTileCount; i++)
                {

                    //staying in range of the number if tiles in the bag
                    //add tiles from bag at random
                    //then remove thoese tiles from the bag
                    now = r.Next(0, _BagOfTiles.Count);
                    _rackOfTiles.Add(_BagOfTiles[now]);
                    _BagOfTiles.RemoveAt(now);


                    //recheck the rackcount?
                    rackCount = (uint)_rackOfTiles.Count;
 
                    
                    //if the rack count after check is 7 then simply break the loop
                    //NOTE: might not be the best way of implmenting this
                    if (rackCount == 7)
                    {
                        break;
                    }
                }


             
            }

            //return rack count 
            return rackCount;
        }



        /*
         * method name: PlayWord
         * purpose:  this method is created to take a word and play it (getting the points)
         *           //tests word
         *           //update total points
         *           //removes the letters from rack 
         *           //adds new letters to rack
         *           //then return true
         *          //if word in invalid return false
         * Programmer: HI
         * DATE...
         */
        public bool playWord(string word)
        {
            //turn the word to array
            char[] wordchar = word.ToCharArray();

            //turn the rack of tiles to a single string
            string rackString = string.Join("", _rackOfTiles.Select(x => x.letter.ToString()).ToArray());

            //is a word
            if ((wordChecker.CheckSpelling(word.ToLower())))
            {
                
                //give points
                TotalPoint += testWord(word);
                
                //for the amount of words in the char array
                for (int i = 0; i < wordchar.Length; i++)
                {
                    //check word is word
                    if (rackString.Contains(wordchar[i]))
                    {
                        //again prob not the best way of doing this but it works 
                        // TIles tile = new TIles(letters.a);
                        for (int j = 0; j < _rackOfTiles.Count; j++)
                        {
                            //something like this: remove
                            //if index in the rack has a letter that is a certian letter
                            ///e.g rack[j].letter is letter.a (EX: rack[2] = 'a')
                            //and the word char array also has the same letter 
                            ///e.g wordchar[i] == 'a' (EX wordchar[1] = 'a'
                            //then delete the index of that item 
                            ///rack.removeAt(j) (EX rack.removeat(2)
                            if (_rackOfTiles[j].letter == letters.a && wordchar[i] == 'a')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.b && wordchar[i] == 'b')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.c && wordchar[i] == 'c')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.d && wordchar[i] == 'd')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.e && wordchar[i] == 'e')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.f && wordchar[i] == 'f')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.g && wordchar[i] == 'g')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.h && wordchar[i] == 'h')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.i && wordchar[i] == 'i')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.j && wordchar[i] == 'j')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.k && wordchar[i] == 'k')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.l && wordchar[i] == 'l')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.m && wordchar[i] == 'm')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.n && wordchar[i] == 'n')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.o && wordchar[i] == 'o')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.p && wordchar[i] == 'p')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.q && wordchar[i] == 'q')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.r && wordchar[i] == 'r')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.s && wordchar[i] == 's')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.t && wordchar[i] == 't')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.u && wordchar[i] == 'u')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.v && wordchar[i] == 'v')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.w && wordchar[i] == 'w')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.x && wordchar[i] == 'x')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.y && wordchar[i] == 'y')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                            else if (_rackOfTiles[j].letter == letters.z && wordchar[i] == 'z')
                            {
                                _rackOfTiles.RemoveAt(j);
                            }
                        } 
                        //  _rackOfTiles.Remove(wordchar[i]);
                    }
                }

               
 
                //add new tiles
                addTiles();
                //wordChecker.Quit();
                return true;
            }
            else
            {
                return false;
            }
             
 
        }
         
        /*
        * method name: PlayWord
        * purpose:  this method is created to take a word test it 
        *            //test word using word application lib            
        *            
        * Programmer: HI
        * DATE...
        */
        public uint testWord(string word)
        {
            //point system:
            /*
             * a, e, i, l, n, o, r, s, t, u = 1
             * d, g = 2
             * b, c, m, p = 3
             * f, h, v, w, y = 4
             * k = 5
             * j, x = 8
             * q, z = 10
             */

            //cal point var
            uint calcPoints = 0;

            //convert word to array and rack to string
            char[] chars = word.ToCharArray();
            string rackString = string.Join("", _rackOfTiles.Select(x => x.letter.ToString()).ToArray());


            //is a word
            if ((wordChecker.CheckSpelling(word.ToLower())))
            {
                for(int i = 0; i < chars.Length; i++)
                {
                    //if the string contains any letter in the word array
                    if (rackString.Contains(chars[i]))
                    {
                        //add the point that letter is worth
                        if (chars[i] == 'a' || chars[i] == 'e' || chars[i] == 'i' || chars[i] == 'l' || chars[i] == 'n' || chars[i] == '0' || chars[i] == 'r' || chars[i] == 's' || chars[i] == 't' || chars[i] == 'u')
                        {
                            calcPoints += 1;
                        }else if( chars[i] == 'd' || chars[i] == 'g')
                        {
                            calcPoints += 2;
                        }else if( chars[i] == 'b' || chars[i] == 'c' || chars[i] == 'm' || chars[i] == 'p')
                        {
                            calcPoints += 3;
                        }else if(chars[i] == 'f' || chars[i] == 'h' || chars[i] == 'v' || chars[i] == 'w' || chars[i] == 'y')
                        {
                            calcPoints += 4;
                        }else if(chars[i] == 'k')
                        {
                            calcPoints += 5;
                        }else if( chars[i] == 'j' || chars[i] == 'x')
                        {
                            calcPoints += 8;
                        }else if( chars[i] == 'q' || chars[i] == 'z')
                        {
                            calcPoints += 10;
                        }
                    }
                }
               // wordChecker.Quit();
                return calcPoints;

            }
            else
            {
                return 0;
            }
        }


        /*
       * method name: tostring
       * purpose:  this method is created  to print out tiles in the rak         
       *            //first converts them to string (prob was not nessary)
       * Programmer: HI
       * DATE...
       */
        public override string ToString()
        {
            //joins all items in ract togetger
            string rack = string.Join("", _rackOfTiles.Select(x => x.letter.ToString()).ToArray());
             
            return $"[{rack}]";
        }

        
    }
}
