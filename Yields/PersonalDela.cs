using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields
{
    public class PersonalDela : IComparable
    {
        public PersonalDela(string surname, string name, string clas, string dateOfBirth)
        {
            Surname = surname;
            Name = name;
            Clas = clas;
            DateOfBirth = dateOfBirth;
        }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Clas { get; set; }
        public string DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"{Clas} {Surname} {Name} {DateOfBirth}";
        }

        //public int CompareTo(PersonalDela? other)
        //{

        //}

        public int CompareTo(object obj)
        {
            PersonalDela other = (PersonalDela)obj;
            int clas1 = Convert.ToInt32(Clas.Remove(Clas.Length - 1));
            int clas2 = Convert.ToInt32(other?.Clas.Remove(other.Clas.Length - 1));
            int res3 = clas1.CompareTo(clas2);
            if (res3 == 0)
            {
                int res = Clas[Clas.Length - 1].CompareTo(other?.Clas[other.Clas.Length - 1]); // -1
                if (res == 0)
                {
                    int res1 = Surname.CompareTo(other?.Surname); // 1
                    if (res1 == 0)
                        return Name.CompareTo(other.Name);
                    return res1;
                }

                return res;
            }

            return res3;
        }
    }
}
