using System;
using System.Collections.Generic;

namespace IdfOperation
{ 
    public class Hamas : Organization
    {
        private readonly List<Terrorist> _terrorists;
        public Hamas(string currentCommander) : base(new DateTime(1987, 12, 14), currentCommander) 
        {
            _terrorists = TerroristGenerator.Generate(10);
        } 
        public IReadOnlyList<Terrorist> GetTerrorists()
        {
            return _terrorists.AsReadOnly();
        }

        public void AddTerrorist(Terrorist terrorist)
        { 
            _terrorists.Add(terrorist);
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Hamas - Commander: {GetCommander()}, Established: {GetEstablishmentDate().ToShortDateString()}");
            Console.WriteLine($"Terrorist Count: {_terrorists.Count}");

            Console.WriteLine("=== Terrorists ===");
            foreach (var terrorist in _terrorists)
            {
                terrorist.PrintInfo();
            }
            Console.WriteLine("==================");
        }
    }
}