using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    interface ITransport
    {
        void Start();
        void Stop();
    }
    interface IMoveable : ITransport
    {
        void Move();
        void Run();
        void Jump() { }
        void BeforeUp() { }
    }

    interface IFlyable : ITransport
    {
        void Fly();
        void Katapult();
    }

    interface ISwimable : ITransport
    {
        void Swim();
        void Shvartovat();
    }

    interface IHumanable : IMoveable
    {

    }
}
