using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GuessBasket.Entities;
using GuessBasket.Helper;

namespace GuessBasket.Core
{
     public abstract class Player
    {
        public string Name { get; set; }

        protected Game game;

        protected Player(Game game, string name)
        {
            this.game = game;
            this.Name = name;
        }

        public void Play(CancellationToken cancelToken)
        {
            var isGuessed = false;
            while (!isGuessed)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    return;
                }

                var number = GenerateNumber();
                Console.WriteLine(string.Format("{0} - {1}", this.Name, number));
                isGuessed = this.game.MakeAttempt(number, this);

                if (isGuessed)
                {
                    return;
                }

                var delay = Math.Abs(this.game.MaxAttempts - number) * 10;
                Thread.Sleep(delay);
            }
        }

        protected abstract int GenerateNumber();
    }
}
