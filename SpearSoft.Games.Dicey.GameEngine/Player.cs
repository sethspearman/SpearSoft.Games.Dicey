using System;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Player
    {
        public int Order { get; private set; }
        public Player(string playerName, int order)
        {
            PlayerName = playerName;
            Id = Guid.NewGuid();
            Order = order;
        }
        public string PlayerName { get; private set; }
        public Guid Id { get; private set; }
        public GameCard GameCard { get; set; } = new GameCard();

    }
}