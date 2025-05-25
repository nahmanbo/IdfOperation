namespace IdfOperation
{
    public static class TerroristGenerator
    {
        private static readonly List<string> Names = new List<string>()
        {
            "Ahmed Yassin", "Mohammed Deif", "Khaled Mashal", "Ismail Haniyeh",
            "Marwan Issa", "Salah Shehade", "Yahya Sinwar", "Ibrahim Abu al-Naja",
            "Mahmoud Zahar", "Fathi Hammad", "Abdel Aziz al-Rantisi", "Mohammed al-Zahar",
            "Jihad al-Amarin", "Tawfiq Abu Naim", "Ayman Nofal"
        };

        private static readonly List<string> Weapons = new List<string>()
        {
            "Knife", "Gun", "M16", "AK47"
        };

        private static readonly Random Rnd = new Random();

        //==============================================================
        public static List<Terrorist> Generate(int count)
        {
            List<Terrorist> list = new List<Terrorist>();

            for (int i = 0; i < count; i++)
            {
                string name = Names[Rnd.Next(0, Names.Count)];
                int rank = Rnd.Next(1, 6);
                int weaponCount = Rnd.Next(1, 4);

                List<string> selectedWeapons = new List<string>();

                while (selectedWeapons.Count < weaponCount)
                {
                    string randomWeapon = Weapons[Rnd.Next(Weapons.Count)];
                    if (!selectedWeapons.Contains(randomWeapon))
                        selectedWeapons.Add(randomWeapon);
                }

                list.Add(new Terrorist(name, rank, selectedWeapons));
            }

            return list;
        }
    }
}