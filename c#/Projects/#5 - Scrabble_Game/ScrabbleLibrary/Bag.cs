/*
 * FIleName: Bag.cs
 * Purpose: this is a class that implments the IBag interface (with a few extra items to get the IBAG working 
 * NOTE:
 * Programmer: Hassan Ihsan
 * DATE: ....
 */


namespace ScrabbleLibrary
{
    public class Bag : IBag
    {
        //create a list for bag of tiles
         List<TIles> _bagOfTiles { get; init; }


        /*
         * method name: BAG
         * purpose: Default constructor
         *           //initializes the bag with full tiles set
         * Programmer: HI
         * DATE...
         */
        public Bag()
        {
            //create new list 
            _bagOfTiles = new();

            //add tiles to list
            //this is tedous cause of all the looks

            /*
             * j, k, q, x, z = 1
             * b, c, f, h, m, p, v, w, y = 2
             * g = 3
             * d, l, s, u = 4
             * n, r, t = 6
             * o = 8
             * a, i = 9
             * e = 12
             */

 

            //there should be a much better way of doing this: 
            //this is tedios (i tried to implment a dicstionary but time was not a friend)
            //in the end this works even if its spagaty
            foreach (letters aLetter in Enum.GetValues(typeof(letters)))
            {
              
                //ones
                if(aLetter == letters.j )
                {
                    _bagOfTiles.Add(new TIles(letters.j)); 
                     
                }else if(aLetter == letters.k)
                {
                     _bagOfTiles.Add(new TIles(letters.k));
                }
                else if (aLetter == letters.q)
                {
                    _bagOfTiles.Add(new TIles(letters.q));
                }
                else if (aLetter == letters.x)
                {
                    _bagOfTiles.Add(new TIles(letters.x));
                }
                else if (aLetter == letters.z)
                {
                     _bagOfTiles.Add(new TIles(letters.z));
                }


                //twos
                for (int i = 0; i < 2; i++)
                {
                    if (aLetter == letters.b)
                    {
                        _bagOfTiles.Add(new TIles(letters.b));

                    }
                    else if (aLetter == letters.c)
                    {
                        _bagOfTiles.Add(new TIles(letters.c));
                    }
                    else if (aLetter == letters.f)
                    {
                        _bagOfTiles.Add(new TIles(letters.f));
                    }
                    else if (aLetter == letters.h)
                    {
                        _bagOfTiles.Add(new TIles(letters.h));
                    }
                    else if (aLetter == letters.m)
                    {
                        _bagOfTiles.Add(new TIles(letters.m));
                    }
                    else if (aLetter == letters.p)
                    {
                        _bagOfTiles.Add(new TIles(letters.p));
                    }
                    else if (aLetter == letters.v)
                    {
                        _bagOfTiles.Add(new TIles(letters.v));
                    }
                    else if (aLetter == letters.w)
                    {
                        _bagOfTiles.Add(new TIles(letters.w));
                    }
                    else if (aLetter == letters.y)
                    {
                        _bagOfTiles.Add(new TIles(letters.y));
                    }

                }

                //three                
                for (int i = 0; i < 3; i++)
                {

                    if (aLetter == letters.g)
                    {
                        _bagOfTiles.Add(new TIles(letters.g));
                    } 
                }

                //four
                for (int i = 0; i < 4; i++)
                {
                    if (aLetter == letters.d)
                    {
                        _bagOfTiles.Add(new TIles(letters.d));

                    }
                    else if (aLetter == letters.l)
                    {
                        _bagOfTiles.Add(new TIles(letters.l));
                    }
                    else if (aLetter == letters.s)
                    {
                        _bagOfTiles.Add(new TIles(letters.s));
                    }
                    else if (aLetter == letters.u)
                    {
                        _bagOfTiles.Add(new TIles(letters.u));
                    }
                }

                //six
                for (int i = 0; i < 6; i++)
                {
                    if (aLetter == letters.n)
                    {
                        _bagOfTiles.Add(new TIles(letters.n));

                    }
                    else if (aLetter == letters.r)
                    {
                        _bagOfTiles.Add(new TIles(letters.r));
                    }
                    else if (aLetter == letters.t)
                    {
                        _bagOfTiles.Add(new TIles(letters.t));
                    }
                }

                //eit
                for (int i = 0; i < 8; i++)
                {
                    if (aLetter == letters.o)
                    {
                        _bagOfTiles.Add(new TIles(letters.o));
                    }
                }

                //nine
                for (int i = 0; i < 9; i++)
                {
                    if (aLetter == letters.a)
                    {
                        _bagOfTiles.Add(new TIles(letters.a));

                    }
                    else if (aLetter == letters.i)
                    {
                        _bagOfTiles.Add(new TIles(letters.i));
                    }
                }

                //twl         
                for (int i = 0; i < 12; i++)
                {
                    if (aLetter == letters.e)
                    {
                        _bagOfTiles.Add(new TIles(letters.e));
                    }
                    
                }

            }
            
             
        }


        //tile count
        public uint tileCount => (uint)_bagOfTiles.Count;

        //author
        public string author => "Author: H. Ihsan - Jan";


        /*
         * method name: GenerateRack
         * purpose: a IRACK Method to generate a rack by calling a new rack deafult construckt and giving it the bag of tile list
         * Programmer: HI
         * DATE...
         */
        public IRack GenerateRack()
        {
            return new Rack(_bagOfTiles);
        }


        /*
         * method name: to string
         * purpose:  overriden tostring method that counts the amount of letters in the bag and prints the letter count
         *           e.g. e(12), a(9) and so on
         * Programmer: HI
         * DATE...
         */
        public override string ToString()
        {
            //for keeping track of count of num of tiles (might be a better way?)
            int aCount = 0, bCount = 0, cCount = 0, dCount = 0, eCount = 0, fCount= 0, gCount = 0, hCount = 0, iCount = 0, jCount = 0, kCount = 0, lCount = 0, mCount= 0, nCount = 0, oCount = 0, pCount = 0, qCount = 0, rCount = 0, sCount = 0, tCount = 0, uCount = 0, vCount = 0, wCount= 0, xCount = 0, yCount = 0, zCount = 0;

            //really tedious (could have done a switch?)
            for (int index = 0; index < _bagOfTiles.Count; index++)
            {
                if (_bagOfTiles[index].letter == letters.a)
                {
                    aCount++;
                }else if (_bagOfTiles[index].letter == letters.b)
                {
                    bCount++;
                }
                else if (_bagOfTiles[index].letter == letters.c)
                {
                    cCount++;
                }
                else if (_bagOfTiles[index].letter == letters.d)
                {
                    dCount++;
                }
                else if (_bagOfTiles[index].letter == letters.e)
                {
                    eCount++;
                }
                else if (_bagOfTiles[index].letter == letters.f)
                {
                    fCount++;
                }
                else if (_bagOfTiles[index].letter == letters.g)
                {
                    gCount++;
                }
                else if (_bagOfTiles[index].letter == letters.h)
                {
                    hCount++;
                }
                else if (_bagOfTiles[index].letter == letters.i)
                {
                    iCount++;
                }
                else if (_bagOfTiles[index].letter == letters.j)
                {
                    jCount++;
                }
                else if (_bagOfTiles[index].letter == letters.k)
                {
                    kCount++;
                }
                else if (_bagOfTiles[index].letter == letters.l)
                {
                    lCount++;
                }
                else if (_bagOfTiles[index].letter == letters.m)
                {
                    mCount++;
                }
                else if (_bagOfTiles[index].letter == letters.n)
                {
                    nCount++;
                }
                else if (_bagOfTiles[index].letter == letters.o)
                {
                    oCount++;
                }
                else if (_bagOfTiles[index].letter == letters.p)
                {
                    pCount++;
                }
                else if (_bagOfTiles[index].letter == letters.q)
                {
                    qCount++;
                }
                else if (_bagOfTiles[index].letter == letters.r)
                {
                    rCount++;
                }
                else if (_bagOfTiles[index].letter == letters.s)
                {
                    sCount++;
                }
                else if (_bagOfTiles[index].letter == letters.t)
                {
                    tCount++;
                }
                else if (_bagOfTiles[index].letter == letters.u)
                {
                    uCount++;
                }
                else if (_bagOfTiles[index].letter == letters.v)
                {
                    vCount++;

                }
                else if (_bagOfTiles[index].letter == letters.w)
                {
                    wCount++;
                }
                else if (_bagOfTiles[index].letter == letters.x)
                {
                    xCount++;
                }
                else if (_bagOfTiles[index].letter == letters.y)
                {
                    yCount++;
                }
                else if (_bagOfTiles[index].letter == letters.b)
                {
                    zCount++;
                }
            }

            return string.Concat($"a({aCount})  b({bCount})  c({cCount}) d({dCount}) e({eCount}) f({fCount}) g({gCount}) h({hCount}) i({iCount}) j({jCount}) k({kCount}) l({lCount}) m({mCount}) n({nCount}) \no({oCount}) p({pCount}) q({qCount}) r({rCount}) s({sCount}) t({tCount}) u({uCount}) v({vCount}) w({wCount}) x({xCount}) y({yCount}) z({zCount})");
        }
    }
}