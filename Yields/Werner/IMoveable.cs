using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    interface IMoveable
    {
        const int minSpeed = 0;
        private static int maxSpeed = 100;
        int GetTime(int distance, int speed);

        public int MaxSpeed { get => maxSpeed; set { if (value > 0) maxSpeed = value; } }
    }
}
