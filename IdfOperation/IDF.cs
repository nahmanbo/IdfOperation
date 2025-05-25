namespace IdfOperation
{
    public class Idf : Organization
    {
        public FirepowerDivision Firepower { get; private set; }
        public IntelligenceDivision Intelligence { get; private set; }

        //====================================
        public Idf(string currentCommander)
            : base(new DateTime(1948, 5, 31), currentCommander)
        {
            Firepower = new FirepowerDivision();
            Intelligence = new IntelligenceDivision();
        }

        //--------------------------------------------------------------
        public override void PrintInfo()
        {
            Console.WriteLine($"IDF - Commander: {GetCommander()}, Established: {GetEstablishmentDate().ToShortDateString()}");

            Console.WriteLine("=== Firepower Division ===");
            Firepower.PrintInfo();

            Console.WriteLine("=== Intelligence Division ===");
            Intelligence.PrintInfo();
        }
    }
}