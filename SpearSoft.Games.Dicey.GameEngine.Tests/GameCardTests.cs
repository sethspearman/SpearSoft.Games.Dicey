using System.Linq;
using NUnit.Framework;

namespace SpearSoft.Games.Dicey.GameEngine.Tests
{
    public class GameCardTests
    {
        [TestCase(new byte[] { 6, 6, 6, 0, 0 })]
        public void UpperBonus_if_score_63orGreater_returns35(byte[] bytes)
        {
            //arrange
            var game = new Game();

            var player1 = game.CurrentPlayer;

            //var gameCard = GetGameCard();
            SetupUpperHand(player1, new MockDiceSet(bytes));

            //act
            var upperBonus = player1.GameCard.UpperBonus;

            //assert
            Assert.IsTrue(upperBonus == 35);

        }

        [TestCase(new byte[] { 6, 6, 5, 0, 0 })]
        public void UpperBonus_if_score_62orLess_returns0(byte[] bytes)
        {
            //arrange
            var game = new Game();

            var player1 = game.CurrentPlayer;

            //var gameCard = GetGameCard();

            SetupUpperHand(player1, new MockDiceSet(bytes));

            //act
            var upperBonus = player1.GameCard.UpperBonus;

            //assert
            Assert.IsTrue(upperBonus == 0);

        }

        [Test]
        public void GrandTotal_upperScore_lowerScore_plusBonuses()
        {
            //arrange
            var game = new Game();
            var player1 = game.CurrentPlayer;

            SetupUpperHand(player1, new MockDiceSet(6,6,6,0,0));

            SetupLowerHand(player1);

            //act 
            //var grandTotal = player1.GameCard.UpperBonus + player1.GameCard.UpperScore + player1.GameCard.LowerScore;
            player1.GameCard.BonusYahtzeeCount++;
            var grandTotal = player1.GameCard.Score;

            //assert
            Assert.IsTrue(grandTotal == 35 + 63 + 25 + 50 + 17 + 100);

        }

        private static void SetupLowerHand(Player player1)
        {
            var hand = player1.GameCard.Hands?.SingleOrDefault(h => h.Name == GameCard.FullHouse);
            hand.SetDice(new MockDiceSet(1, 1, 1, 2, 2)); // 25
            player1.GameCard.ApplyHand(hand);

            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.ThreeOfAKind);
            hand.SetDice(new MockDiceSet(5,5,5,1,1)); // 17 
            player1.GameCard.ApplyHand(hand);

            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Yahtzee);
            hand.SetDice(new MockDiceSet(5,5,5,5,5)); // 50
            player1.GameCard.ApplyHand(hand);
        }

        private static void SetupUpperHand(Player player1, IDiceSet sixes)
        {
            
            var hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Aces);
            hand.SetDice(new MockDiceSet(1,1,1,0,0));
            player1.GameCard.ApplyHand(hand);

            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Twos);
            hand.SetDice(new MockDiceSet(2,2,2,0,0));
            player1.GameCard.ApplyHand(hand);

            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Threes);
            hand.SetDice(new MockDiceSet(3,3,3,0,0));
            player1.GameCard.ApplyHand(hand);

            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Fours);
            hand.SetDice(new MockDiceSet(4,4,4,0,0));
            player1.GameCard.ApplyHand(hand);

            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Fives);
            hand.SetDice(new MockDiceSet(5,5,5,0,0));
            player1.GameCard.ApplyHand(hand);

            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Sixes);
            hand.SetDice(sixes);
            player1.GameCard.ApplyHand(hand);
        }
    }
}
