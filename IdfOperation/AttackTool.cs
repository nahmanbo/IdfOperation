abstract class Weapon
{
    private string _name { get; }
    //תחמושת
    private int _ammo { get; }
    //יעילות
    private string _targetType { get; }


    public Weapon(string name, int ammunitionCapacity, string effective)
    {
        this._name = name;
        this._ammo = ammunitionCapacity;
        this._targetType = effective;
    }


   public abstract void UseAmmo(int count) ;







}