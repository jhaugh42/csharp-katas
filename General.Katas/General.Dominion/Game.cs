using System.Collections.Generic;
using System.Linq;
using General.Dominion.Cards.Victory;
using General.Dominion.Interface;

namespace General.Dominion
{
    public class Game
    {
        private List<Player> _players = new List<Player>();
        private Player _currentPlayer;
        private Dictionary<string, Stack<ICard>> _supply = new Dictionary<string, Stack<ICard>>();
        private List<ICard> _trash = new List<ICard>();

        public List<Player> Players
        {
            get { return _players; }
            set { _players = value; }
        }

        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set { _currentPlayer = value; }
        }

        public Dictionary<string, Stack<ICard>> Supply
        {
            get { return _supply; }
            set { _supply = value; }
        }

        public List<ICard> Trash
        {
            get { return _trash; }
            set { _trash = value; }
        }

        public Game(int numPlayers)
        {
            Players = new List<Player>(numPlayers);
            Supply = new Dictionary<string, Stack<ICard>>();
            Trash = new List<ICard>();
        }

        public bool IsReady()
        {
            return _players.Count > 1 && _players.All(p => p.IsReady);
        }


    }
}
