namespace IdfOperation;

public class Zik : Weapon, IFuelable
{
    private int _fuel = 100;
    public Zik()
        : base("Zik", 3, ["people", "vehicles"], 3) { }

    public void lessFuel()
    {
        this._fuel -= 5;
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