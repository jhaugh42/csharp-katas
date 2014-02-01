using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Dominion.Interface;

namespace General.Dominion.Cards.Treasure
{
    public class Silver : IHasTreasureValue
    {
        public string Name { get { return "Silver"; } }
        public int Cost { get { return 3; } }

        public int GetTreasureValue()
        {
            return 2;
        }
    }
}
