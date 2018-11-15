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
        private readonly List<Func<IEnumerable<IDie>, bool>> _rules;
        private readonly Func<IEnumerable<IDie>, int> _scoreFormula;


        /// <summary>
        /// You will also pass in at least one rule in the list of rules and a scoreFormula
        /// But not every calculation needs to know a valueToCheck (full house) or has a minimum count.
        /// Note - this class uses an array of bytes to do the calculations rather than the Dice instance
        /// to make it more testable.
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="scoreFormula"></param>
        /// <param name="name"></param>
        /// <param name="scoreDescription"></param>
        public DiceCalculator(List<Func<IEnumerable<IDie>, bool>> rules, Func<IEnumerable<IDie>, int> scoreFormula, string name, string scoreDescription)
        {
            _rules = rules;
            _scoreFormula = scoreFormula;
            Name = name;
            ScoreDescription = scoreDescription;
        }

        public string Name { get; }
        public string ScoreDescription { get; }

        public DiceCalculationResult Calculate(IDiceSet dice)
        {
            var isValid = true;
            int score = _scoreFormula.Invoke(dice);

            foreach (var r in _rules)
            {
                if (r.Invoke(dice) == false)
                {
                    isValid = false;
                    break;
                }
            }

            return new DiceCalculationResult(isValid,score);

        }
    }
}