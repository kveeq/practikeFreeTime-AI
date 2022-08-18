using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public abstract class Food
    {
        protected Food(int hpPlus)
        {
            HpPlus = hpPlus;
        }

        protected Food(string name, string description, int hpPlus) : this(hpPlus)
        {
            Name = name;
            Description = description;
        }

        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract int HpPlus { get; set; }

        public void Eat(IHumanable transport)
        {
            transport.Hp += HpPlus;
            Console.WriteLine($"{transport.GetType().Name} eat {this.GetType().Name}");
        }
    }
    public abstract class Toplivo : IToplivo
    {
        protected Toplivo(int hpPlus)
        {
            HpPlus = hpPlus;
        }

        public abstract int HpPlus { get; set; }
        public abstract ToplivoTypes Type { get; set; }

        // Bak transport
        public void TopEat(Transport movist)
        {
            movist.Toplivo += HpPlus;
        }
    }

    public class Benz92 : Toplivo
    {
        public Benz92(int hpPlus) : base(hpPlus)
        {
        }

        public override int HpPlus { get; set; }
        public override ToplivoTypes Type { get; set; }
    }

    public class Dizel : Toplivo
    {
        public Dizel (int hpPlus) : base(hpPlus)
        { }

        public override int HpPlus { get; set; }
        public override ToplivoTypes Type { get; set; }
    }

    public class Orange : Food, IFruct
    {
        public Orange(int hpPlus) : base(hpPlus)
        {
        }

        public Orange(string name, string description, int hpPlus) : base(name, description, hpPlus)
        {
        }

        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int HpPlus { get; set; }
    }


    public class Meat : Food, IMeatable
    {
        public Meat(int hpPlus) : base(hpPlus)
        {
        }

        public Meat(string name, string description, int hpPlus) : base(name, description, hpPlus)
        {
        }

        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int HpPlus { get; set; }
    }
}
