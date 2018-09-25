using System;
using System.Linq;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public static class DiceScoringFormulas
    {
        public static Func<byte[], int> DiceSumOfSpecificNumber(byte valueToCheck)
        {
            return dice => dice.Where(d => d == valueToCheck).Sum(d => d);
        }

        public static Func<byte[], int> DiceSumAll()
        {
            return dice => dice.Sum(d => d);
        }

        public static Func<byte[], int> DiceBonusYahtzeeIfValid(Func<byte[], bool> validator)
        {
            //this calculation will be way more complicated and depends on other values that are already set.  for now return 100.
            return dice => validator.Invoke(dice) ? 100 : 0;
        }

        public static Func<byte[], int> DiceReturnSpecificValueIfValid(Func<byte[], bool> validator,int valueToReturn)
        {
            //return dice => valueToReturn;
            return dice => validator.Invoke(dice) ? valueToReturn : 0;
        }

        public static Func<byte[], int> DiceSumAllIfValid(Func<byte[], bool> validator)
        {
            //return dice => dice.Where(d => d == valueToCheck).Sum(d => d);
            //return dice => GetValue(dice,validator);
            return dice => validator.Invoke(dice) ? dice.Sum(d => d) : 0;
        }
    }
}