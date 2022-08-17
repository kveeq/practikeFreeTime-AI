using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.indexators
{
    public class Footballist
    {
        public Footballist(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public string Name { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return $"{Name} {Number}";
        }
    }

    public class FootballTeam
    {
        public FootballTeam(string name, Footballist[] footballists)
        {
            Name = name;
            this.footballists = footballists;
        }

        public string Name { get; set; }
        public Footballist[] footballists { get; set; }

        public Footballist this[int index]
        {
            get
            {
                if(index <= footballists.Length-1 && index >= 0)
                    return footballists[index];
                else
                    throw new StackOverflowException();
            }
            set
            {
                if (index <= footballists.Length - 1 && index >= 0)
                    footballists[index] = value;
            }
        }
    }
}
