using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GamerLib
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public string playerName { get; set; }
        [DataMember] 
        public int playerPoints { get; set; }

        public Player(string playerName, int playerPoints)
        {
            this.playerName = playerName;
            this.playerPoints = playerPoints;
        }

        public void setPlayerPoints(int points)
        {
            if(points != 0)
            {
                this.playerPoints += points;
            }else
            {
                this.playerPoints = 0;
            }
           
        }
        

    }
}
