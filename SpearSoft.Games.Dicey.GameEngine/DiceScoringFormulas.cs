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

        public static Func<byte[], int> DiceReturnSpecificValue(int valueToReturn)
        {
            return dice => valueToReturn;
        }

        public static Func<byte[], int> DiceSumAllIfValid(Func<byte[], bool> validator)
        {
            //return dice => dice.Where(d => d == valueToCheck).Sum(d => d);
            return GetValue;
        }

        private static int GetValue(byte[] bytes)
        {
            //Func<byte[], bool> Validator = 

            return 10;
        }
    }
}