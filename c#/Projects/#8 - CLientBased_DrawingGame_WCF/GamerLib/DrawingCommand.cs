using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GamerLib
{
    [DataContract]
    public class DrawingCommand
    {
        [DataMember]
        public DrawingActionType ActionType { get; set; }

        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public double Thickness { get; set; }

        [DataMember]
        public DrawingPoints StartPoint { get; set; }

        [DataMember]
        public DrawingPoints EndPoint { get; set; }

        [DataMember]
        public DrawingPoints[] Points { get; set; }
    }


    public enum DrawingActionType
    {
        [EnumMember]
        DrawLine,

        [EnumMember]
        DrawCircle,

        [EnumMember]
        ClearCanvas,
        // add more drawing actions as needed
    }
}
