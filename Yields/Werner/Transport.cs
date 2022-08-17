using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Werner
{
    public class Transport : ITransport
    {
        public int GetTime(int distance, int speed)
        {
            return distance / speed;
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

    public class Car : Transport, IGo
    {
        public void Go()
        {
            Console.WriteLine($"{this.GetType().Name} Go");
        }

        public void Remen()
        {
            Console.WriteLine($"{this.GetType().Name} Remen");
        }
    }

    public class Flyer : Transport, IFly
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
}
