namespace Racquetball_Game_Simulator
{
    public class Player
    {
        private readonly string _name;
        private readonly double _probability;
        private int _wins;
        private int _shutouts;

        public Player(string name, double probability)
        {
            _name = name;
            _probability = probability;
        }

        public void AddWin() { _wins += 1; }

        public void AddShutout() 
        {
            _wins += 1;
            _shutouts += 1;
        }
        
        public string GetName() { return _name; }
        public double GetProb() { return _probability; }
        public int GetWins() { return _wins;}
        public int GetShutouts() { return  _shutouts; }
    }
}