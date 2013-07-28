using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Dominion.Interface;

namespace General.Dominion.Methods
{
    public class DeckActions
    {
        public static void Shuffle(List<ICard> deck)
        {
            for (int i = 0; i < deck.Count; ++i)
            {
                int position1 = new Random().Next(deck.Count - 1);
                int position2 = new Random().Next(deck.Count - 1);
                Swap(deck[position1], deck[position2]);
            }
        }

        private static void Swap<T>(T left, T right)
        {
            T temp = right;
            right = left;
            left = temp;
        }

        public static List<T> GetDeckOfCards<T>(int numCardsInDeck) where T : ICard, new()
        {
            List<T> deck = new List<T>(numCardsInDeck);
            for (int i = 0; i <= numCardsInDeck; ++i)
            {
                deck.Add(new T());
            }
            return deck;
        }

    }
}
