using System;
using System.Collections.Generic;
using System.Linq;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public static class DiceScoringFormulas
    {
        public static Func<IEnumerable<IDie>, int>DiceSumOfSpecificNumber(byte valueToCheck)
        {
            return dice => dice.Where(d => d.Value == valueToCheck).Sum(d => d.Value);
        }

        public static Func<IEnumerable<IDie>, int> DiceSumAll()
        {
            return dice => dice.Sum(d => d.Value);
        }

        public static Func<IEnumerable<IDie>, int> DiceBonusYahtzeeIfValid(Func<IEnumerable<IDie>, bool> validator)
        {
            //this calculation will be way more complicated and depends on other values that are already set.  for now return 100.
            return dice => validator.Invoke(dice) ? 100 : 0;
        }

        public static Func<IEnumerable<IDie>, int> DiceReturnSpecificValueIfValid(Func<IEnumerable<IDie>, bool> validator,int valueToReturn)
        {
            //return dice => valueToReturn;
            return dice => validator.Invoke(dice) ? valueToReturn : 0;
        }

        public static Func<IEnumerable<IDie>, int> DiceSumAllIfValid(Func<IEnumerable<IDie>, bool> validator)
        {
            //return dice => dice.Where(d => d == valueToCheck).Sum(d => d);
            //return dice => GetValue(dice,validator);
            return dice => validator.Invoke(dice) ? dice.Sum(d => d.Value) : 0;
        }
    }
}