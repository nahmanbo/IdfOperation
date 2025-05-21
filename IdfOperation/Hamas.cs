using System;
using System.Collections.Generic;

namespace IdfOperation
{
    public class Hamas : Organization
    {
        public List<Terrorist> Terrorists { get; set; }

        public Hamas(DateTime establishmentDate, string currentCommander)
            : base(establishmentDate, currentCommander)
        {
            Terrorists = new List<Terrorist>();
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Hamas - Commander: {CurrentCommander}, Established: {EstablishmentDate.ToShortDateString()}");
        }
    }
}