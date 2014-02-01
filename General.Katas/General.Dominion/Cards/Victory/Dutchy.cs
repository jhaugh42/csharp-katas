using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Dominion.Interface;

namespace General.Dominion.Cards.Victory
{
    public class Dutchy : IHasVictoryPoints
    {
        public string Name { get { return "Dutchy"; } }
        public int Cost { get { return 5; } }
        
        public int GetVictoryPoints()
        {
            return 3;
        }
    }
}
