namespace IdfOperation
{
    public class Tank : Weapon, IFuelable
    {
        private int _fuel = 100; 
        public Tank(int number) : base($"Tank-{number}", 40, new List<string> { "open areas" }, 40) {} 
        public void LessFuel()
        {
            _fuel = Math.Max(0, _fuel - 5);
        }
        public void AddFuel()
        {
            _fuel = 100;
        } 
        public int GetFuel()
        {
            return _fuel;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {_name}, Ammo: {_ammo}/{_maxAmmo}, Effective Against: {string.Join(", ", _targetType)}, Fuel: {_fuel}%");
        }
    }
}
