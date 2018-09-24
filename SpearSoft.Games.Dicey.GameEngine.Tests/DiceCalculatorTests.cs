using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SpearSoft.Games.Dicey.GameEngine.Tests
{
    public class DiceCalculatorTests
    {
        [Test]
        public void DiceCalculator_4Threes_ReturnsValidAnd6Score()
        {
            //arrange

            var rules = new List<Func<byte[], bool>>();
            Func<byte[], int> scoreFormula;

            byte valueToCheck = 4;
            byte minimumCount = 3;
            scoreFormula = (dice => dice.Where(d => d == valueToCheck).Sum(d => d));


            rules.Add(dice => dice.Length == 5); //this is more like a unit test. remove when done.
            rules.Add(dice => dice.All(d => d >= 1 && d <= 6)); //this is more like a unit test.  remove when done.
            rules.Add(dice => dice.Any(d => d == valueToCheck));
            rules.Add(dice => dice.Count(d => d == valueToCheck) == minimumCount);

            byte[] diceBytes = new byte[5];
            diceBytes[0] = 1;
            diceBytes[0] = 3;
            diceBytes[0] = 2;
            diceBytes[0] = 4;
            diceBytes[0] = 3;

            var calculator = new DiceCalculator(rules, scoreFormula, 2, 3);
            var results = calculator.Validate()


            //act

            //assert)
        }
    }
}


//public DiceCalculator()
//{
//    _scoreFormula = dice => dice.Where(d => d.Value==_valueToCheck).Sum(d => d.Value) ;
//    _rules.Add(dice => dice.Count == 5);  //this is more like a unit test. remove when done.
//    _rules.Add(dice => dice.All(d => d.Value >= 1 && d.Value <= 6)); //this is more like a unit test.  remove when done.
//    _rules.Add(dice => dice.Any(d => d.Value == _valueToCheck));
//    _rules.Add(dice => dice.Count(d => d.Value==_valueToCheck)==_minimumCount);
//}