namespace IdfOperation
{
    public class IntelligenceReport
    {
        private Terrorist _terrorist;
        private int _threatLevel;
        private string _lastKnownLocation;
        private DateTime _reportTime;

        //====================================
        public IntelligenceReport(Terrorist terrorist, string lastKnownLocation, DateTime reportTime)
        {
            _terrorist = terrorist;
            _lastKnownLocation = lastKnownLocation;
            _reportTime = reportTime;
            _threatLevel = CalculateThreatScore();
        }

        //--------------------------------------------------------------
        private int CalculateThreatScore()
        {
            int weaponScore = 0;

            foreach (var weapon in _terrorist.Weapons)
            {
                if (weapon.Equals("Knife", StringComparison.OrdinalIgnoreCase))
                    weaponScore += 1;
                else if (weapon.Equals("Gun", StringComparison.OrdinalIgnoreCase))
                    weaponScore += 2;
                else if (weapon.Equals("M16", StringComparison.OrdinalIgnoreCase) || weapon.Equals("AK47", StringComparison.OrdinalIgnoreCase))
                    weaponScore += 3;
            }

            return _terrorist.Rank * weaponScore;
        }

        //--------------------------------------------------------------
        public void UpdateTerrorist(Terrorist newTerrorist)
        {
            if (newTerrorist == null)
                throw new ArgumentNullException(nameof(newTerrorist));

            _terrorist = newTerrorist;
            _threatLevel = CalculateThreatScore();
        }

        //--------------------------------------------------------------
        public void UpdateLastKnownLocation(string newLocation)
        {
            if (string.IsNullOrWhiteSpace(newLocation))
                throw new ArgumentException("Location cannot be empty.");

            _lastKnownLocation = newLocation;
        }

        //--------------------------------------------------------------
        public void UpdateReportTime(DateTime newTime)
        {
            _reportTime = newTime;
        }

        //--------------------------------------------------------------
        public Terrorist GetTerrorist()
        {
            return _terrorist;
        }

        //--------------------------------------------------------------
        public int GetThreatLevel()
        {
            return _threatLevel;
        }

        //--------------------------------------------------------------
        public string GetLastKnownLocation()
        {
            return _lastKnownLocation;
        }

        //--------------------------------------------------------------
        public DateTime GetReportTime()
        {
            return _reportTime;
        }

        //--------------------------------------------------------------
        public void PrintInfo()
        {
            Console.WriteLine("=== Intelligence Report ===");
            _terrorist.PrintInfo();
            Console.WriteLine($"Threat Level: {_threatLevel}");
            Console.WriteLine($"Last Known Location: {_lastKnownLocation}");
            Console.WriteLine($"Report Date: {_reportTime:yyyy-MM-dd HH:mm}");
        }
    }
}
