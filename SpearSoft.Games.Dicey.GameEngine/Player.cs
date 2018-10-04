using System;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Player
    {
        public Player(string playerName)
        {
            PlayerName = playerName;
            Id = Guid.NewGuid();
        }
        public string PlayerName { get; private set; }
        public Guid Id { get; private set; }

        public GameCard GameCard { get; set; } = new GameCard();
    }
}