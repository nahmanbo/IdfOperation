using IdfOperation.BadGuys;
using IdfOperation.GoodGuys;

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
                Console.WriteLine("5. View terrorist report by name");
                Console.WriteLine("6. View most dangerous terrorist report");
                Console.WriteLine("7. Eliminate terrorist by name");
                Console.WriteLine("8. Eliminate the most dangerous terrorist");
                Console.WriteLine("9. Eliminate terrorists by target type");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice (1-10): ");

                string choice = Console.ReadLine()?.Trim() ?? "";

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
                        PrintReportByTerroristName();
                        break;
                    case "6":
                        PrintMostDangerousTerroristReport();
                        break;
                    case "7":
                        EliminateByName();
                        break;
                    case "8":
                        EliminateMostDangerous();
                        break;
                    case "9":
                        EliminateByTargetType();
                        break;
                    case "10":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        //--------------------------------------------------------------
        private void PrintReportByTerroristName()
        {
            Console.Write("Enter terrorist name: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            var report = _idf.Intelligence.GetReportByTerroristName(name);
            if (report == null)
            {
                Console.WriteLine($"No report found for terrorist: {name}");
                return;
            }

            report.PrintInfo();
        }

        //--------------------------------------------------------------
        private void PrintMostDangerousTerroristReport()
        {
            var report = _idf.Intelligence.GetMostDangerousAliveReport();
            if (report == null)
            {
                Console.WriteLine("No alive terrorist reports available.");
                return;
            }

            report.PrintInfo();
        }

        //--------------------------------------------------------------
        private void EliminateByName()
        {
            Console.Write("Enter the name of the terrorist to eliminate: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            var report = _idf.Intelligence.GetReportByTerroristName(name);
            if (report == null)
            {
                Console.WriteLine($"No intelligence report found for terrorist: {name}");
                return;
            }

            var terrorist = report.GetTerrorist();
            if (!terrorist.IsAlive)
            {
                Console.WriteLine($"{name} is already dead.");
                return;
            }

            var weapon = _idf.Firepower.FindAvailableWeaponFor(report.GetLastKnownLocation());
            if (weapon == null)
            {
                Console.WriteLine($"No weapon available for target type: {report.GetLastKnownLocation()}");
                return;
            }

            TryEliminate(report.GetTerrorist(), report.GetLastKnownLocation());
        }

        //--------------------------------------------------------------
        private void EliminateMostDangerous()
        {
            var report = _idf.Intelligence.GetMostDangerousAliveReport();
            if (report == null)
            {
                Console.WriteLine("No alive intelligence reports available.");
                return;
            }

            TryEliminate(report.GetTerrorist(), report.GetLastKnownLocation());
        }

        //--------------------------------------------------------------
        private void EliminateByTargetType()
        {
            Console.Write("Enter target type name: ");
            string targetType = Console.ReadLine()?.Trim() ?? "";

            bool anyEliminated = false;

            foreach (var report in _idf.Intelligence.GetReports())
            {
                var terrorist = report.GetTerrorist();

                if (report.GetLastKnownLocation() == targetType && TryEliminate(terrorist, targetType))
                {
                    anyEliminated = true;
                }
            }

            if (!anyEliminated)
            {
                Console.WriteLine($"No eligible terrorists found for target type: {targetType}");
            }
        }

        //--------------------------------------------------------------
        private bool TryEliminate(Terrorist terrorist, string targetType)
        {
            if (!terrorist.IsAlive)
            {
                Console.WriteLine($"{terrorist.Name} is already dead.");
                return false;
            }

            var weapon = _idf.Firepower.FindAvailableWeaponFor(targetType);
            if (weapon == null)
            {
                Console.WriteLine($"No weapon available for target type: {targetType}");
                return false;
            }

            weapon.AttackTarget(terrorist);
            return true;
        }
    }
}
