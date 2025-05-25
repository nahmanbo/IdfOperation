using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;

namespace IdfOperation
{
    public class Tank : Weapon, IFuelable
    {
        private int _fuel = 50;

        //==============================================================
        public Tank(int number)
            : base($"Tank-{number}", 40, new List<string> { "open areas" }, 40) {}

        //--------------------------------------------------------------
        public void AddFuel()
        {
            _fuel = 50;
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
        public override void  UseAmmo()
        {
            string input = "";
            while(input != "2" && input != "3") { 
            Console.WriteLine($"You need a {Name} Select quantity of shell : (2 or 3) ");
            input = Console.ReadLine();

                switch (input)
                {
                    case "2":
                        Ammo -= 2;
                        break;

                    case "3":
                        Ammo -= 3;
                        break;

                    default:
                        Console.WriteLine("Enter a valid number.");
                        break;
                }
            }
        }
        //--------------------------------------------------------------
        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Ammo: {Ammo}/{MaxAmmo}, Effective Against: {string.Join(", ", TargetTypes)}, Fuel: {_fuel} liters");
        }
    }
}