using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Dice:List<Die>
    {
        public Dice()
        {
            for (byte i = 1; i <= 5; i++)
            {
                this.Add(new Die(i));
            }

        }

        public void Roll()
        {
            foreach (var die in this)
            {
                die.Roll();
            }
        }

        public Die GetDieByPosition(byte position)
        {
            return this.First(d => d.Position == position);
        }

        public byte GetByteByPosition(byte position)
        {
            Die die =  this.First(d => d.Position == position);
            return die.Value;
        }

        public byte[] ToByteArray()
        {
            var result = new byte[5];
            for (int index = 0; index < Count; index++)
            {
                var die = this[index];
                result[index] = die.Value;
            }

            return result;
        }

    }
}