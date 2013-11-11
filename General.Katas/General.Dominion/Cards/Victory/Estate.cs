using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Dominion.Interface;

namespace General.Dominion.Cards.Victory
{
    public class Estate : IHasVictoryPoints
    {
        public string Name { get { return "Estate"; } }
        public int Cost { get { return 2; } }

        public int GetVictoryPoints()
        {
            return 1;
        }
    }
}
