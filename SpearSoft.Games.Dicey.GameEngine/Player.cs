using System;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Player
    {
        public Player()
        {
            Id = Guid.NewGuid();
        }
        internal string PlayerName { get; set; }
        internal Guid Id { get; set; }

        internal GameCard GameCard { get; set; }
    }
}