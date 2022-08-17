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

    interface ITransport : IMoveable
    {
        void Start();
        void Stop();
    }

    interface IFly : IMoveable, ITransport
    {
        void Fly();
        void Katapult();
    }

    interface IGo : IMoveable, ITransport
    {
        void Go();
        void Remen();
    }

    interface ISwim : IMoveable, ITransport
    {
        void Swim();
        void Shvartovat();
    }

    interface IHeartEntety : IMoveable
    {
        void GetUp();
        void GetDown();
        void Go();
        void Eat();
    }
}
