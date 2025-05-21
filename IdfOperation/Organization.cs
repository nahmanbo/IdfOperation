using System;

namespace IdfOperation
{
    public abstract class Organization
    {
        private string _currentCommander;
        public DateTime EstablishmentDate { get; }

        protected Organization(DateTime establishmentDate, string currentCommander)
        {
            EstablishmentDate = establishmentDate;
            _currentCommander = currentCommander;
        }
        public string GetCommander()
        {
            return _currentCommander;
        }
        public void ChangeCommander(string newCommander)
        {
            _currentCommander = newCommander;
        } 
        public abstract void PrintInfo();
    }
}