using System.Collections.Generic;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Game
    {
        public Game()
        {
            Players= new List<Player>();
            Players.Add(new Player("DEFAULT"));

            //Players.Add(new Player());
        }

        public Game(List<Player> players)
        {
            Players = players;
        }

        public List<Player> Players { get; set; }
    }
}