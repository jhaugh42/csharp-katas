using System.Collections.Generic;

namespace General.Dominion
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public Player CurrentPlayer { get; set; }

        public Dictionary<string, Stack<Card>> Supply { get; set; }
        public List<Card> Trash { get; set; }
           
    
    
    
    
    }
}
