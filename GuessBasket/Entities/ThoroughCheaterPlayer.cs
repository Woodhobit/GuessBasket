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

        public ThoroughCheaterPlayer(int minWeight) : base()
        {
            this.currentNumber = minWeight;
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
