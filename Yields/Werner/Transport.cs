using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public abstract class Transport : ITransport
    {
        const int minSpeed = 0;
        private static int maxSpeed = 100;

        public int MaxSpeed { get => maxSpeed; set { if (value > 0) maxSpeed = value; } }

        public void Move()
        {
            Console.WriteLine($"{this.GetType().Name} moving");
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

    public class Human : Transport, IHumanable
    {
        public void Jump()
        {
            Console.WriteLine($"{this.GetType().Name} Jumping");
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
