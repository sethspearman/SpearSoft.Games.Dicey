using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class GameCard
    {
        public const string Aces = "Aces";
        public const string Twos = "Twos";
        public const string Threes = "Threes";
        public const string Fours = "Fours";
        public const string Fives = "Fives";
        public const string Sixes = "Sixes";
        public const string ThreeOfAKind = "Three of a Kind";
        public const string FourOfAKind = "Four of a Kind";
        public const string FullHouse = "Full House";
        public const string SmallStraight = "Small Straight";
        public const string LargeStraight = "Large Straight";
        public const string Yahtzee = "Yahtzee";
        public const string Chance = "Chance";
        public const string YahtzeeBonus = "Yahtzee Bonus";


        public List<Hand> Hands = null;
        
        public int Score
        {
            get
            {
                return Hands.ToList().Where(h => h.IsApplied).Sum(hand => hand.Score);
            }    
        }

        public int PotentialScore
        {
            get { return Score + Hands.FirstOrDefault(h => h.IsSelected)?.Score ?? 0; }
        }

        public int UpperScore
        {
            get
            {
                return Hands.ToList().Where(h => h.IsApplied && h.Section==Section.Upper).Sum(hand => hand.Score);
            }
        }

        public int PotentialUpperScore
        {
            get { return UpperScore + Hands.FirstOrDefault(h => h.IsSelected && h.Section==Section.Upper)?.Score ?? 0; }
        }

        public int LowerScore
        {
            get
            {
                return Hands.ToList().Where(h => h.IsApplied && h.Section == Section.Lower).Sum(hand => hand.Score);
            }
        }

        public int PotentialLowerScore
        {
            get
            {
                return UpperScore + Hands.FirstOrDefault(h => h.IsSelected && h.Section == Section.Lower)?.Score ?? 0;
            }
        }

        public void SelectUnselectHand(Hand hand)
        {
            var selected = !hand.IsSelected;

            ClearSelected();
            hand.IsSelected = selected;
        }

        public void ApplyHand(Hand hand)
        {
            ClearSelected();
            //do stuff to lock in the round and emit a score for this round.
            //assumes that this is only set once for one hand.  no reset needed.
            hand.IsApplied = true;
        }

        public void ClearSelected()
        {
            Hands.Where(h=>h.IsSelected).ToList().ForEach(h => h.IsSelected = false);
        }

        public GameCard()
        {
            InitializeGameCard();
        }

        public Hand GetHandByName(string name)
        {
            return Hands.FirstOrDefault(h => h.Name == name);
        }

        private void InitializeGameCard()
        {
            Hands = new List<Hand>();

            //upper hands initialization
            Hands.Add(InitUpperHand(1, Aces, "The sum of dice with the number 1"));
            Hands.Add(InitUpperHand(2, Twos, "The sum of dice with the number 2"));
            Hands.Add(InitUpperHand(3, Threes, "The sum of dice with the number 3"));
            Hands.Add(InitUpperHand(4, Fours, "The sum of dice with the number 4"));
            Hands.Add(InitUpperHand(5, Fives, "The sum of dice with the number 5"));
            Hands.Add(InitUpperHand(6, Sixes, "The sum of dice with the number 6"));

            //lower hands initialization

            Hands.Add(InitUpperXofAKind(ThreeOfAKind, "Sum of all dice", 3));
            Hands.Add(InitUpperXofAKind(FourOfAKind, "Sum of all dice", 4));

            //full house
            var rules = new List<Func<byte[], bool>>() {DiceValidations.DiceIsFullHouse()};
            var scoreFormula =
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsFullHouse(), 25);
            var hand = new Hand(FullHouse, "25", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);

            //small straight
            rules = new List<Func<byte[], bool>>() {DiceValidations.DiceIsSmallStraight()};
            scoreFormula =
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsSmallStraight(), 30);
            hand = new Hand(SmallStraight, "30", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);

            //large straight
            rules = new List<Func<byte[], bool>>() {DiceValidations.DiceIsLargeStraight()};
            scoreFormula =
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsLargeStraight(), 40);
            hand = new Hand(LargeStraight, "40", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);

            //yahtzee
            rules = new List<Func<byte[], bool>>() {DiceValidations.DiceIsXofAKind(5)};
            scoreFormula =
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsXofAKind(5), 50);
            hand = new Hand(Yahtzee, "50", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);

            //chance
            rules = new List<Func<byte[], bool>>() {DiceValidations.DiceAlwaysValid()};
            scoreFormula =
                DiceScoringFormulas.DiceSumAll();
            hand = new Hand(Chance, "Sum of all dice", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);

            //yahtzee bonus
            rules = new List<Func<byte[], bool>>() {DiceValidations.DiceIsXofAKind(5)};
            scoreFormula =
                DiceScoringFormulas.DiceBonusYahtzeeIfValid(DiceValidations.DiceIsXofAKind(5));
            hand = new Hand(YahtzeeBonus, "100", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);
        }

        private static Hand InitUpperXofAKind(string name, string formulaDescription, byte XofAKind)
        {
            var rules = new List<Func<byte[], bool>>() {DiceValidations.DiceIsXofAKind(XofAKind)};
            var scoreFormula = DiceScoringFormulas.DiceSumAllIfValid(DiceValidations.DiceIsXofAKind(XofAKind));
            var hand = new Hand(name, formulaDescription, scoreFormula, rules, Section.Lower);

            return hand;
        }

        private static Hand InitUpperHand(byte valueToCheck,string name, string formulaDescription)
        {
            var scoreFormula = DiceScoringFormulas.DiceSumOfSpecificNumber(valueToCheck);
            var rules = new List<Func<byte[], bool>>();
            rules.Add(DiceValidations.DiceAlwaysValid());
            var hand = new Hand(name, formulaDescription, scoreFormula, rules, Section.Upper);

            return hand;
        }
    }


}