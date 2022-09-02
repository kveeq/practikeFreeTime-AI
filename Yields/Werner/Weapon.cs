using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public abstract class Weapon<T> : IWeapon where T : Weapon<T>
    {
        public int Damage { get; }
        public Weapon(int damage)
        {
            Damage = damage;
        }

        public void Hit(IHumanable human, IHumanable humanSet)
        {
            human.Hit(humanSet);
        }
    }

    public class Kinjal : Weapon<Kinjal>, IKidak
    {
        public Kinjal(int damage) : base(damage)
        {
        }

        public void Kinut(IHumanable humanGet, IHumanable humanSet)
        {
            humanGet.Hit(humanSet);
        }
    }

    public class Scar : Weapon<Scar>, IStrel
    {
        public Scar(int damage) : base(damage)
        {
        }

        public void Strel(IHumanable humanGet, IHumanable humanSet)
        {
            humanGet.Hit(humanSet);
        }
    }

    public class Dubin : Weapon<Dubin>, IBumm
    {
        public int DopDamage { get; set; }
        public Dubin(int damage) : base(damage)
        {
            DopDamage = damage;
        }
    }
}
