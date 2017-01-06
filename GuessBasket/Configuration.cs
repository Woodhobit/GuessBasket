using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessBasket
{
    public static class Configuration
    {
        public static byte MinAmountOfPlayers => 2;

        public static byte MaxAmountOfPlayers => 8;

        public static int MaxWeight => 140;

        public static int MinWeight => 40;

        public static int MaxAttempts => 100;

        public static int TimeForGame => 1500;
    }
}
