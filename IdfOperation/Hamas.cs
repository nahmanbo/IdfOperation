using System;
using System.Collections.Generic;

namespace IdfOperation
{
    public class Hamas : Organization
    {
        public List<Terrorist> Terrorists { get; set; }

        public Hamas(string currentCommander)
            : base(new DateTime(1987, 12, 10), currentCommander)
        {
            Terrorists = new List<Terrorist>();
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Hamas - Commander: {GetCommander()}, Established: {EstablishmentDate.ToShortDateString()}");
        }
    }
}