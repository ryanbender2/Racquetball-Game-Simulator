namespace Racquetball_Game_Simulator
{
    public class Player
    {
        private string _name;
        private float _probability;
        private int _wins;
        private int _shutouts;

        public Player(string name, float probability)
        {
            _name = name;
            _probability = probability;
        }

        public void add_win()
        {
            _wins += 1;
        }

        public void add_shutout()
        {
            _wins += 1;
            _shutouts += 1;
        }
    }
}