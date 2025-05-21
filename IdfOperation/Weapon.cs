using System.Collections.Generic;

namespace IdfOperation
{
    public class Weapon
    {
        private List<global::Weapon> _strikeUnits;
        public Weapon()
        {
            _strikeUnits = new List<global::Weapon>();
        } 
        public void AddStrikeUnit(global::Weapon unit)
        {
            _strikeUnits.Add(unit);
        } 
        public IReadOnlyList<global::Weapon> GetStrikeUnits()
        {
            return _strikeUnits.AsReadOnly();
        } 
        public int GetStrikeCount()
        {
            return _strikeUnits.Count;
        }
    }
}