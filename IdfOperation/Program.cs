namespace IdfOperation; 

class Program
{
    static void Main(string[] args)
    {
        Hamas hamas = new Hamas("Yahya Sinwar");
        Idf idf = new Idf("Eyal Zamir");

        while (true)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. View full IDF information");
            Console.WriteLine("2. View all Hamas data");
            Console.WriteLine("3. View Firepower Division data");
            Console.WriteLine("4. View Intelligence Division reports");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            string choice = Console.ReadLine();
            Console.WriteLine(); // spacing

            switch (choice)
            {
                case "1":
                    idf.PrintInfo();
                    break;
                case "2":
                    hamas.PrintInfo();
                    break;
                case "3":
                    idf.Firepower.PrintInfo();
                    break;
                case "4":
                    idf.Intelligence.PrintInfo();
                    break;
                case "5":
                    Console.WriteLine("Exiting program...");
                    return;

                case "6":
                {
                    var report = idf.Intelligence.GetMostDangerousTerrorist();

                    if (report == null)
                    {
                        Console.WriteLine("No intelligence reports available.");
                        break;
                    }

                    var terrorist = report.GetTerrorist();

                    if (!terrorist.IsAlive)
                    {
                        Console.WriteLine($"Most dangerous terrorist ({terrorist.Name}) is already dead.");
                        break;
                    }

                    string targetType = report.GetLastKnownLocation();
                    var weapon = idf.Firepower.GetAvailableWeaponForTarget(targetType);

                    if (weapon == null)
                    {
                        Console.WriteLine($"No available weapon for target type: {targetType}");
                        break;
                    }

                    weapon.AttackTarget(terrorist, 1);
                    break;
                }

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
