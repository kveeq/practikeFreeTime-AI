using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public interface ITransport : IMoveable
    {
        event Action<string> ToplivoChanged;
        int Bak { get;set; }
        void Start();
        void Stop();
        void SetToplivo(IToplivo toplivo);
    }
    public interface IMoveable
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

    public interface IHumanable: IMoveable
    {
        public event Action<string> HumanDead;
        event Action<string> HpChange;
        event Action<string> WeaponChange;
        public bool isDead { get; }
        public dynamic? Weapon { get; }
        int Hp { get; set; }
        void Eat(Food food);
        void Living();
        void Hit(IHumanable human2);
        void PullWeapon<T>(T weapon) where T : Weapon<T>;
        void ThrowWeapon();
    }
}
