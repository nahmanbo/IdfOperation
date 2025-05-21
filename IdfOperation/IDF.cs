namespace IdfOperation
{
    public class IDF : Organization
    {
        public FirepowerDivision Firepower { get; private set; }
        public IntelligenceDivision Intelligence { get; private set; }

        public IDF(DateTime establishmentDate, string currentCommander)
            : base(establishmentDate, currentCommander)
        {
            Firepower = new FirepowerDivision();
            Intelligence = new IntelligenceDivision();
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"IDF - Commander: {CurrentCommander}, Established: {EstablishmentDate.ToShortDateString()}");
            Console.WriteLine($"Firepower Units: {Firepower.GetStrikeCount()}");
            Console.WriteLine($"Intel Messages: {Intelligence.GetIntelCount()}");
        }
    }
}