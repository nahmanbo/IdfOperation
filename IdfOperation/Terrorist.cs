using System;
using System.Collections.Generic;

namespace IdfOperation
{
    public class Terrorist
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public bool IsAlive { get; set; }
        public List<string> Weapons { get; set; }

        public Terrorist(string name, int rank, List<string> weapons)
        {
            Name = name;
            Rank = Math.Clamp(rank, 1, 5);
            Weapons = weapons ?? new List<string>();
            IsAlive = true;
        }

        public void PrintInfo()
        {
            string status = IsAlive ? "Alive" : "Dead";
            string weaponList = Weapons.Count > 0 ? string.Join(", ", Weapons) : "Unarmed";
            Console.WriteLine($"Terrorist: {Name} | Rank: {Rank} | Status: {status} | Weapons: {weaponList}");
        }

        public void Kill()
        {
            IsAlive = false;
        }
    }

    public static class TerroristGenerator
    {
        private static readonly List<string> names = new()
        {
            "Ahmed Yassin", "Mohammed Deif", "Khaled Mashal", "Ismail Haniyeh",
            "Marwan Issa", "Salah Shehade", "Yahya Sinwar", "Ibrahim Abu al-Naja"
        };

        private static readonly List<string> weapons = new()
        {
            "Knife", "Gun", "M16", "AK47"
        };

        private static readonly Random rnd = new();

        public static List<Terrorist> Generate(int count)
        {
            var list = new List<Terrorist>();

            for (int i = 0; i < count; i++)
            {
                string name = names[rnd.Next(names.Count)] + $" #{i + 1}";
                int rank = rnd.Next(1, 6);

                int weaponCount = rnd.Next(1, 4);
                var shuffled = new List<string>(weapons);
                shuffled.Sort((a, b) => rnd.Next(-1, 2));
                var selectedWeapons = shuffled.GetRange(0, weaponCount);

                list.Add(new Terrorist(name, rank, selectedWeapons));
            }

            return list;
        }
    }
}
