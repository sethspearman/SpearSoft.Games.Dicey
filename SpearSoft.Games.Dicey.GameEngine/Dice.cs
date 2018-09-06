using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Dice:List<Die>
    {
        public void Roll()
        {
            foreach (var die in this)
            {
                die.Roll();
            }
        }

    }
}