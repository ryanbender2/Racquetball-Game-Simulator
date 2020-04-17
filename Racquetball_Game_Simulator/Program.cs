using System;

namespace Racquetball_Game_Simulator
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var t = new Game(.50, .50);
            t.PlayGame(true, "Ryan", "Preston");
        }
    }
}