namespace SpearSoft.Games.Dicey.GameEngine
{
    //public interface IDiceValidator
    //{
    //    //Dice dice;
    //    //List<IRule> Rules { get; }

    //    //returns isvalid and score from hand
    //    (bool, int) Validate();
    //}

    public struct DiceCalculationResult
    {
        public DiceCalculationResult(bool isValid, int score)
        {
            IsValid = isValid;
            Score = score;
        }
        public bool IsValid { get; private set; }
        public int Score { get; private set; }
    }
}