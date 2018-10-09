using System;
using System.Collections.Generic;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Hand
    {

        public Hand(string name, string formulaDescription, Func<byte[], int> scoreFormula, List<Func<byte[], bool>> scoreCalculationRules, Section section)
        {
            Name = name;
            FormulaDescription = formulaDescription;
            ScoreFormula = scoreFormula;
            ScoreCalculationRules = scoreCalculationRules;
            Section = section;
        }
        public string Name { get; }
        
        public string FormulaDescription { get; }

        public Func<byte[], int> ScoreFormula { get; }

        public List<Func<byte[], bool>> ScoreCalculationRules { get; }

        public Section Section { get; }

        public bool IsScoreable { get; private set; }

        public bool IsValid { get; private set; } 

        public int Score { private set; get; } 

        public bool IsSelected { get; set; }

        public bool IsApplied { get; set; }

        private byte[] _dice;

        public void SetDice(byte[] dice)
        {
            _dice = dice;

            DiceCalculationResult calcResult = Calculate();
            Score = calcResult.Score;
            IsScoreable = calcResult.Score > 0;
            IsValid = calcResult.IsValid;

        }

        private DiceCalculationResult Calculate()
        {
            var isValid = true;
            int score = ScoreFormula.Invoke(_dice);

            foreach (var r in ScoreCalculationRules)
            {
                if (r.Invoke(_dice) == false)
                {
                    isValid = false;
                    break;
                }
            }

            return new DiceCalculationResult(isValid, score);

        }
    }
}