using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Dominion.Interface;

namespace General.Dominion.Cards.Treasure
{
    public class Gold : ITreasureCard
    {
        public string Name { get { return "Gold"; } }
        public int Cost { get { return 6; } }

        public int GetTreasureValue()
        {
            return 3;
        }
    }
}
