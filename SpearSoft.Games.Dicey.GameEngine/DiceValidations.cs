using System;
using System.Collections.Generic;
using System.Linq;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class DiceValidations
    {
        public static Func<IEnumerable<IDie>, bool> DiceMustContain(byte valueToCheck)
        {
            return dice => dice.Any(d => d.Value == valueToCheck);
        }

        public static Func<IEnumerable<IDie>, bool> DiceMustHaveCount(byte minimumCount)
        {
            return dice => dice.Count() == minimumCount;
        }

        public static Func<IEnumerable<IDie>, bool> DiceMustHaveCountOfACertainValue(byte valueToCheck,byte minimumCount)
        {
            return dice => dice.Count(d => d.Value == valueToCheck) >= minimumCount;
        }

        public static  Func<IEnumerable<IDie>, bool> DiceMustHaveValues1To6()
        {
            return dice => dice.All(d => d.Value >= 1 && d.Value <= 6);
        }

        public static Func<IEnumerable<IDie>, bool> DiceAlwaysValid()
        {
            return dice => true;
        }

        public static Func<IEnumerable<IDie>, bool> DiceIsXofAKind(byte numOfAKind)
        {
            return dice => dice.Count(d => d.Value == 1) >= numOfAKind
                           || dice.Count(d => d.Value == 2) >= numOfAKind
                           || dice.Count(d => d.Value == 3) >= numOfAKind
                           || dice.Count(d => d.Value == 4) >= numOfAKind
                           || dice.Count(d => d.Value == 5) >= numOfAKind
                           || dice.Count(d => d.Value == 6) >= numOfAKind;
        }
        public static Func<IEnumerable<IDie>, bool> DiceIsFullHouse()
        {
            byte threeOfAKind = 3;
            byte twoOfAKind = 2;
            return dice => (dice.Count(d => d.Value == 1) == threeOfAKind
                           || dice.Count(d => d.Value == 2) == threeOfAKind
                           || dice.Count(d => d.Value == 3) == threeOfAKind
                           || dice.Count(d => d.Value == 4) == threeOfAKind
                           || dice.Count(d => d.Value == 5) == threeOfAKind
                           || dice.Count(d => d.Value == 6) == threeOfAKind)
                           &&
                           (dice.Count(d => d.Value == 1) == twoOfAKind
                           || dice.Count(d => d.Value == 2) == twoOfAKind
                           || dice.Count(d => d.Value == 3) == twoOfAKind
                           || dice.Count(d => d.Value == 4) == twoOfAKind
                           || dice.Count(d => d.Value == 5) == twoOfAKind
                           || dice.Count(d => d.Value == 6) == twoOfAKind);
        }

        public static Func<IEnumerable<IDie>, bool> DiceIsSmallStraight()
        {
            return dice => dice.Any(d => d.Value == 1) && dice.Any(d => d.Value == 2) && dice.Any(d => d.Value ==3) && dice.Any(d => d.Value == 4)
                || dice.Any(d => d.Value == 2) && dice.Any(d => d.Value == 5) && dice.Any(d => d.Value == 3) && dice.Any(d => d.Value == 4)
                || dice.Any(d => d.Value == 5) && dice.Any(d => d.Value == 6) && dice.Any(d => d.Value == 3) && dice.Any(d => d.Value == 4);
        }

        public static Func<IEnumerable<IDie>, bool> DiceIsLargeStraight()
        {
            return dice => dice.Any(d => d.Value == 1) && dice.Any(d => d.Value == 2) && dice.Any(d => d.Value == 3) && dice.Any(d => d.Value == 4) && dice.Any(d => d.Value == 5)
                           || dice.Any(d => d.Value == 6) && dice.Any(d => d.Value == 2) && dice.Any(d => d.Value == 3) && dice.Any(d => d.Value == 4) && dice.Any(d => d.Value == 5);
        }
    }
}