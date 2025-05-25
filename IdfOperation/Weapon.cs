namespace IdfOperation
{
    public abstract class Weapon
    {
        protected string _name { get; }
        protected float _ammo { get; set; }
        protected int _maxAmmo { get; }
        protected List<string> _targetType { get; }

        //==============================================================
        protected Weapon(string name, float ammo, List<string> effective, int maxAmmo)
        {
            _name = name;
            _ammo = ammo;
            _targetType = effective;
            _maxAmmo = maxAmmo;
        }

        //--------------------------------------------------------------
        public List<string> GetTargetTypes()
        {
            return _targetType;
        }

        //--------------------------------------------------------------
        public void UseAmmo(float count)
        {
            if (count < 0 || count > _maxAmmo)
            {
                Console.WriteLine("The quantity is invalid.");
                return;
            }
            _ammo -= count;
        }

        //--------------------------------------------------------------
        public void UpdateAmmo(float count)
        {
            _ammo += count;
        }

        //--------------------------------------------------------------
        public float GetAmmo()
        {
            return _ammo;
        }

        //--------------------------------------------------------------
        public abstract void PrintInfo();

        //--------------------------------------------------------------
        public void AttackTarget(Terrorist terrorist, float ammoToUse)
        {
            if (!terrorist.IsAlive)
            {
                Console.WriteLine($"{terrorist.Name} is already dead.");
                return;
            }

            UseAmmo(ammoToUse);

            if (this is IFuelable fuelable)
                fuelable.LessFuel();

            terrorist.Kill();
            Console.WriteLine($"{_name} attacked and killed {terrorist.Name}.");
        }
    }
}
