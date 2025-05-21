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

        public int CalculateQualityScore()
        {
            int weaponPoints = 0;

            foreach (var weapon in Weapons)
            {
                switch (weapon.ToLower())
                {
                    case "knife":
                        weaponPoints += 1;
                        break;
                    case "gun":
                        weaponPoints += 2;
                        break;
                    case "m16":
                    case "ak47":
                        weaponPoints += 3;
                        break;
                }
            }

            return Rank * weaponPoints;
        }

        public void Kill()
        {
            IsAlive = false;
        }
    }
}