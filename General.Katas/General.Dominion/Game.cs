using System.Collections.Generic;
using General.Dominion.Cards.Victory;
using General.Dominion.Interface;

namespace General.Dominion
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public Player CurrentPlayer { get; set; }

        public Dictionary<string, Stack<ICard>> Supply { get; set; }
        public List<ICard> Trash { get; set; }
           
    }
}
