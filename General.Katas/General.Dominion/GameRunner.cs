using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Dominion.Cards.Action;
using General.Dominion.Cards.Treasure;
using General.Dominion.Cards.Victory;
using General.Dominion.Interface;
using General.Dominion.Methods;

namespace General.Dominion
{
    public class GameRunner
    {
        private Game _game;

        public GameRunner()
        {
            _game = new Game(2);
        }

        public void Initialize()
        {
            SetupSupply();
            DealInitialHandsToPlayers();

        }

        private void SetupSupply()
        {
            _game.Supply.Add("estate", new Stack<ICard>(DeckActions.GetDeckOfCards<Estate>(30)));
            _game.Supply.Add("dutchy", new Stack<ICard>(DeckActions.GetDeckOfCards<Estate>(12)));
            _game.Supply.Add("province", new Stack<ICard>(DeckActions.GetDeckOfCards<Province>(8)));
            _game.Supply.Add("gold", new Stack<ICard>(DeckActions.GetDeckOfCards<Gold>(20)));
            _game.Supply.Add("silver", new Stack<ICard>(DeckActions.GetDeckOfCards<Silver>(30)));
            _game.Supply.Add("copper", new Stack<ICard>(DeckActions.GetDeckOfCards<Copper>(60)));

            _game.Supply.Add("mine", new Stack<ICard>(DeckActions.GetDeckOfCards<Mine>(10)));
            _game.Supply.Add("militia", new Stack<ICard>(DeckActions.GetDeckOfCards<Militia>(10)));
            _game.Supply.Add("market", new Stack<ICard>(DeckActions.GetDeckOfCards<Market>(10)));
            _game.Supply.Add("woodcutter", new Stack<ICard>(DeckActions.GetDeckOfCards<Woodcutter>(10)));
            _game.Supply.Add("workoshop", new Stack<ICard>(DeckActions.GetDeckOfCards<Workshop>(10)));
            _game.Supply.Add("smithy", new Stack<ICard>(DeckActions.GetDeckOfCards<Smithy>(10)));
            _game.Supply.Add("village", new Stack<ICard>(DeckActions.GetDeckOfCards<Village>(10)));
            _game.Supply.Add("library", new Stack<ICard>(DeckActions.GetDeckOfCards<Library>(10)));
            _game.Supply.Add("moat", new Stack<ICard>(DeckActions.GetDeckOfCards<Moat>(10)));
            _game.Supply.Add("adventurer", new Stack<ICard>(DeckActions.GetDeckOfCards<Adventurer>(10)));
        }

        private void DealInitialHandsToPlayers()
        {
            List<ICard> tempDeck = new List<ICard>();
            foreach (Player player in _game.Players)
            {
                for (int numCopper = 0; numCopper <= 7; ++numCopper)
                    tempDeck.Add(_game.Supply["copper"].Pop());

                for (int numCopper = 0; numCopper <= 3; ++numCopper)
                    tempDeck.Add(_game.Supply["estate"].Pop());

                DeckActions.Shuffle(tempDeck);

                foreach (ICard card in tempDeck)
                {
                    player.Deck.Enqueue(card);
                }
            }
        }
        
    }
}
