namespace IdfOperation
{
    public class IntelligenceDivision
    {
        private readonly List<IntelligenceReport> _reports;
        private static readonly List<string> Locations = new() { "buildings", "people", "vehicles", "open areas" };
        private static readonly Random Random = new();

        //====================================
        public IntelligenceDivision()
        {
            _reports = new List<IntelligenceReport>();

            foreach (var terrorist in Hamas.Instance.GetTerrorists())
            {
                string location = GetRandomLocation();
                var report = new IntelligenceReport(terrorist, location, DateTime.Now);
                _reports.Add(report);
            }
        }

        //--------------------------------------------------------------
        private string GetRandomLocation()
        {
            int index = Random.Next(Locations.Count);
            return Locations[index];
        }

        //--------------------------------------------------------------
        public IReadOnlyList<IntelligenceReport> GetReports()
        {
            return _reports.AsReadOnly();
        }

        //--------------------------------------------------------------
        public IntelligenceReport GetMostDangerousTerrorist()
        { 
            IntelligenceReport mostDangerous = _reports[0];

            foreach (var report in _reports)
            {
                if (report.GetThreatLevel() > mostDangerous.GetThreatLevel())
                    mostDangerous = report;
            }

            return mostDangerous;
        }
        //--------------------------------------------------------------
        public IntelligenceReport GetTerroristByName(string name)
        {
            IntelligenceReport ByName = null;

            foreach(var report in _reports)
            {
                if (string.Equals(report.GetTerrorist().Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    ByName = report;
                    break;
                }

            }
            return ByName;
        }
        //--------------------------------------------------------------
        public void PrintInfo()
        {
            foreach (var report in _reports)
            {
                report.PrintInfo();
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
