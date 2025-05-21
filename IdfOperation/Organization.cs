namespace IdfOperation
{
    public abstract class Organization
    {
        public DateTime EstablishmentDate { get; set; }
        public string CurrentCommander { get; set; }

        protected Organization(DateTime establishmentDate, string currentCommander)
        {
            EstablishmentDate = establishmentDate;
            CurrentCommander = currentCommander;
        }

        public abstract void PrintInfo();
    }
}