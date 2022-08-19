using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public interface IWeapon
    {
        public int Damage { get; }
        void Hit(IHumanable human);
    }

    public interface IBumm : IWeapon
    {
        public int DopDamage { get; set; }
    }

    public interface IKidak : IWeapon
    {
        void Kinut(IHumanable human);
    }

    public interface IStrel : IWeapon
    {
        void Strel(IHumanable human);
    }
}
