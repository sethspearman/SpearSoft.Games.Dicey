using System;
using System.ComponentModel;
using System.Linq;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Player
    {
        public event EventHandler<RollDiceEventArgs> DoRollDice;
        public int Order { get; }
        public byte DiceRollCount { get; private set; }
        public Player(string playerName, int order)
        {
            PlayerName = playerName;
            Id = Guid.NewGuid();
            Order = order;
            GameCard = new GameCard();
            Round = 1;
            DiceRollCount = 0;
        }

        public static void RollDice(Dice dice)
        {
            dice.Roll();
            
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
        public bool CanIncrementRound()
        {
            return GameCard.Hands.Count(h => h.IsApplied) == Round;
        }

        protected virtual void OnDoRollDice(RollDiceEventArgs e)
        {
            DoRollDice?.Invoke(this, e);
        }
    }

    public class RollDiceEventArgs:CancelEventArgs
    {
        public RollDiceEventArgs(byte diceRollCount)
        {
            DiceRollCount = diceRollCount;
        }
        public byte DiceRollCount { get; }
        //RETURNS THE RESULT OF ROLLING 
        public Dice Dice { get; set; }
    }
}