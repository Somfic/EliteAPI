namespace EliteAPI.Status.Models
{
    public class ShipPips
    {
        private readonly int[] _pips;

        internal ShipPips(int[] pips)
        {
            _pips = pips;
        }

        public int System => _pips[0];
        public int Engines => _pips[1];
        public int Weapons => _pips[2];
    }
}