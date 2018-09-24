using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("SpearSoft.Games.Dicey.GameEngine.Tests")]

namespace SpearSoft.Games.Dicey.GameEngine
{
    /// <summary>
    /// Class for calculating validity and score from Dice passed to Calculate method
    /// For each game, one of these will be created for each possible scoring hand.
    /// </summary>
    internal class DiceCalculator
    {
        private readonly List<Func<byte[], bool>> _rules;
        private readonly Func<byte[], int> _scoreFormula;
        private readonly byte _valueToCheck;
        private readonly byte _minimumCount;

        /// <summary>
        /// You will also pass in at least one rule in the list of rules and a scoreFormula
        /// But not every calculation needs to know a valueToCheck (full house) or has a minimum count.
        /// Note - this class uses an array of bytes to do the calculations rather than the Dice instance
        /// to make it more testable.
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="scoreFormula"></param>
        /// <param name="minimumCount"></param>
        /// <param name="valueToCheck"></param>
        /// <param name="name"></param>
        /// <param name="scoreDescription"></param>
        public DiceCalculator(List<Func<byte[], bool>> rules, Func<byte[], int> scoreFormula, byte minimumCount, byte valueToCheck, string name, string scoreDescription)
        {
            _rules = rules;
            _scoreFormula = scoreFormula;
            _minimumCount = minimumCount;
            _valueToCheck = valueToCheck;
            Name = name;
            ScoreDescription = scoreDescription;
        }

        //public DiceCalculator()
        //{
        //    _scoreFormula = dice => dice.Where(d => d.Value==_valueToCheck).Sum(d => d.Value) ;
        //    _rules.Add(dice => dice.Count == 5);  //this is more like a unit test. remove when done.
        //    _rules.Add(dice => dice.All(d => d.Value >= 1 && d.Value <= 6)); //this is more like a unit test.  remove when done.
        //    _rules.Add(dice => dice.Any(d => d.Value == _valueToCheck));
        //    _rules.Add(dice => dice.Count(d => d.Value==_valueToCheck)==_minimumCount);
        //}

        public string Name { get; }
        public string ScoreDescription { get; }

        public DiceCalculationResult Calculate(byte[] diceValues)
        {
            var isValid = true;
            int score = _scoreFormula.Invoke(diceValues);

            if (_rules.Any( r=> r.Invoke(diceValues) ==false))
            {
                isValid = false;
            }

            //foreach (var rule in _rules)
            //{
            //    if (!rule.Invoke(dice))
            //    {
            //        isValid = false;
            //    } 
            //}

            return new DiceCalculationResult(isValid,score);

        }
    }
}