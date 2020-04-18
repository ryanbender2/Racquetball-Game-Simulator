using System;

namespace Racquetball_Game_Simulator
{
    public class Racquetball
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly int _numGames;
        
        public Racquetball(string player1Name, string player2Name,
            double player1Prob, double player2Prob, int numGames)
        {
            _player1 = new Player(player1Name, player1Prob);
            _player2 = new Player(player2Name, player2Prob);
            _numGames = numGames;
        }

        public void SimulateGames(bool watchGame=false)
        {
            for (var i = 0; i < _numGames; i++)
            {
                // new game
                var game = new Game(_player1.GetProb(), _player2.GetProb());
                game.Play(watchGame, _player1.GetName(), _player2.GetName());
                
                // add win to players counts
                var winner = game.GetWinner();
                var shutout = game.GetShutout();
                
                if (winner == 0 && !shutout) _player1.AddWin();
                if (winner == 0 && shutout) _player1.AddShutout();
                if (winner == 1 && !shutout) _player2.AddWin();
                if (winner == 1 && shutout) _player2.AddShutout();
            }
        }

        public void PrintStats()
        {
            var p1WinningPercent = Math.Round((float) _player1.GetWins() / _numGames, 4, MidpointRounding.ToEven);
            var p2WinningPercent = Math.Round((float) _player2.GetWins() / _numGames, 4, MidpointRounding.ToEven);

            var stats = $"\nNumber of Games Simulated: {_numGames}\n  Player 1 Stats:\n    " +
                        $"Name: {_player1.GetName()}\n    Wins: {_player1.GetWins()}" +
                        $"\n    Winning Percentage: {p1WinningPercent}\n    " +
                        $"Shutouts: {_player1.GetShutouts()}\n\n  Player 2 Stats:" +
                        $"\n    Name: {_player2.GetName()}\n    " +
                        $"Wins: {_player2.GetWins()}\n    Winning Percentage: {p2WinningPercent}" +
                        $"\n    Shutouts: {_player2.GetShutouts()}";
            
            Console.Out.WriteLine(stats);
        }
    }
}