using System;
using System.ComponentModel;
using System.Linq;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Player
    {
        private const int MaxRollCount = 3;

        //public event EventHandler<RollDiceEventArgs> DoRollDice;
        public int Order { get; }
        public byte DiceRollCount { get; private set; }
        public bool HandSelected { get; private set; }
        public bool MaxRollCountReached { get; private set; }

        public Player(string playerName, int order)
        {
            PlayerName = playerName;
            Id = Guid.NewGuid();
            Order = order;
            GameCard = new GameCard();
            Round = 1;
            DiceRollCount = 0;

            GameCard.GameCardSelected += GameCard_GameCardSelected            ;
        }

        private void GameCard_GameCardSelected(object sender, GameCardSelectedEventArgs e)
        {
            HandSelected = e.IsSelected;
        }

        public void RollDice(IDiceSet dice)
        {
            dice.Roll();

            DiceRollCount++;

            MaxRollCountReached = DiceRollCount == MaxRollCount;

            //var args = new RollDiceEventArgs(DiceRollCount);
            //OnDoRollDice(args);

            //if (!args.Cancel)
            //{
            //    return args.Dice;
            //}

            //return Dice.Empty;
        }

        public string PlayerName { get; }
        public Guid Id { get; }
        public GameCard GameCard { get; }

        private byte _round;

        public byte Round
        {
            get { return _round; }
            set
            {
                if (CanIncrementRound())
                {
                    _round = value;
                }
            }
        }

        public bool RoundCompleted
        {
            get { return MaxRollCountReached || HandSelected; }
        }
        
        public bool CanIncrementRound()
        {
            return GameCard.Hands.Count(h => h.IsApplied) == Round;
        }

        //protected virtual void OnDoRollDice(RollDiceEventArgs e)
        //{
        //    DoRollDice?.Invoke(this, e);
        //}
    }

    //public class RollDiceEventArgs:CancelEventArgs
    //{
    //    public RollDiceEventArgs(byte diceRollCount)
    //    {
    //        DiceRollCount = diceRollCount;
    //    }
    //    public byte DiceRollCount { get; }
    //    //RETURNS THE RESULT OF ROLLING 
    //    public Dice Dice { get; set; }
    //}
}