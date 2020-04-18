using System;
using System.Linq;
using System.Threading;

namespace Racquetball_Game_Simulator
{
    public class Game
    {
        private readonly double _p1Prob;
        private readonly double _p2Prob;
        private int _p1Score;
        private int _p2Score;
        private bool _shutout;
        private int _winner;

        public Game(double p1Prob, double p2Prob)
        {
            _p1Prob = p1Prob;
            _p2Prob = p2Prob;
        }

        public void Play(bool watchGame, string n1, string n2)
        {
            var rng = new Random();
            var p1Size = (int) (_p1Prob * 100);
            var p2Size = (int) (_p2Prob * 100);
            var p1 = new int[p1Size];
            var p2 = new int[p2Size];
            for (var i = 0; i < p1Size; i++) p1[i] = 0;
            for (var i = 0; i < p2Size; i++) p2[i] = 1;
            var playerProbabilities = p1.Concat(p2).ToArray();
            var firstToServe = rng.Next(2);
            var serving = firstToServe;
            var gameFinished = false;
            var rallyCounter = 0;
            
            // Game loop
            while (!gameFinished)
            {
                rallyCounter += 1;
                var rallyWinner = playerProbabilities[rng.Next(playerProbabilities.Length)];
                var rallyLoser = rallyWinner == 0 ? 1 : 0;

                if (watchGame)
                {
                    var server = serving == 0 ? n1 : n2;
                    var nWon = rallyWinner == 0 ? n1 : n2;
                    var gameStats =
                        $"Rally {rallyCounter} | {n1}'s Score {_p1Score} | {n2}'s Score {_p2Score} | Serving {server} | Rally Winner {nWon}";
                    Console.Out.WriteLine(gameStats);
                    Thread.Sleep(2000);
                }

                if (rallyWinner == serving)
                {
                    if (rallyWinner == 0) { _p1Score += 1; }
                    else { _p2Score += 1; }
                }

                if (rallyLoser == serving) serving = rallyWinner;

                if (_p1Score == 15 || _p2Score == 15)
                {
                    gameFinished = true;
                    _winner = _p1Score == 15 ? 0 : 1;
                }

                if (_p1Score == 7 && _p2Score == 0 || _p2Score == 7 && _p1Score == 0)
                {
                    gameFinished = true;
                    _shutout = true;
                    _winner = _p1Score == 7 ? 0 : 1;
                }
            }
        }

        public bool GetShutout() { return _shutout; }
        public int GetWinner() { return _winner; }
    }
}