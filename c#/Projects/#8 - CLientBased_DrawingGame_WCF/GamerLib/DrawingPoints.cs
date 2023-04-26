using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GamerLib
{
    [DataContract]
    public class DrawingPoints
    {
        [DataMember]
        public double X { get; set; }

        [DataMember]
        public double Y { get; set; }
    }
}
