using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public abstract class Weapon : IWeapon
    {
        public int Damage { get; }
        public Weapon(int damage)
        {
            Damage = damage;
        }
        public void Hit(IHumanable human, IHumanable humanSet)
        {
            throw new NotImplementedException();
        }
    }

    public class Kinjal : Weapon, IKidak
    {
        public Kinjal(int damage) : base(damage)
        {
        }

        public void Kinut(IHumanable humanGet, IHumanable humanSet)
        {
            humanGet.Hit(humanSet);
        }
    }

    public class Step : Weapon, IStrel
    {
        public Step(int damage) : base(damage)
        {
        }

        public void Strel(IHumanable human, IHumanable humanSet)
        {
            throw new NotImplementedException();
        }
    }
}
