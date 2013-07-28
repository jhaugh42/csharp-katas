using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Dominion.Interface;

namespace General.Dominion.Cards.Treasure
{
    public class Copper : ITreasureCard
    {
        public string Name { get { return "Copper"; } }
        public int Cost { get { return 0; } }

        public int GetTreasureValue()
        {
            return 1;
        }
    }
}
