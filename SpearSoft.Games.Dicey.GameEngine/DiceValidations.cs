using System;
using System.Linq;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public static class DiceValidations
    {
        public static Func<byte[], bool> DiceMustContain(byte valueToCheck)
        {
            return dice => dice.Any(d => d == valueToCheck);
        }

        public static Func<byte[], bool> DiceMustHaveCount(byte minimumCount)
        {
            return dice => dice.Length == minimumCount;
        }

        public static Func<byte[], bool> DiceMustHaveCountOfACertainValue(byte valueToCheck,byte minimumCount)
        {
            return dice => dice.Count(d => d == valueToCheck) >= minimumCount;
        }

        public static  Func<byte[], bool> DiceMustHaveValues1To6()
        {
            return dice => dice.All(d => d >= 1 && d <= 6);
        }

        public static Func<byte[], bool> DiceAlwaysValid()
        {
            return dice => true;
        }

        public static Func<byte[], bool> DiceIsXofAKind(byte numOfAKind)
        {
            return dice => dice.Count(d => d == 1) >= numOfAKind
                           || dice.Count(d => d == 2) >= numOfAKind
                           || dice.Count(d => d == 3) >= numOfAKind
                           || dice.Count(d => d == 4) >= numOfAKind
                           || dice.Count(d => d == 4) >= numOfAKind
                           || dice.Count(d => d == 5) >= numOfAKind;
        }
        public static Func<byte[], bool> DiceIsFullHouse()
        {
            byte threeOfAKind = 3;
            byte twoOfAKind = 2;
            return dice => (dice.Count(d => d == 1) == threeOfAKind
                           || dice.Count(d => d == 2) == threeOfAKind
                           || dice.Count(d => d == 3) == threeOfAKind
                           || dice.Count(d => d == 4) == threeOfAKind
                           || dice.Count(d => d == 4) == threeOfAKind
                           || dice.Count(d => d == 5) == threeOfAKind)
                           &&
                           (dice.Count(d => d == 1) == twoOfAKind
                           || dice.Count(d => d == 2) == twoOfAKind
                           || dice.Count(d => d == 3) == twoOfAKind
                           || dice.Count(d => d == 4) == twoOfAKind
                           || dice.Count(d => d == 4) == twoOfAKind
                           || dice.Count(d => d == 5) == twoOfAKind);
        }

        public static Func<byte[], bool> DiceIsSmallStraight()
        {
            return dice => dice.Any(d => d == 1) && dice.Any(d => d == 2) && dice.Any(d => d==3) && dice.Any(d => d == 4)
                || dice.Any(d => d == 2) && dice.Any(d => d == 5) && dice.Any(d => d == 3) && dice.Any(d => d == 4)
                || dice.Any(d => d == 5) && dice.Any(d => d == 6) && dice.Any(d => d == 3) && dice.Any(d => d == 4);
        }

        public static Func<byte[], bool> DiceIsLargeStraight()
        {
            return dice => dice.Any(d => d == 1) && dice.Any(d => d == 2) && dice.Any(d => d == 3) && dice.Any(d => d == 4) && dice.Any(d => d == 5)
                           || dice.Any(d => d == 6) && dice.Any(d => d == 2) && dice.Any(d => d == 3) && dice.Any(d => d == 4) && dice.Any(d => d == 5);
        }
    }
}