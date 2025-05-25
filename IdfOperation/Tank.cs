namespace IdfOperation
{
    public class Tank : Weapon, IFuelable
    {
        private int _fuel = 50;

        //==============================================================
        public Tank(int number)
            : base($"Tank-{number}", 40, new List<string> { "open areas" }, 40) {}

        //--------------------------------------------------------------
        public void AddFuel()
        {
            _fuel = 50;
        }

        //--------------------------------------------------------------
        public void LessFuel()
        {
            _fuel = Math.Max(0, _fuel - 5);
        }

        //--------------------------------------------------------------
        public int GetFuel()
        {
            return _fuel;
        }

        //--------------------------------------------------------------
        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Ammo: {Ammo}/{MaxAmmo}, Effective Against: {string.Join(", ", TargetTypes)}, Fuel: {_fuel} liters");
        }
    }
}