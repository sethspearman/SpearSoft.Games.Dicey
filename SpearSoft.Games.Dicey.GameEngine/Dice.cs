using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Dice:List<Die>
    {
        public Dice()
        {
            for (int i = 0; i <= 4; i++)
            {
                this.Add(new Die());
            }

        }

        public void Roll()
        {
            foreach (var die in this)
            {
                die.Roll();
            }
        }

    }
}