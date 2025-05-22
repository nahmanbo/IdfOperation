public abstract class Weapon
{
    protected string _name { get; }
    protected float _ammo { get; set; }
    protected int _maxAmmo { get; }
    protected List<string> _targetType { get; }
    public Weapon(string name, float ammo, List<string> effective, int maxAmmo)
    {
        _name = name;
        _ammo = ammo;
        _targetType = effective;
        _maxAmmo = maxAmmo;
    }
    public List<string> GetTargetTypes()
    {
        return _targetType;
    }


    public void UseAmmo(float count)
    {
        if (count < 0 || count > this._maxAmmo)
        {
            Console.WriteLine("The quantity is invalid.");
            return;
        }
        Console.WriteLine("");
        this._ammo -= count;
    }
    public  void UpdateAmmo(float count)
    {
        _ammo += count;
    }
    public abstract void PrintInfo();
    









}