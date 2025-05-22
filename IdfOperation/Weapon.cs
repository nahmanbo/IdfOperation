public abstract class Weapon
{
    protected string _name { get; }
    protected float _ammo { get; set; }
    protected int _maxAmmo { get; }
   
    protected List<string> _targetType { get; }

    public Weapon(string name, float ammo, List<string> effective, int _maxAmmo)
    {
        this._name = name;
        this._ammo = ammo;
        this._targetType = effective; 
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