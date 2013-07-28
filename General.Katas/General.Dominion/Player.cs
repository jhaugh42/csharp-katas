using System.Collections.Generic;

namespace General.Dominion
{
    public class Player
    {
        public string Name { get; set; }

        public Stack<Card> Deck { get; set; }
        public List<Card> DiscardPile { get; set; }
        public List<Card> CardsInPlay { get; set; }
        public List<Card> Hand { get; set; } 
    }
}
