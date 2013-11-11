using System.Collections.Generic;
using System.Linq;
using General.Dominion.Interface;
using General.Dominion.Methods;

namespace General.Dominion
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Deck = new Queue<ICard>();
            DiscardPile = new List<ICard>();
            CardsInPlay = new List<ICard>();
            Hand = new List<ICard>();
        }


        public string Name { get; private set; }

        public Queue<ICard> Deck { get; set; }
        public List<ICard> DiscardPile { get; set; }
        public List<ICard> CardsInPlay { get; set; }
        public List<ICard> Hand { get; set; }

        public int NumActions { get; set; }
        public int NumBuys { get; set; }
        public int NumTreasure { get; private set; }
        
        public void SetupNextHand()
        {
            MoveAllCards(fromPile: CardsInPlay, toPile: DiscardPile);
            MoveAllCards(fromPile: Hand, toPile:DiscardPile);
            DealFromDeckToHand(5);
            NumActions = 1;
            NumBuys = 1;
            NumTreasure = CountTeasureInHand();
        }

        private void ShuffleDiscardAndReturnToDeck()
        {
            DeckActions.Shuffle(DiscardPile);
            foreach (ICard card in DiscardPile)
            {
                Deck.Enqueue(card);
            }
            DiscardPile.Clear();
        }

        private void MoveAllCards(List<ICard> fromPile, List<ICard> toPile)
        {
            toPile.AddRange(fromPile);
            fromPile.Clear();
        }

        private void DealFromDeckToHand(int numCardsToDeal)
        {
            if (Deck.Count < numCardsToDeal)
            {
                ShuffleDiscardAndReturnToDeck();
            }
            int cardsDelt = 0;
            while (Deck.Any() && cardsDelt < numCardsToDeal)
            {
                Hand.Add(Deck.Dequeue());
                ++cardsDelt;
            }

        }

        private int CountTeasureInHand()
        {
            return Hand.Where(crd => crd is IHasTreasureValue)
                .Sum(crd => ((IHasTreasureValue) crd).GetTreasureValue());
        }


    }
}
