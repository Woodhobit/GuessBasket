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
            var players = PlayersGenerator.GeneratePlayers();
            foreach (var player in players)
            {
                game.AddPlayer(player);
            }

            game.Start();
        }

    }
}
