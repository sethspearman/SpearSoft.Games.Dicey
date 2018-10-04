using System;
using System.Collections.Generic;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class GameCard
    {

        public GameCard()
        {
            Hands = new List<Hand>();

            //upper hands initialization
            Hands.Add(InitUpperHand(1,"Aces","The sum of dice with the number 1"));
            Hands.Add(InitUpperHand(2,"Twos","The sum of dice with the number 2"));
            Hands.Add(InitUpperHand(3,"Threes","The sum of dice with the number 3"));
            Hands.Add(InitUpperHand(4,"Fours","The sum of dice with the number 4"));
            Hands.Add(InitUpperHand(5,"Fives","The sum of dice with the number 5"));
            Hands.Add(InitUpperHand(6,"Sixes","The sum of dice with the number 6"));

            //lower hands initialization

            Hands.Add(InitUpperXofAKind("Three of a Kind","Sum of all dice",3));
            Hands.Add(InitUpperXofAKind("Four of a Kind", "Sum of all dice", 4));

            //full house
            var rules = new List<Func<byte[], bool>>() { DiceValidations.DiceIsFullHouse() };
            var scoreFormula =
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsFullHouse(), 25);
            var hand = new Hand("Full House","25",scoreFormula,rules,Section.Lower);
            Hands.Add(hand);

            //small straight
            rules = new List<Func<byte[], bool>>() { DiceValidations.DiceIsSmallStraight() };
            scoreFormula =
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsSmallStraight(), 30);
            hand = new Hand("Small Straight", "30", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);

            //large straight
            rules = new List<Func<byte[], bool>>() { DiceValidations.DiceIsLargeStraight() };
            scoreFormula =
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsLargeStraight(), 40);
            hand = new Hand("Large Straight", "40", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);

            //yahtzee
            rules = new List<Func<byte[], bool>>() {DiceValidations.DiceIsXofAKind(5)};
            scoreFormula =
                DiceScoringFormulas.DiceReturnSpecificValueIfValid(DiceValidations.DiceIsXofAKind(5), 50);
            hand = new Hand("Yahtzee", "50", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);

            //chance
            rules = new List<Func<byte[], bool>>() { DiceValidations.DiceAlwaysValid() };
            scoreFormula =
                DiceScoringFormulas.DiceSumAll();
            hand = new Hand("Chance", "Sum of all dice", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);

            //yahtzee bonus
            rules = new List<Func<byte[], bool>>() { DiceValidations.DiceIsXofAKind(5) };
            scoreFormula =
                DiceScoringFormulas.DiceBonusYahtzeeIfValid(DiceValidations.DiceIsXofAKind(5));
            hand = new Hand("Yahtzee Bonus", "100", scoreFormula, rules, Section.Lower);
            Hands.Add(hand);

        }

        private static Hand InitUpperXofAKind(string name, string formulaDescription, byte XofAKind)
        {
            var rules = new List<Func<byte[], bool>>() {DiceValidations.DiceIsXofAKind(XofAKind)};
            var scoreFormula = DiceScoringFormulas.DiceSumAllIfValid(DiceValidations.DiceIsXofAKind(XofAKind));
            var hand = new Hand(name, formulaDescription, scoreFormula, rules, Section.Lower);

            return hand;
        }

        private Hand InitUpperHand(byte valueToCheck,string name, string formulaDescription)
        {
            var scoreFormula = DiceScoringFormulas.DiceSumOfSpecificNumber(valueToCheck);
            var rules = new List<Func<byte[], bool>>();
            rules.Add(DiceValidations.DiceAlwaysValid());
            var hand = new Hand(name, formulaDescription, scoreFormula, rules, Section.Upper);

            return hand;
        }



        public List<Hand> Hands = null;



        public int Score { get; set; }
    }
}