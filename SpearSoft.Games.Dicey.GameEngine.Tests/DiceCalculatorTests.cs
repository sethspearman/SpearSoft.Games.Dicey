using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SpearSoft.Games.Dicey.GameEngine.Tests
{
    public class DiceCalculatorTests
    {
        private byte[] GetDiceByteArray(byte byte1, byte byte2, byte byte3, byte byte4, byte byte5)
        {
            var diceBytes = new byte[5] {byte1, byte2, byte3, byte4, byte5};
            return diceBytes;
        }

        [Test]
        public void DiceCalculator_Threes_2ReturnsValidAndScoreOf6()
        {
            //arrange
            var rules = new List<Func<byte[], bool>>();
            Func<byte[], int> scoreFormula;

            byte valueToCheck = 3;
            byte minimumCount = 1;
            scoreFormula = DiceScoringFormulas.DiceSumOfSpecificNumber(valueToCheck);

            rules.Add(DiceValidations.DiceMustHaveCount(5));
            rules.Add(DiceValidations.DiceMustHaveValues1To6());
            rules.Add(DiceValidations.DiceMustContain(valueToCheck));
            rules.Add(DiceValidations.DiceMustHaveCountOfACertainValue(valueToCheck, minimumCount));

            var calculator = new DiceCalculator(rules, scoreFormula, "Threes",
                "The sum of the dice with the number 3");

            //act
            var results = calculator.Calculate(GetDiceByteArray(1, 3, 2, 4, 3));

            //assert)
            Assert.IsTrue(results.IsValid && results.Score == 6);
        }

        [TestCase(1, new byte[] {1, 6, 6, 6, 6}, 1)]
        [TestCase(1, new byte[] {1, 1, 6, 6, 6}, 2)]
        [TestCase(1, new byte[] {1, 1, 1, 6, 6}, 3)]
        [TestCase(1, new byte[] {1, 1, 1, 1, 6}, 4)]
        [TestCase(1, new byte[] {1, 1, 1, 1, 1}, 5)]
        public void DiceCalculator_Aces_ReturnsSumOf1s(byte valueToCheck, byte[] bytes, int expected)
        {
            //arrange
            var rules = new List<Func<byte[], bool>>();
            var scoreFormula = DiceScoringFormulas.DiceSumOfSpecificNumber(valueToCheck);

            rules.Add(DiceValidations.DiceAlwaysValid());

            var calculator = new DiceCalculator(rules, scoreFormula, "Aces", "The sum of the dice with the number 1");

            //act
            var results = calculator.Calculate(bytes);

            //assert)
            Assert.IsTrue(results.IsValid, "Results should have been valid.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(2, new byte[] {2, 6, 6, 6, 6}, 1)]
        [TestCase(2, new byte[] {2, 2, 6, 6, 6}, 2)]
        [TestCase(2, new byte[] {2, 2, 2, 6, 6}, 3)]
        [TestCase(2, new byte[] {2, 2, 2, 2, 6}, 4)]
        [TestCase(2, new byte[] {2, 2, 2, 2, 2}, 5)]
        public void DiceCalculator_Twos_ReturnsSumOf2s(byte valueToCheck, byte[] bytes, int expected)
        {
            //arrange
            expected = expected * valueToCheck;
            var rules = new List<Func<byte[], bool>>();
            var scoreFormula = DiceScoringFormulas.DiceSumOfSpecificNumber(valueToCheck);

            rules.Add(DiceValidations.DiceAlwaysValid());

            var calculator = new DiceCalculator(rules, scoreFormula, "Two", "The sum of the dice with the number 2");

            //act
            var results = calculator.Calculate(bytes);

            //assert)
            Assert.IsTrue(results.IsValid, "Results should have been valid.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(3, new byte[] {3, 6, 6, 6, 6}, 1)]
        [TestCase(3, new byte[] {3, 3, 6, 6, 6}, 2)]
        [TestCase(3, new byte[] {3, 3, 3, 6, 6}, 3)]
        [TestCase(3, new byte[] {3, 3, 3, 3, 6}, 4)]
        [TestCase(3, new byte[] {3, 3, 3, 3, 3}, 5)]
        public void DiceCalculator_Threes_ReturnsSumOf3s(byte valueToCheck, byte[] bytes, int expected)
        {
            //arrange
            expected = expected * valueToCheck;
            var rules = new List<Func<byte[], bool>>();
            var scoreFormula = DiceScoringFormulas.DiceSumOfSpecificNumber(valueToCheck);

            rules.Add(DiceValidations.DiceAlwaysValid());

            var calculator = new DiceCalculator(rules, scoreFormula, "Threes", "The sum of the dice with the number 3");

            //act
            var results = calculator.Calculate(bytes);

            //assert)
            Assert.IsTrue(results.IsValid, "Results should have been valid.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(4, new byte[] {4, 6, 6, 6, 6}, 1)]
        [TestCase(4, new byte[] {4, 4, 6, 6, 6}, 2)]
        [TestCase(4, new byte[] {4, 4, 4, 6, 6}, 3)]
        [TestCase(4, new byte[] {4, 4, 4, 4, 6}, 4)]
        [TestCase(4, new byte[] {4, 4, 4, 4, 4}, 5)]
        public void DiceCalculator_Fours_ReturnsSumOf4s(byte valueToCheck, byte[] bytes, int expected)
        {
            //arrange
            expected = expected * valueToCheck;
            var rules = new List<Func<byte[], bool>>();
            var scoreFormula = DiceScoringFormulas.DiceSumOfSpecificNumber(valueToCheck);

            rules.Add(DiceValidations.DiceAlwaysValid());

            var calculator = new DiceCalculator(rules, scoreFormula, "Fours", "The sum of the dice with the number 4");

            //act
            var results = calculator.Calculate(bytes);

            //assert)
            Assert.IsTrue(results.IsValid, "Results should have been valid.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(5, new byte[] {5, 6, 6, 6, 6}, 1)]
        [TestCase(5, new byte[] {5, 5, 6, 6, 6}, 2)]
        [TestCase(5, new byte[] {5, 5, 5, 6, 6}, 3)]
        [TestCase(5, new byte[] {5, 5, 5, 5, 6}, 4)]
        [TestCase(5, new byte[] {5, 5, 5, 5, 5}, 5)]
        public void DiceCalculator_Fives_ReturnsSumOf5s(byte valueToCheck, byte[] bytes, int expected)
        {
            //arrange
            expected = expected * valueToCheck;
            var rules = new List<Func<byte[], bool>>();
            var scoreFormula = DiceScoringFormulas.DiceSumOfSpecificNumber(valueToCheck);

            rules.Add(DiceValidations.DiceAlwaysValid());

            var calculator = new DiceCalculator(rules, scoreFormula, "Fives", "The sum of the dice with the number 5");

            //act
            var results = calculator.Calculate(bytes);

            //assert)
            Assert.IsTrue(results.IsValid, "Results should have been valid.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(6, new byte[] {6, 1, 1, 1, 1}, 1)]
        [TestCase(6, new byte[] {6, 6, 1, 1, 1}, 2)]
        [TestCase(6, new byte[] {6, 6, 6, 1, 1}, 3)]
        [TestCase(6, new byte[] {6, 6, 6, 6, 1}, 4)]
        [TestCase(6, new byte[] {6, 6, 6, 6, 6}, 5)]
        public void DiceCalculator_Sixes_ReturnsSumOf6s(byte valueToCheck, byte[] bytes, int expected)
        {
            //arrange
            expected = expected * valueToCheck;
            var rules = new List<Func<byte[], bool>>();
            var scoreFormula = DiceScoringFormulas.DiceSumOfSpecificNumber(valueToCheck);

            rules.Add(DiceValidations.DiceAlwaysValid());

            var calculator = new DiceCalculator(rules, scoreFormula, "Sixes", "The sum of the dice with the number 6");

            //act
            var results = calculator.Calculate(bytes);

            //assert)
            Assert.IsTrue(results.IsValid, "Results should have been valid.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(new byte[] { 4, 4, 1, 2, 4 },15, true)]  //valid, add dice
        [TestCase(new byte[] { 4, 4, 1, 2, 1 },0, false)]  //not not three of a kind, score 0
        [TestCase(new byte[] { 4, 4, 4, 2, 4 },18, true)]  //valid, add dice
        public void DiceCalculator_ThreeOfAKind_IfValidReturnsSumOfAllDice(byte[] bytes, int expected, bool isValid)
        {
            List<DiceCalculator> diceCalculators = Setup();

            var calculator = diceCalculators.First(dc => dc.Name == "Three Of A Kind");

            var results = calculator.Calculate(bytes);

            Assert.IsTrue(results.IsValid == isValid, $"Results should have been {isValid} but where {!isValid}.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(new byte[] { 4, 4, 1, 2, 4 }, 0, false)]  //not not four of a kind, score 0
        [TestCase(new byte[] { 4, 4, 1, 2, 1 }, 0, false)]  //not not four of a kind, score 0
        [TestCase(new byte[] { 4, 4, 4, 2, 4 }, 18, true)]  //valid, add dice
        public void DiceCalculator_FourOfAKind_IfValidReturnsSumOfAllDice(byte[] bytes, int expected, bool isValid)
        {
            List<DiceCalculator> diceCalculators = Setup();

            var calculator = diceCalculators.First(dc => dc.Name == "Four Of A Kind");

            var results = calculator.Calculate(bytes);

            Assert.IsTrue(results.IsValid == isValid, $"Results should have been {isValid} but where {!isValid}.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(new byte[] { 4, 4, 1, 2, 4 }, 0, false)]  //not full house, score 0
        [TestCase(new byte[] { 4, 4, 1, 4, 1 }, 25, true)]  //full house, score 25
        [TestCase(new byte[] { 4, 4, 4, 2, 4 }, 0, false)]  //not full house, score 0
        public void DiceCalculator_FullHouse_IfValidReturns25(byte[] bytes, int expected, bool isValid)
        {
            List<DiceCalculator> diceCalculators = Setup();

            var calculator = diceCalculators.First(dc => dc.Name == "Full House");

            var results = calculator.Calculate(bytes);

            Assert.IsTrue(results.IsValid == isValid, $"Results should have been {isValid} but where {!isValid}.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(new byte[] { 1, 2, 3, 4, 5 }, 30, true)]  //a large straight is also a small straight
        [TestCase(new byte[] { 1, 2, 3, 4, 5 }, 30, true)]  //a large straight is also a small straight but should still show score 30
        [TestCase(new byte[] { 5, 2, 4, 3, 5 }, 30, true)]  //order doesn't matter, score 30
        [TestCase(new byte[] { 1, 2, 3, 1, 2 }, 0, false)]  //not a straight, score 0
        [TestCase(new byte[] { 4, 4, 4, 2, 4 }, 0, false)]  //valid, add dice
        public void DiceCalculator_SmallStraight_IfValidReturns30(byte[] bytes, int expected, bool isValid)
        {
            List<DiceCalculator> diceCalculators = Setup();

            var calculator = diceCalculators.First(dc => dc.Name == "Small Straight");

            var results = calculator.Calculate(bytes);

            Assert.IsTrue(results.IsValid == isValid, $"Results should have been {isValid} but where {!isValid}.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(new byte[] { 1, 2, 3, 4, 4 }, 0, false)]  //a small straight is not a large straight
        [TestCase(new byte[] { 1, 2, 3, 4, 5 }, 40, true)]  //a large straight score 40
        [TestCase(new byte[] { 5, 2, 4, 3, 1 }, 40, true)]  //order doesn't matter, score 40
        [TestCase(new byte[] { 1, 2, 3, 1, 2 }, 0, false)]  //not a straight, score 0
        [TestCase(new byte[] { 4, 4, 4, 2, 4 }, 0, false)]  //valid, add dice
        public void DiceCalculator_LargeStraight_IfValidReturns40(byte[] bytes, int expected, bool isValid)
        {
            List<DiceCalculator> diceCalculators = Setup();

            var calculator = diceCalculators.First(dc => dc.Name == "Large Straight");

            var results = calculator.Calculate(bytes);

            Assert.IsTrue(results.IsValid == isValid, $"Results should have been {isValid} but where {!isValid}.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(new byte[] { 4, 4, 4, 4, 4 }, 50, true)]  //a small straight is not a large straight
        [TestCase(new byte[] { 1, 2, 3, 4, 5 }, 0, false)]  //a straight is not a yahtzee score 0
        [TestCase(new byte[] { 4, 4, 4, 2, 4 }, 0, false)]  //almost but no banana , score 0
        public void DiceCalculator_Yahtzee_IfValidReturns50(byte[] bytes, int expected, bool isValid)
        {
            List<DiceCalculator> diceCalculators = Setup();

            var calculator = diceCalculators.First(dc => dc.Name == "Yahtzee");

            var results = calculator.Calculate(bytes);

            Assert.IsTrue(results.IsValid == isValid, $"Results should have been {isValid} but where {!isValid}.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        [TestCase(new byte[] { 4, 4, 4, 4, 4 }, 100, true)]  //a small straight is not a large straight
        [TestCase(new byte[] { 1, 2, 3, 4, 5 }, 0, false)]  //a straight is not a yahtzee score 0
        [TestCase(new byte[] { 4, 4, 4, 2, 4 }, 0, false)]  //almost but no banana , score 0
        public void DiceCalculator_YahtzeeBonus_IfValidReturns100(byte[] bytes, int expected, bool isValid)
        {
            List<DiceCalculator> diceCalculators = Setup();

            var calculator = diceCalculators.First(dc => dc.Name == "Yahtzee Bonus");

            var results = calculator.Calculate(bytes);

            Assert.IsTrue(results.IsValid == isValid, $"Results should have been {isValid} but where {!isValid}.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

        private List<DiceCalculator> Setup()
        {
            var result = new List<DiceCalculator>();

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceAlwaysValid()},
                DiceScoringFormulas.DiceSumOfSpecificNumber(1), 
                "Aces", "The sum of the dice with the number 1"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceAlwaysValid()},
                DiceScoringFormulas.DiceSumOfSpecificNumber(2), 
                "Twos", "The sum of the dice with the number 2"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceAlwaysValid()},
                DiceScoringFormulas.DiceSumOfSpecificNumber(3), 
                "Threes", "The sum of the dice with the number 3"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceAlwaysValid()},
                DiceScoringFormulas.DiceSumOfSpecificNumber(4), 
                "Fours", "The sum of the dice with the number 4"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceAlwaysValid()},
                DiceScoringFormulas.DiceSumOfSpecificNumber(5), 
                "Fives", "The sum of the dice with the number 5"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceAlwaysValid()},
                DiceScoringFormulas.DiceSumOfSpecificNumber(6), 
                "Sixes", "The sum of the dice with the number 6"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceIsXofAKind(3)},
                DiceScoringFormulas.DiceSumAllIfValid(DiceValidations.DiceIsXofAKind(3)), 
                "Three Of A Kind", "Sum of all dice"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceIsXofAKind(4)},
                DiceScoringFormulas.DiceSumAllIfValid(DiceValidations.DiceIsXofAKind(4)), 
                "Four Of A Kind", "Sum of all dice"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceIsFullHouse()},
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsFullHouse(), 25), 
                "Full House", "25"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceIsSmallStraight()},
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsSmallStraight(), 30),
                "Small Straight", "30"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceIsLargeStraight()},
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsLargeStraight(), 40),
                "Large Straight", "40"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceIsXofAKind(5)},
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsXofAKind(5), 50), 
                "Yahtzee", "50"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceAlwaysValid()},
                DiceScoringFormulas.DiceSumAll(), 
                "Chance", "Sum of all dice"));

            result.Add(new DiceCalculator(new List<Func<byte[], bool>>() {DiceValidations.DiceIsXofAKind(5)},
                DiceScoringFormulas.DiceBonusYahtzeeIfValid(DiceValidations.DiceIsXofAKind(5)), 
                "Yahtzee Bonus", "100"));

            return result;
        } 


    }
}