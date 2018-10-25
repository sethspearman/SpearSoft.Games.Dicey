using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;
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
            SetupUpperHand(player1, bytes);

            //act
            var upperBonus = player1.GameCard.UpperBonus;

            //assert
            Assert.IsTrue(upperBonus==35);

        }

        [TestCase(new byte[] { 6, 6, 5, 0, 0 })]
        public void UpperBonus_if_score_62orLess_returns0(byte[] bytes)
        {
            //arrange
            var game = new Game();

            var player1 = game.CurrentPlayer;

            //var gameCard = GetGameCard();

            SetupUpperHand(player1, bytes);

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

            var bytes = new byte[] { 6, 6, 6, 0, 0 };
            SetupUpperHand(player1, bytes);

            SetupLowerHand(player1);

            //act 
            //var grandTotal = player1.GameCard.UpperBonus + player1.GameCard.UpperScore + player1.GameCard.LowerScore;
            player1.GameCard.BonusYahtzeeCount++;
            var grandTotal = player1.GameCard.Score;

            //assert
            Assert.IsTrue(grandTotal==35+63+25+50+17+100);
            
        }

        private static void SetupLowerHand(Player player1)
        {
            byte[] bytes;

            bytes = new byte[] {1, 1, 1, 2, 2}; //25
            var hand = player1.GameCard.Hands?.SingleOrDefault(h => h.Name == GameCard.FullHouse);
            hand.SetDice(bytes);
            player1.GameCard.ApplyHand(hand);

            bytes = new byte[] {5, 5, 5, 1, 1}; //17 points
            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.ThreeOfAKind);
            hand.SetDice(bytes);
            player1.GameCard.ApplyHand(hand);

            bytes = new byte[] { 5, 5, 5, 5, 5 }; //50 points
            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Yahtzee);
            hand.SetDice(bytes);
            player1.GameCard.ApplyHand(hand);
        }

        private static void SetupUpperHand(Player player1,byte[] sixBytes)
        {
            var bytes = new byte[] {1, 1, 1, 0, 0};
            var hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Aces);
            hand.SetDice(bytes);
            player1.GameCard.ApplyHand(hand);

            bytes = new byte[] {2, 2, 2, 0, 0};
            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Twos);
            hand.SetDice(bytes);
            player1.GameCard.ApplyHand(hand);

            bytes = new byte[] {3, 3, 3, 0, 0};
            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Threes);
            hand.SetDice(bytes);
            player1.GameCard.ApplyHand(hand);

            bytes = new byte[] {4, 4, 4, 0, 0};
            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Fours);
            hand.SetDice(bytes);
            player1.GameCard.ApplyHand(hand);

            bytes = new byte[] {5, 5, 5, 0, 0};
            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Fives);
            hand.SetDice(bytes);
            player1.GameCard.ApplyHand(hand);
            
            hand = player1.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Sixes);
            hand.SetDice(sixBytes);
            player1.GameCard.ApplyHand(hand);
        }
    }
}
