using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GuessBasket.Core;
using GuessBasket.Helper;

namespace GuessBasket.Entities
{
    public class MemoryPlayer : Player
    {
        private List<int> previousAttempts;

        public MemoryPlayer(Game game, string name): base(game, name)
        {
            this.previousAttempts = new List<int>();
        }

        protected override int GenerateNumber()
        {
            var number = StaticRandom.Rand(this.game.MinWeight, this.game.MaxWeight);
            while (this.previousAttempts.Contains(number))
            {
                number = StaticRandom.Rand(this.game.MinWeight, this.game.MaxWeight);
            }

            this.previousAttempts.Add(number);
            return number;
        }
    }
}
