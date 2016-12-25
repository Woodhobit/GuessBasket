using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GuessBasket.Core;

namespace GuessBasket.Entities
{
    class ThoroughCheaterPlayer : Player
    {
        private int currentNumber;

        public ThoroughCheaterPlayer(Game game, string name) : base(game, name)
        {
            this.currentNumber = this.game.MinWeight;
        }

        protected override int GenerateNumber()
        {
            var number = this.currentNumber;
            while (number >= this.game.MinWeight && number <= this.game.MaxWeight && this.game.PreviousAttempts.ContainsKey(number))
            {
                number++;
            }

            this.currentNumber = number;
            return number;
        }
    }
}
