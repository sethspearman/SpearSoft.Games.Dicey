using System.Linq;
using NUnit.Framework;

namespace SpearSoft.Games.Dicey.GameEngine.Tests
{
    public class GameHandTests
    {
        [Test]
        public void GameHand_Scoring_HasTests()
        {
            var gameCard = GetGameCard();

            Assert.IsTrue(gameCard.Hands!=null && gameCard.Hands.Count > 0);

        }

        [TestCase(1, new byte[] { 1, 6, 6, 6, 6 }, 1)]
        [TestCase(1, new byte[] { 1, 1, 6, 6, 6 }, 2)]
        [TestCase(1, new byte[] { 1, 1, 1, 6, 6 }, 3)]
        [TestCase(1, new byte[] { 1, 1, 1, 1, 6 }, 4)]
        [TestCase(1, new byte[] { 1, 1, 1, 1, 1 }, 5)]
        public void GameHand_Scoring_Aces_GetProperScore(byte valueToCheck, byte[] bytes, int expected)
        {
            var gameCard = GetGameCard();

            var hand = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Aces);

            hand.SetDice(bytes);

            Assert.IsTrue(hand.Score==expected);
        }


        private static GameCard GetGameCard()
        {
            var game = new Game();
            var player = game.Players[0];
            var gameCard = player.GameCard;

            return gameCard;

        } 
    }
}