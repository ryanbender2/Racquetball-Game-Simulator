using System;

namespace Racquetball_Game_Simulator
{
    internal static class Program
    {
        private static string _p1Name;
        private static string _p2Name;
        private static double _p1Prob;
        private static double _p2Prob;
        private static int _games;
        
        private static void Main(string[] args)
        {
            // take inputs
            Console.Out.WriteLine("Player 1's Name: ");
            _p1Name = Console.In.ReadLine();
            Console.Out.WriteLine("Player 2's Name: ");
            _p2Name = Console.In.ReadLine();
            Console.Out.WriteLine("Player 1's Probability: ");
            _p1Prob = Math.Round(double.Parse(
                Console.In.ReadLine() ?? 
                throw new ArgumentException("Null value for Player 1's probability")),
                2, MidpointRounding.ToEven);
            Console.Out.WriteLine("Player 2's Probability: ");
            _p2Prob = Math.Round(double.Parse(
                Console.In.ReadLine() ??
                throw new ArgumentException("Null value for Player 2's probability")),
                2, MidpointRounding.ToEven);
            Console.Out.WriteLine("Number of games to be simulated: ");
            _games = int.Parse(Console.In.ReadLine() ?? 
                               throw new ArgumentException("Null value for games to be simulated"));
            
            // verify probabilities
            if (_p1Prob > 1 || _p2Prob > 1) throw new ArgumentException("Probability values need to be less than 1");
            
            // run game
            var racquetball = new Racquetball(_p1Name, _p2Name,
                _p1Prob, _p2Prob, _games);
            racquetball.SimulateGames(true);
            racquetball.PrintStats();
        }
    }
}