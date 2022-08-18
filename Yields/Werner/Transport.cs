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
        public event Action<string> ToplivoChanged;
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
        private bool isDead = false;
        public int Hp { 
            get => hp; 
            set  
            {
                hp = value;
                if (value < 0)
                {
                    HumanDead?.Invoke($"human dead");
                    isDead = true;
                    return;
                }
                HpChange?.Invoke($"Здоровье изменилось - {Hp}"); 
            }
        }

        public int damage = 10;

        public event Action<string> HpChange;
        public event Action<string> HumanDead;

        public void Eat(Food food)
        {
            if (isDead)
            {
                Console.WriteLine("human dead");
                return;
            }
            food.Eat(this);
            Console.WriteLine($"{this.GetType().Name} Eating");
        }

        public void Jump()
        {
            if (isDead)
            {
                Console.WriteLine("human dead");
                return;
            }
            Console.WriteLine($"{this.GetType().Name} Jumping");
        }

        public void Living()
        {
            if (isDead)
            {
                Console.WriteLine("human dead");
                return;
            }
            Console.WriteLine($"{this.GetType().Name} Living");
        }

        public void Hit(IHumanable human2)
        {
            if (isDead)
            {
                Console.WriteLine("human dead");
                return;
            }
            human2.Hp -= damage;
        }     
        
        public void Hit(IHumanable human2, Weapon weapon)
        {
            if (isDead)
            {
                Console.WriteLine("human dead");
                return;
            }
            human2.Hp -= weapon.Damage;
        }

        public void Move()
        {
            Console.WriteLine($"{this.GetType().Name} Moving");
        }

        public void Run()
        {
            Console.WriteLine($"{this.GetType().Name} Running");
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
            Console.WriteLine($"{this.GetType().Name} Svarting");
        }

        public void Swim()
        {
            Console.WriteLine($"{this.GetType().Name} Swimming");
        }
    }
}
