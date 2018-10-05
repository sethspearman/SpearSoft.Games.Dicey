using System.Collections.Generic;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Game
    {
        public Player CurrentPlayer { get; private set; }
        public byte CurrentTurn { get; private set; }

        public Game()
        {
            var players= new List<Player>();
            players.Add(new Player("DEFAULT",1));
            
            Init(players);
        }

        public Game(List<Player> players)
        {
            Init(players);
        }

        private void Init(List<Player> players)
        {
            Players = players;
            CurrentPlayer = players[0];
            CurrentTurn = 1;
        }

        public List<Player> Players { get; set; }
    }
}