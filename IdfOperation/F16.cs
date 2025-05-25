namespace IdfOperation
{
    public class F16 : Weapon, IFuelable
    {
        private int _fuel = 100;

        //==============================================================
        public F16(int number)
            : base($"F16-{number}", 8, new List<string> { "buildings" }, 8) {}

        //--------------------------------------------------------------
        public void AddFuel()
        {
            _fuel = 100;
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