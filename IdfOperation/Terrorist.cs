namespace IdfOperation
{
    public class Terrorist
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Rank { get; set; }
        public bool IsAlive { get; set; }
        public List<string> Weapons { get; set; }

        //==============================================================
        public Terrorist(string name, int id, int rank, List<string> weapons)
        {
            Name = name;
            Id = id;
            Rank = rank;
            Weapons = weapons;
            IsAlive = true;
        }

        //--------------------------------------------------------------
        public void PrintInfo()
        {
            string status = IsAlive ? "Alive" : "Dead";
            string weaponList = string.Join(", ", Weapons);
            Console.WriteLine($"Terrorist: {Name} | Id: {Id} | Rank: {Rank} | Status: {status} | Weapons: {weaponList}");
        }

        //--------------------------------------------------------------
        public void Kill()
        {
            IsAlive = false;
        }
    }
}
