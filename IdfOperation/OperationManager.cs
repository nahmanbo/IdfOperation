namespace IdfOperation
{
    public class OperationManager
    {
        private readonly Idf _idf;
        private readonly Hamas _hamas;

        //====================================
        public OperationManager(Idf idf, Hamas hamas)
        {
            _idf = idf;
            _hamas = hamas;
            RunMenu();
        }

        //--------------------------------------------------------------
        public void RunMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. View full IDF information");
                Console.WriteLine("2. View full Hamas information");
                Console.WriteLine("3. View Firepower Division data");
                Console.WriteLine("4. View Intelligence Division reports");
                Console.WriteLine("5. View most dangerous terrorist report");
                Console.WriteLine("6. View all terrorist reports sorted by threat level");
                Console.WriteLine("7. Eliminate terrorist by name");
                Console.WriteLine("8. Eliminate the most dangerous terrorist");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice (1-9): ");

                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        _idf.PrintInfo();
                        break;

                    case "2":
                        _hamas.PrintInfo();
                        break;

                    case "3":
                        _idf.Firepower.PrintInfo();
                        break;

                    case "4":
                        _idf.Intelligence.PrintInfo();
                        break;

                    case "5":
                        _idf.Intelligence.GetMostDangerousAliveReport().PrintInfo();
                        break;

                    case "6":
                        _idf.Intelligence.GetMostDangerousAliveReport().PrintInfo();
                        break;

                    case "7":
                        //EliminateByName();
                        break;

                    case "8":
                        EliminateMostDangerous();
                        break;

                    case "9":
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
        

        //--------------------------------------------------------------
        private void EliminateMostDangerous()
        {
            var report = _idf.Intelligence.GetMostDangerousAliveReport();
            if (report == null)
            {
                Console.WriteLine("No intelligence reports available.");
                return;
            }

            var terrorist = report.GetTerrorist();

            if (!terrorist.IsAlive)
            {
                Console.WriteLine($"Most dangerous terrorist ({terrorist.Name}) is already dead.");
                return;
            }

            var weapon = _idf.Firepower.FindAvailableWeaponFor(report.GetLastKnownLocation());
            if (weapon == null)
            {
                Console.WriteLine($"No available weapon for target type: {report.GetLastKnownLocation()}");
                return;
            }

            weapon.AttackTarget(terrorist, 1);
        }
    }
}
