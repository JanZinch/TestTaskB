using System.Linq;

namespace TestTask
{
    public class FullName
    {
        public readonly string Surname;
        public readonly string Name;
        public readonly string Patronymic;

        public FullName(string surname, string name, string patronymic)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
        }
        
        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}";
        }
        
        public override int GetHashCode()
        {
            return ToString().Select<char, int>(character => (int)character).Sum();
        }
        
        public override bool Equals(object? obj)
        {
            if (obj is FullName other)
            {
                return Compare(this, other); 
            }
            else
            {
                return false;
            }
        }

        private static bool Compare(FullName a, FullName b)
        {
            return ReferenceEquals(a,b) 
                   || a.Surname == b.Surname && a.Name == b.Name && a.Patronymic == b.Patronymic;
        }
    }
}