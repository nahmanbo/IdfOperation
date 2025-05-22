public class F16 : Weapon , IFuelable
{
    private int _fuel= 100;
    public F16()
        :base("F16", 8, [ "buildings" ],8) {}

    public  void lessFuel()
    {
        this._fuel -=5 ;
    }
    public void addFuel()
    {
        this._fuel = 100;

    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {_name}, Ammo: {_ammo}/{_maxAmmo}, Effective Against: {string.Join(", ", _targetType)}, Fuel: {_fuel}%");
    }

}
