namespace IdfOperation
{
    public static class TerroristGenerator
    {
        private static readonly List<string> names = new List<string>()
        {
            "Ahmed Yassin", "Mohammed Deif", "Khaled Mashal", "Ismail Haniyeh",
            "Marwan Issa", "Salah Shehade", "Yahya Sinwar", "Ibrahim Abu al-Naja",
            "Mahmoud Zahar", "Fathi Hammad", "Abdel Aziz al-Rantisi", "Mohammed al-Zahar",
            "Jihad al-Amarin", "Tawfiq Abu Naim", "Ayman Nofal"
        };

        private static readonly List<string> weapons = new List<string>()
        {
            "Knife", "Gun", "M16", "AK47"
        };

        private static readonly Random rnd = new Random();

        //==============================================================
        public static List<Terrorist> Generate(int count)
        {
            List<Terrorist> list = new List<Terrorist>();

            for (int i = 0; i < count; i++)
            {
                string name = names[rnd.Next(0, names.Count)];
                int rank = rnd.Next(1, 6);
                int weaponCount = rnd.Next(1, 4);

                List<string> selectedWeapons = new List<string>();

                while (selectedWeapons.Count < weaponCount)
                {
                    string randomWeapon = weapons[rnd.Next(weapons.Count)];
                    if (!selectedWeapons.Contains(randomWeapon))
                        selectedWeapons.Add(randomWeapon);
                }

                list.Add(new Terrorist(name, rank, selectedWeapons));
            }

            return list;
        }
    }
}