using System;
using System.Collections.Generic;

namespace IdfOperation
{
    public class IntelligenceDivision
    {
        private readonly List<IntelligenceReport> _reports;
        private static readonly List<string> _locations = new() { "buildings", "people", "vehicles", "open areas" };
        private static readonly Random _random = new();

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
            int index = _random.Next(_locations.Count);
            return _locations[index];
        }

        //--------------------------------------------------------------
        public IReadOnlyList<IntelligenceReport> GetReports()
        {
            return _reports.AsReadOnly();
        }

        //--------------------------------------------------------------
        public void PrintAllReports()
        {
            if (_reports.Count == 0)
            {
                Console.WriteLine("No intelligence reports available.");
                return;
            }

            foreach (var report in _reports)
            {
                report.PrintReport();
                Console.WriteLine("--------------------------------");
            }
        }
    }
}