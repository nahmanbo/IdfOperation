interface IFuelable
{ 
    int fuel { get; } 
    public void lessFuel(int count);
    public void addFuel();
}