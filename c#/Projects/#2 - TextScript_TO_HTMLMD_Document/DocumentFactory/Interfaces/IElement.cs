using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory.Interfaces
{
    public interface IElement
    {
        string ToString();
    }

    public class BaseElement : IElement
    {
        //tostring will be overwriten when adding element values
        public override string ToString()
        {
            return "";
        }
    }
}
