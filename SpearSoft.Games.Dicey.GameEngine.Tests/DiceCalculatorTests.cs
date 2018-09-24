using System;
using System.Collections.Generic;
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

            var calculator = new DiceCalculator(rules, scoreFormula, valueToCheck, minimumCount, "Threes",
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

            var calculator = new DiceCalculator(rules, scoreFormula, valueToCheck, 0, "Aces",
                "The sum of the dice with the number 1");

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

            var calculator = new DiceCalculator(rules, scoreFormula, valueToCheck, 0, "Aces",
                "The sum of the dice with the number 1");

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

            var calculator = new DiceCalculator(rules, scoreFormula, valueToCheck, 0, "Aces",
                "The sum of the dice with the number 1");

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

            var calculator = new DiceCalculator(rules, scoreFormula, valueToCheck, 0, "Aces",
                "The sum of the dice with the number 1");

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

            var calculator = new DiceCalculator(rules, scoreFormula, valueToCheck, 0, "Aces",
                "The sum of the dice with the number 1");

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

            var calculator = new DiceCalculator(rules, scoreFormula, valueToCheck, 0, "Aces",
                "The sum of the dice with the number 1");

            //act
            var results = calculator.Calculate(bytes);

            //assert)
            Assert.IsTrue(results.IsValid, "Results should have been valid.");
            Assert.IsTrue(results.Score == expected,
                $"Score was expected to be {expected} but was {results.Score} instead.");
        }

    }
}