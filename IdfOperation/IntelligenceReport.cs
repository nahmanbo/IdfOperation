using System;

namespace IdfOperation
{
    public class IntelligenceReport
    {
        public Terrorist Target { get; }
        public int ThreatLevel { get; }
        public string LastKnownLocation { get; }
        public DateTime ReportDate { get; }

        //====================================
        public IntelligenceReport(Terrorist target, string lastKnownLocation, DateTime reportDate)
        {
            Target = target;
            LastKnownLocation = lastKnownLocation;
            ReportDate = reportDate;
            ThreatLevel = CalculateThreatScore();
        }

        //--------------------------------------------------------------
        private int CalculateThreatScore()
        {
            int weaponScore = 0;

            foreach (var weapon in Target.Weapons)
            {
                if (weapon.Equals("Knife", StringComparison.OrdinalIgnoreCase))
                    weaponScore += 1;
                else if (weapon.Equals("Gun", StringComparison.OrdinalIgnoreCase))
                    weaponScore += 2;
                else if (weapon.Equals("M16", StringComparison.OrdinalIgnoreCase) || weapon.Equals("AK47", StringComparison.OrdinalIgnoreCase))
                    weaponScore += 3;
            }

            return Target.Rank * weaponScore;
        }

        //--------------------------------------------------------------
        public void PrintReport()
        {
            Console.WriteLine("=== Intelligence Report ===");
            Target.PrintInfo();
            Console.WriteLine($"Threat Level: {ThreatLevel}");
            Console.WriteLine($"Last Known Location: {LastKnownLocation}");
            Console.WriteLine($"Report Date: {ReportDate:yyyy-MM-dd HH:mm}");
        }
    }
}