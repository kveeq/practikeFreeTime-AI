using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public interface ITransport
    {
        void Start();
        void Stop();
        void SetToplivo(IToplivo toplivo);
    }
    public interface IMoveable : ITransport
    {
        event Action<string> ToplivoChanged;
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

    public interface IHumanable : IMoveable
    {
        int Hp { get; set; }
        void Eat(Food food);
        void Living();
        event Action<string> HpChange;
    }
}
