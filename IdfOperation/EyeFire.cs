using IdfOperation;

public class EyeFire : Weapon
{
    //--------------------------------------------------------------
    public EyeFire(int number)
            : base($"EyeFire-{number}", 1200, new List<string> { "Fence space" }, 1200) { }
    //--------------------------------------------------------------
    public override void UseAmmo()
    {
        Ammo -= 30;
    }
    //--------------------------------------------------------------
    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Ammo: {Ammo}/{MaxAmmo}, Effective Against: {string.Join(", ", TargetTypes)}");
    }
}