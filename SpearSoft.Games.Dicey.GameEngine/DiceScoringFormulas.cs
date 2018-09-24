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
    }
}