using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GuessBasket.Core;
using GuessBasket.Helper;

namespace GuessBasket.Entities
{
    public class Game
    {
        public bool IsGuessed { get; set; }

        public ConcurrentDictionary<int, Player> PreviousAttempts { get; }

        public int MaxAttempts { get; }

        public int MaxWeight { get; }

        public int MinWeight { get; }

        private int time;

        private int attempts;

        private readonly int magicNumber;

        private readonly object locked;

        private Player winner;

        private CancellationTokenSource cancellationTokenSource;

        private List<Player> players;

        public Game()
        {
            this.MaxWeight = Configuration.MaxWeight;
            this.MinWeight = Configuration.MinWeight;
            this.MaxAttempts = Configuration.MaxAttempts;
            this.time = Configuration.TimeForGame;

            this.magicNumber = StaticRandom.Rand(this.MinWeight, this.MaxWeight);
            this.locked = new object();

            this.PreviousAttempts = new ConcurrentDictionary<int, Player>();
            this.cancellationTokenSource = new CancellationTokenSource();
            this.players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            player.ConnectToGame(this);
            this.players.Add(player);
        }

        public void Start()
        {
            Console.WriteLine($"The real weight of the basket - {this.magicNumber}");

            this.IsGuessed = false;
            var count = this.players.Count;

            Task[] tasks = new Task[count];

            for (int i = 0; i < count; i++)
            {
                int tmpFixedClosure = i;
                tasks[i] = Task.Run(() => players[tmpFixedClosure].Play(this.cancellationTokenSource.Token));
            }

            var result = Task.WaitAny(tasks, this.time);
            this.ShowResult(result);
        }

        public bool MakeAttempt(int number, Player player)
        {
            lock (locked)
            {
                this.attempts++;

                if (this.magicNumber == number)
                {
                    this.IsGuessed = true;
                    this.winner = player;
                    return true;
                }

                if (this.attempts == this.MaxAttempts)
                {
                    this.cancellationTokenSource.Cancel();
                }
            }

            if (!this.PreviousAttempts.ContainsKey(number))
            {
                this.PreviousAttempts.TryAdd(number, player);
            }

            return false;
        }

        private void ShowResult(int result)
        {
            if (result == -1)
            {
                Console.WriteLine("Time out!!");
                this.ShowClosestResult();
            }
            else
            {
                if (this.winner == null)
                {
                    this.ShowClosestResult();
                }
                else
                {
                    Console.WriteLine($"The player {this.winner.Name} is WINNER!!! Total amount of attempts in the game : {this.attempts}");
                }
            }
        }

        private void ShowClosestResult()
        {
            var closest = this.PreviousAttempts.Aggregate((x, y) => Math.Abs(x.Key - this.magicNumber) < Math.Abs(y.Key - this.magicNumber) ? x : y);
            Console.WriteLine("Here are not winner!");
            Console.WriteLine($"Closest player is - {closest.Value.Name}. His guess is - {closest.Key}");
        }
    }
}
