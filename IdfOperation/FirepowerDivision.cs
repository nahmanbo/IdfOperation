using System.Collections.Generic;

namespace IdfOperation
{
    public class FirepowerDivision
    {
        private List<Weapon> _strikeUnits;

        public FirepowerDivision()
        {
            _strikeUnits = new List<Weapon>();
            // ניתן לאתחל כאן מראש יחידות כמו F16, Hermes, M109
        }

        public void AddStrikeUnit(Weapon unit)
        {
            _strikeUnits.Add(unit);
        }

        public IReadOnlyList<Weapon> GetStrikeUnits()
        {
            return _strikeUnits.AsReadOnly();
        }

        public int GetStrikeCount()
        {
            return _strikeUnits.Count;
        }
    }
}