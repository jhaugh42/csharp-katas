using System.Collections.Generic;
using General.Dominion.Interface;

namespace General.Dominion
{
    public class Player
    {
        public string Name { get; set; }

        public Stack<ICard> Deck { get; set; }
        public List<ICard> DiscardPile { get; set; }
        public List<ICard> CardsInPlay { get; set; }
        public List<ICard> Hand { get; set; } 
    }
}
