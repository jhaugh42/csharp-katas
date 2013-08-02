using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Dominion.Interface;

namespace General.Dominion.Cards.Victory
{
    public class Province : IVictoryCard
    {
        public string Name { get { return "Province"; } }
        public int Cost { get { return 8; } }

        public int GetVictoryPoints()
        {
            return 6;
        }
    }
}
