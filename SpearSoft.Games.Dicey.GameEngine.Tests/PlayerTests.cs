using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using NUnit.Framework;

namespace SpearSoft.Games.Dicey.GameEngine.Tests
{
    public class PlayerTests
    {
        [Test]
        public void Player_UserRolled3Times_RoundCompleted()
        {
            //arrange
            var dice = new Dice();
            var game = new Game();
            var player = game.Players[0];

            //act
            player.RollDice(dice);
            player.RollDice(dice);
            player.RollDice(dice);
            
            //assert
            Assert.IsTrue(player.RoundCompleted);

        }
        [Test]
        public void Player_UserRolledLessThan3Times_RoundNotCompleted()
        {
            //arrange
            var dice = new Dice();
            var game = new Game();
            var player = game.Players[0];

            //act
            player.RollDice(dice);
            player.RollDice(dice);

            //assert
            Assert.IsFalse(player.RoundCompleted);

        }

        [Test]
        public void Player_HasSelectedHand_RoundCompleted()
        {
            //arrange
            var game = new Game();
            var player = game.CurrentPlayer;

            //act
            game.CurrentPlayer.GameCard.SelectUnselectHand(
                game.CurrentPlayer.GameCard.Hands.First(h => h.Name == GameCard.Aces));


            //assert
            Assert.IsTrue(player.RoundCompleted);

        }

        [Test]
        public void Player_HasUnselectedHand_RoundNotCompleted()
        {
            //arrange
            var game = new Game();
            var player = game.CurrentPlayer;

            //act
            game.CurrentPlayer.GameCard.SelectUnselectHand(
                game.CurrentPlayer.GameCard.Hands.First(h => h.Name == GameCard.Aces));

            game.CurrentPlayer.GameCard.SelectUnselectHand(
                game.CurrentPlayer.GameCard.Hands.First(h => h.Name == GameCard.Aces));

            //assert
            Assert.IsFalse(player.RoundCompleted);

        }

        [Test]
        public void Player_SelectsNewHand_RoundCompleted()
        {
            //arrange
            var game = new Game();
            var player = game.CurrentPlayer;

            //act
            game.CurrentPlayer.GameCard.SelectUnselectHand(
                game.CurrentPlayer.GameCard.Hands.First(h => h.Name == GameCard.Aces));

            game.CurrentPlayer.GameCard.SelectUnselectHand(
                game.CurrentPlayer.GameCard.Hands.First(h => h.Name == GameCard.Chance));

            //assert
            Assert.IsTrue(player.RoundCompleted);

        }

        [Test]
        public void Player_NoHandSelectedBut3DiceRolls_RoundCompleted1()
        {
            //arrange
            var dice = new Dice();
            var game = new Game();
            var player = game.CurrentPlayer;

            //act
            player.RollDice(dice);
            player.RollDice(dice);
            player.RollDice(dice);

            game.CurrentPlayer.GameCard.SelectUnselectHand(
                game.CurrentPlayer.GameCard.Hands.First(h => h.Name == GameCard.Aces));

            game.CurrentPlayer.GameCard.SelectUnselectHand(
                game.CurrentPlayer.GameCard.Hands.First(h => h.Name == GameCard.Aces));

            //assert
            Assert.IsTrue(player.RoundCompleted);

        }

        [Test]
        public void Player_NoHandSelectedBut3DiceRolls_RoundCompleted2()
        {
            //arrange
            var dice = new Dice();
            var game = new Game();
            var player = game.CurrentPlayer;

            //act

            game.CurrentPlayer.GameCard.SelectUnselectHand(
                game.CurrentPlayer.GameCard.Hands.First(h => h.Name == GameCard.Aces));

            game.CurrentPlayer.GameCard.SelectUnselectHand(
                game.CurrentPlayer.GameCard.Hands.First(h => h.Name == GameCard.Aces));

            player.RollDice(dice);
            player.RollDice(dice);
            player.RollDice(dice);

            //assert
            Assert.IsTrue(player.RoundCompleted);

        }


    }
}