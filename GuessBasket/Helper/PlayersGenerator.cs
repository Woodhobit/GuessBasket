using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GuessBasket.Core;
using GuessBasket.Entities;
using GuessBasket.Enums;

namespace GuessBasket.Helper
{
    public static  class PlayersGenerator
    {
        private static List<Player> players;

        private static readonly Dictionary<PlayerType, Func<Player>> playersTypeCollection;

        static PlayersGenerator()
        {
            playersTypeCollection = new Dictionary<PlayerType, Func<Player>>
            {
                [PlayerType.RandomPlayer] = () => new RandomPlayer(),
                [PlayerType.MemoryPlayer] = () => new MemoryPlayer(),
                [PlayerType.ThoroughPlayer] = () => new ThoroughPlayer(Configuration.MinWeight),
                [PlayerType.CheaterPlayer] = () => new CheaterPlayer(),
                [PlayerType.ThoroughCheaterPlayer] = () => new ThoroughCheaterPlayer(Configuration.MinWeight),
            };

            players = new List<Player>();
        }

        public static IEnumerable<Player> GeneratePlayers()
        {
            byte playersCount = ReadPlayersCount();

            for (byte i = 0; i < playersCount; i++)
            {
                var player = ReadPlayerType(i);
                player.Name = ReadPlayerName(i);

                players.Add(player);
            }

            return players;
        }

        private static byte ReadPlayersCount()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of players (The amount of participating players – 2 through 8)");

            byte playersCount = Convert.ToByte(Console.ReadLine());

            if (playersCount < Configuration.MinAmountOfPlayers || playersCount > Configuration.MaxAmountOfPlayers)
            {
                ReadPlayersCount();
            }

            return playersCount;
        }

        private static Player ReadPlayerType(byte position)
        {
            Console.Clear();
            ShowPlayersType();
            Console.WriteLine($"Enter the type of the {position+1}-th player");

            byte playerType = Convert.ToByte(Console.ReadLine());
            var player = GetPlayer(playerType);

            if (player == null)
            {
                ReadPlayerType(position);
            }

            return player;
        }


        private static void ShowPlayersType()
        {
            Console.WriteLine($"{(byte)PlayerType.RandomPlayer} - {PlayerType.RandomPlayer.ToString()}");
            Console.WriteLine($"{(byte)PlayerType.MemoryPlayer} - {PlayerType.MemoryPlayer.ToString()}");
            Console.WriteLine($"{(byte)PlayerType.ThoroughPlayer} - {PlayerType.ThoroughPlayer.ToString()}");
            Console.WriteLine($"{(byte)PlayerType.CheaterPlayer} - {PlayerType.CheaterPlayer.ToString()}");
            Console.WriteLine($"{(byte)PlayerType.ThoroughCheaterPlayer} - {PlayerType.ThoroughCheaterPlayer.ToString()}");
        }


        private static string ReadPlayerName(byte position)
        {
            Console.Clear();
            Console.WriteLine($"Enter the name of the {position+1}-th player");

            var name = Console.ReadLine();
            Regex regex = new Regex(@"^[a-zA-Z0-9]{3,30}$", RegexOptions.Compiled);

            if (!regex.IsMatch(name))
            {
                ReadPlayerName(position);
            }

            return name;
        }

        private static Player GetPlayer(byte playerType)
        {
            var isDefined = Enum.IsDefined(typeof(PlayerType), playerType);

            if (!isDefined)
            {
                return null;
            }

            return (Player)playersTypeCollection[(PlayerType) playerType].DynamicInvoke();
        }

    }
}
