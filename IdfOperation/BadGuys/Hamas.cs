using IdfOperation.Organizations;

namespace IdfOperation.BadGuys
{
    public class Hamas : Organization
    {
        private static Hamas? _instance;
        private readonly List<Terrorist> _terrorists;

        //====================================
        public static Hamas Instance => _instance!;

        //====================================
        public Hamas(string currentCommander)
            : base(new DateTime(1987, 12, 14), currentCommander)
        {
            _instance = this;
            _terrorists = TerroristGenerator.Generate(3).Result;
        }

        //--------------------------------------------------------------
        public IReadOnlyList<Terrorist> GetTerrorists()
        {
            return _terrorists.AsReadOnly();
        }

        //--------------------------------------------------------------
        public void AddTerrorist(Terrorist terrorist)
        {
            _terrorists.Add(terrorist);
        }

        //--------------------------------------------------------------
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