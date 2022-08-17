using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public class Transport : IMoveable
    {
        public int GetTime(int distance, int speed)
        {
            return distance / speed;
        }
    }
}
