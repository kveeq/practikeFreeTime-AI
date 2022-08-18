using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public abstract class Transport : ITransport, IMoveable
    {
        public event Action<string> ToplivoChanged;
        const int minSpeed = 0;
        private static int maxSpeed = 100;
        private int toplivo = 100; 
        public int Toplivo { get => toplivo; set { ToplivoChanged?.Invoke($"Топливо изменилось на {value - toplivo}: Toplivo = {toplivo}"); toplivo = value; } }

        public int MaxSpeed { get => maxSpeed; set { if (value > 0) maxSpeed = value; } }

        public void Move()
        {
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

    public class Moto : Transport
    {
        public void BeforeUp()
        {
            Console.WriteLine($"{this.GetType().Name} Upping");
        }
    }

    public class Human : Transport, IHumanable
    {
        private int hp = 100;
        public int Hp { get => hp; set  { hp = value; HpChange?.Invoke($"Здоровье изменилось - {Hp}"); } }

        public event Action<string> HpChange;

        public void Eat(Food food)
        {
            Console.WriteLine($"{this.GetType().Name} Eating");
            food.Eat(this);
        }

        public void Jump()
        {
            Console.WriteLine($"{this.GetType().Name} Jumping");
        }

        public void Living()
        {
            Console.WriteLine($"{this.GetType().Name} Living");
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
