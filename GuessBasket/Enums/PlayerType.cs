using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessBasket.Enums
{
    public enum PlayerType : byte
    {
        RandomPlayer = 1,
        MemoryPlayer,
        ThoroughPlayer,
        CheaterPlayer,
        ThoroughCheaterPlayer
    }
}
