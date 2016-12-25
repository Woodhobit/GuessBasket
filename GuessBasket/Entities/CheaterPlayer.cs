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
    public class CheaterPlayer : Player
    {
        public CheaterPlayer(Game game, string name) : base(game, name)
        {
        }

        protected override int GenerateNumber()
        {
            var number = StaticRandom.Rand(this.game.MinWeight, this.game.MaxWeight);
            while (this.game.PreviousAttempts.ContainsKey(number))
            {
                number = StaticRandom.Rand(this.game.MinWeight, this.game.MaxWeight);
            }

            return number;
        }
    }
}
