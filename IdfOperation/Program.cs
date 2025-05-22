namespace IdfOperation;

class Program
{
    static void Main(string[] args)
    {
        Hamas hamas = new Hamas("Yahya Sinwar");
        hamas.PrintInfo();
        hamas.ChangeCommander("Mohammed Deif");
        hamas.PrintInfo();

        F16 f161 = new F16();
        f161.PrintInfo();
    }
}