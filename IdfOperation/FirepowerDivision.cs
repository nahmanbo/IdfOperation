namespace IdfOperation
{
    public class FirepowerDivision
    {
        private Dictionary<string, List<Weapon>> _weaponsByTarget;

        public FirepowerDivision()
        {
            _weaponsByTarget = new Dictionary<string, List<Weapon>>();

            AddWeapons(i => new F16(i + 1), 5);
            AddWeapons(i => new Zik(i + 1), 8);
            AddWeapons(i => new Tank(i + 1), 3);

        } 
        public IReadOnlyDictionary<string, List<Weapon>> GetWeaponsByTarget()
        {
            return _weaponsByTarget;
        }
        private void AddWeapons(Func<int, Weapon> weaponFactory, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Weapon weapon = weaponFactory(i);
                foreach (var target in weapon.GetTargetTypes())
                {
                    if (!_weaponsByTarget.ContainsKey(target))
                        _weaponsByTarget[target] = new List<Weapon>();

                    _weaponsByTarget[target].Add(weapon);
                }
            }
        }
        public void PrintInfo()
        {
            foreach (var kvp in _weaponsByTarget)
            {
                Console.WriteLine($"Target Type: {kvp.Key}");
                foreach (var weapon in kvp.Value)
                {
                    weapon.PrintInfo();
                }
                Console.WriteLine("--------------------------------");
            }
        }
    }
}