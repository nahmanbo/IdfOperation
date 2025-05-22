using System;

namespace IdfOperation
{
    public class IDF : Organization
    {
        public Weapon Firepower { get; private set; }
        public IntelligenceDivision Intelligence { get; private set; }

        public IDF(string currentCommander)
            : base(new DateTime(1948, 5, 31), currentCommander) 
        {
           // Firepower = new Weapon();
            Intelligence = new IntelligenceDivision();
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"IDF - Commander: {GetCommander()}, Established: {GetEstablishmentDate().ToShortDateString()}"); 
            //Console.WriteLine($"Firepower Units: {Firepower.GetStrikeCount()}");
            //Console.WriteLine($"Intel Messages: {Intelligence.GetIntelCount()}");
        }
    }
}