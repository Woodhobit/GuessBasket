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

        public MemoryPlayer(): base()
        {
            this.previousAttempts= new List<int>();
        }

        protected override int GenerateNumber()
        {
            var range = Enumerable.Range(this.game.MinWeight, this.game.MaxWeight).Where(i => !this.previousAttempts.Contains(i));
            int index = StaticRandom.Rand(this.game.MinWeight, this.game.MaxWeight - this.previousAttempts.Count);
            var number = range.ElementAt(index);
            this.previousAttempts.Add(number);
            return number;
        }
    }
}
