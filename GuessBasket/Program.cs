using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GuessBasket.Core;
using GuessBasket.Entities;
using GuessBasket.Helper;

namespace GuessBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            var players = GetPlayers(StaticRandom.Rand(2,8), game);
            foreach (var player in players)
            {
                game.AddPlayer(player);
            }

            game.Start();
        }

        private static List<Player> GetPlayers(int count, Game game)
        {
            var players = new List<Player>
            {
                new RandomPlayer(game,"RandomPlayer 1"),
                new MemoryPlayer(game, "MemoryPlayer 1"),
                new ThoroughPlayer(game, "ThoroughPlayer 1"),
                new CheaterPlayer(game,"CheaterPlayer 1"),
                new ThoroughCheaterPlayer(game,"ThoroughCheaterPlayer 1"),
                new RandomPlayer(game,"RandomPlayer 2"),
                new MemoryPlayer(game, "MemoryPlayer 2"),
                new ThoroughPlayer(game, "ThoroughPlayer 2"),
                new CheaterPlayer(game,"CheaterPlayer 2"),
                new ThoroughCheaterPlayer(game,"ThoroughCheaterPlayer 2")
            };

            var random = new Random();
            return players.OrderBy(m => random.Next()).Take(count).ToList();
        }
    }
}
