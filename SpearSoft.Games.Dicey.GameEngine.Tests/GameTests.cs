using System;
using System.Xml.Serialization;
using NUnit.Framework;

namespace SpearSoft.Games.Dicey.GameEngine.Tests
{
    public class GameTests
    {
        [Test]
        public void GameInit_HasPlayer()
        {

            var game = new Game();

            Assert.IsTrue(game.Players!=null &&  game.Players.Count == 1,
                "Game constructor did not initilize a player.");

        }

        [Test]
        public void GameInit_HasPlayer_NamedDEFAULT()
        {

            var game = new Game();

            Assert.IsTrue(game.Players != null && game.Players[0].PlayerName == "DEFAULT",
                "either there are no players or player is not named default");

        }

        [Test]
        public void GameInit_HasPlayer_GuidIDNotEmpty()
        {

            var game = new Game();

            Assert.IsTrue(game.Players != null && game.Players[0].Id != Guid.Empty,
                "either there are no players or player is not named default");

        }

        [Test]
        public void GameInit_Player_HasGameCard()
        {

            var game = new Game();
            var player = game.Players[0];

            Assert.IsTrue(player.GameCard!=null);
        }

        [Test]
        public void GameInit_Player_HasGameCardWithHands()
        {

            var game = new Game();
            var player = game.Players[0];

            Assert.IsTrue(player.GameCard != null && player.GameCard.Hands.Count == 14);
        }

    }
}