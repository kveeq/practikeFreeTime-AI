using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public abstract class Transport : ITransport, IMoveable
    {
        public int Bak { get; set; } = 100;
        public event Action<string>? ToplivoChanged;
        const int minSpeed = 0;
        private static int maxSpeed = 100;
        private int toplivo = 100; 
        public int Toplivo { get => toplivo; set { toplivo = value; ToplivoChanged?.Invoke($"Топливо изменилось: {toplivo} л."); } }

        public int MaxSpeed { get => maxSpeed; set { if (value > 0) maxSpeed = value; } }

        public void Move()
        {
            if (toplivo < 20)
            {
                Console.WriteLine($"{this.GetType().Name} топлива не хватает");
                return;
            }
            Console.WriteLine($"{this.GetType().Name} moving");
            Toplivo -= 20;
        }

        public void Run()
        {
            Console.WriteLine($"{this.GetType().Name} Running");
        }

        public void Start()
        {
            Console.WriteLine($"{this.GetType().Name} Start");
        }

        public void Stop()
        {
            Console.WriteLine($"{this.GetType().Name} Stop");
        }

        public void SetToplivo(IToplivo toplivo)
        {
                toplivo.TopEat(this);
        }
    }

    public class Car : Transport, IMoveable
    {

    }

    public class Moto : Transport, IMoveable
    {
        public void BeforeUp()
        {
            Console.WriteLine($"{this.GetType().Name} Upping");
        }
    }

    public class Human : IHumanable
    {
        private int hp = 100;
        public bool isDead { get; set; } = false;
        private dynamic? weapon = null;
        public dynamic? Weapon { get => weapon; }
        public string Name { get; set; }
        public Human(string name)
        {
            Name = name;
        }

        public int Hp { 
            get => hp; 
            set  
            {
                hp = value;
                HpChange?.Invoke($"Здоровье {Name} изменилось - {Hp}"); 
                if (value <= 0)
                {
                    HumanDead?.Invoke($"human {Name} dead");
                    isDead = true;
                }
            }
        }


        public int damage = 10;

        public static event Action<string>? HpChange;
        public static event Action<string>? HumanDead;
        public static event Action<string>? WeaponChange;

        public void Eat(Food food)
        {
            if (CheckDead(this))
                return;
            food.Eat(this);
            Console.WriteLine($"{this.GetType().Name} {Name} Eating");
        }

        public void Jump()
        {
            if (CheckDead(this))
                return;
            Console.WriteLine($"{this.GetType().Name} {Name} Jumping");
        }

        public void Living()
        {
            if (CheckDead(this))
                return;
            Console.WriteLine($"{this.GetType().Name} {Name} Living");
        }

        public void Hit(IHumanable human2)
        {
            if (CheckDead(human2) || CheckDead(this))
                return;
            Console.Write("Hit ");
            human2.Hp -= damage;
        }

        private bool CheckDead(IHumanable human)
        {
            if (human.isDead)
            {
                Console.WriteLine($"human {human.Name} dead");
            }
            
            return human.isDead;
        }
        
        // public void Hit(IHumanable human2, Weapon weapon)
        //{
        //    //if (isDead)
        //    //{
        //    //    Console.WriteLine("human dead");
        //    //    return;
        //    //}
        //    //weapon.Hit(this, human2);
        //    //human2.Hp -= weapon.Damage;
        //}

        public void Move()
        {
            Console.WriteLine($"{this.GetType().Name} Moving");
        }

        public void Run()
        {
            Console.WriteLine($"{this.GetType().Name} Running");
        }

        public void PullWeapon<T>(T pullWeapon) where T : Weapon<T>
        {
            if (weapon != null)
                return;
            damage += pullWeapon.Damage;
            weapon = pullWeapon;
            WeaponChange?.Invoke($"{Name} взял {weapon.GetType().Name}");
        }

        public void ThrowWeapon()
        {
            if (weapon == null)
                return;

            WeaponChange?.Invoke($"{Name} выбросил {weapon.GetType().Name}");
            damage -= weapon.Damage;
            weapon = null;
        }
    }

    public class Flyer : Transport, IFlyable
    {
        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name} Fly");
        }

        public void Katapult()
        {
            Console.WriteLine($"{this.GetType().Name} Katapult");
        }
    }

    public class Swimmer : Transport, ISwimable
    {
        public void Shvartovat()
        {
            Console.WriteLine($"{this.GetType().Name} Shvarting");
        }

        public void Swim()
        {
            Console.WriteLine($"{this.GetType().Name} Swimming");
        }
    }
}
