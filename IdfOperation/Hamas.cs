using System;
using System.Collections.Generic;

namespace IdfOperation
{ 
    public class Hamas : Organization
    {
        private readonly List<Terrorist> _terrorists;
        public Hamas(string currentCommander) : base(new DateTime(1987, 12, 14), currentCommander) 
        {
            _terrorists = new List<Terrorist>();
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
        }
    }
}