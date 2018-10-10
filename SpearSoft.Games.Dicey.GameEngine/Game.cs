using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Game
    {
        public event EventHandler<NextPlayerEventArgs> NextPlayer;
        public event EventHandler<NextRoundEventArgs> IncrementRound;

        protected virtual void OnNextPlayer(NextPlayerEventArgs e)
        {
            NextPlayer?.Invoke(this, e);
        }

        protected virtual void OnIncrementRound(NextRoundEventArgs e)
        {
            IncrementRound?.Invoke(this, e);
        }

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

        public bool IncrementCurrentRound()
        {
            if (Players.All(p=>p.CanIncrementRound()))
            {
                CurrentRound++;
                Players.ForEach(p=>p.Round=CurrentRound);
                OnIncrementRound(new NextRoundEventArgs(CurrentRound));
                GetNextPlayer();
                return true;
            }
            return false;
        }
        public bool GetNextPlayer()
        {
            if (CurrentPlayer.CanIncrementRound())
            {
                var nextPlayer = Players.FirstOrDefault(p => p.Order == CurrentPlayer.Order + 1) ?? Players.First(p => p.Order == 1);
                CurrentPlayer = nextPlayer;
                OnNextPlayer(new NextPlayerEventArgs(CurrentPlayer));
                return true;
            }
            return false;
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
            return this.Players.All(p => p.GameCard.Hands.All(h => h.IsApplied));
        }

        public List<Player> Players { get; set; }
    }

    public class NextPlayerEventArgs:EventArgs
    {
        public NextPlayerEventArgs(Player player)
        {
            Player = player;
        }
        public Player Player { get; }
    }

    public class NextRoundEventArgs : EventArgs
    {
        public NextRoundEventArgs(byte newRound)
        {
            NewRound = newRound;
        }
        public byte NewRound { get; set; }
    }
}