using System;
using System.Collections.Generic;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Game
    {
        public Player CurrentPlayer { get; private set; }
        public byte CurrentRound { get; private set; }
        public byte MaxRollsPerRound { get; private set; }

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
            CurrentRound = 1;
            MaxRollsPerRound = 3;
        }

        public bool GameOver()
        {
            throw new NotImplementedException();
        }

        public List<Player> Players { get; set; }
    }
}