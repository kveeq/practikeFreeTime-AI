using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    interface IFruct
    {

    }

    interface IMeatable
    {
        
    }

    public interface IToplivo
    {
        ToplivoTypes Type { get; set; }
        void TopEat(Transport movist);
    }
    
    public enum ToplivoTypes
    {
        Benz,
        Gaz,
        Dizel
    }
}
