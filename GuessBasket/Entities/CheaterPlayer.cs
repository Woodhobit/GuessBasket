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
        protected override int GenerateNumber()
        {
            var range = Enumerable.Range(this.game.MinWeight, this.game.MaxWeight).Where(i => !this.game.PreviousAttempts.Keys.Contains(i));
            int index = StaticRandom.Rand(this.game.MinWeight, this.game.MaxWeight - this.game.PreviousAttempts.Keys.Count);
            return range.ElementAt(index);
        }
    }
}
