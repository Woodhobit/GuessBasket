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
    public class ThoroughPlayer : Player
    {
        private int currentNumber;

        public ThoroughPlayer(int minWeight) : base()
        {
            this.currentNumber = minWeight;
        }


        protected override int GenerateNumber()
        {
            if (this.currentNumber >= this.game.MinWeight && this.currentNumber <= this.game.MaxWeight)
            {
                return this.currentNumber++;
            }

            return 0;
        }
    }
}
