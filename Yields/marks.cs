namespace Yields
{
    public class Marks : IComparable<Marks>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Physick { get; set; }
        public int Inform { get; set; }
        public int Mathe { get; set; }
        public double Srednay { get => (Physick + Inform + Mathe) / 3.0; }

        public Marks(string? name, string? surname, int physick, int inform, int mathe)
        {
            Name = name;
            Surname = surname;
            Physick = physick;
            Inform = inform;
            Mathe = mathe;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Mathe} {Physick} {Inform} {Srednay}";
        }

        public int CompareTo(Marks? other)
        {
            return this.Srednay.CompareTo(other?.Srednay);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}