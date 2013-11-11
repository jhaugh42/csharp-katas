using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Dominion.Interface;

namespace General.Dominion.Cards.Action
{
    class Adventurer : IActionCard
    {
        public void Act(Game game)
        {
            throw new NotImplementedException();
        }

        public int Cost
        {
            get { return 6; }
        }

        public string Name
        {
            get { return "Adventurer"; }
        }

    }
}
