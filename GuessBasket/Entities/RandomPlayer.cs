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
    class RandomPlayer : Player
    {
        protected override int GenerateNumber()
        {
            return StaticRandom.Rand(this.game.MinWeight, this.game.MaxWeight);
        }
    }
}
