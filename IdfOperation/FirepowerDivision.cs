using System;
using System.Collections.Generic;

namespace IdfOperation
{
    public class FirepowerDivision
    {
        private readonly Dictionary<string, List<Weapon>> _weaponsByTarget;
        public FirepowerDivision()
        {
            _weaponsByTarget = new Dictionary<string, List<Weapon>>();

            AddF16(5);
            AddZik(8);
            AddTank(3);
        }
        private void AddF16(int count)
        {
            for (int i = 0; i < count; i++)
            {
                F16 f16 = new F16(i + 1);
                AddWeaponToTargets(f16);
            }
        }

        private void AddZik(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Zik zik = new Zik(i + 1);
                AddWeaponToTargets(zik);
            }
        }

        private void AddTank(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Tank tank = new Tank(i + 1);
                AddWeaponToTargets(tank);
            }
        }

        private void AddWeaponToTargets(Weapon weapon)
        {
            List<string> targets = weapon.GetTargetTypes();
            foreach (string target in targets)
            {
                if (!_weaponsByTarget.ContainsKey(target))
                {
                    _weaponsByTarget[target] = new List<Weapon>();
                }

                _weaponsByTarget[target].Add(weapon);
            }
        }

        public IReadOnlyDictionary<string, List<Weapon>> GetWeaponsByTarget()
        {
            return _weaponsByTarget;
        }
        public Weapon? GetAvailableWeaponForTarget(string targetType)
        {
            if (!_weaponsByTarget.ContainsKey(targetType))
                return null;

            foreach (var weapon in _weaponsByTarget[targetType])
            {
                bool hasAmmo = weapon.GetAmmo() > 0;
                bool hasFuel = true;

                if (weapon is IFuelable fuelable)
                    hasFuel = fuelable.GetFuel() > 0;

                if (hasAmmo && hasFuel)
                    return weapon;
            }

            return null;
        }
        public void PrintInfo()
        {
            foreach (KeyValuePair<string, List<Weapon>> kvp in _weaponsByTarget)
            {
                Console.WriteLine($"Target Type: {kvp.Key}");
                foreach (Weapon weapon in kvp.Value)
                {
                    weapon.PrintInfo();
                }
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
