using System.Collections.Generic;
using System.Linq;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Dice : List<Die>
    {
        private Dice(bool empty) : this()
        {
        }

        public Dice()
        {
            for (byte i = 1; i <= 5; i++) Add(new Die(i, 0));
        }

        public static Dice Empty => new Dice(true);

        public override int GetHashCode()
        {
            unchecked
            {
                var bytes = ToByteArray();

                var hash = 13;
                hash = hash * 7 + bytes[0].GetHashCode();
                hash = hash * 7 + bytes[1].GetHashCode();
                hash = hash * 7 + bytes[2].GetHashCode();
                hash = hash * 7 + bytes[3].GetHashCode();
                hash = hash * 7 + bytes[4].GetHashCode();

                return hash;
            }
        }

        public void Roll()
        {
            foreach (var die in this) die.Roll();
        }

        public Die GetDieByPosition(byte position)
        {
            return this.First(d => d.Position == position);
        }

        public byte GetByteByPosition(byte position)
        {
            var die = this.First(d => d.Position == position);
            return die.Value;
        }

        public byte[] ToByteArray()
        {
            var result = new byte[5];
            for (var index = 0; index < Count; index++)
            {
                var die = this[index];
                result[index] = die.Value;
            }

            return result;
        }

        #region System Overrides (GetHashCode, Equals, and == and != operators)
        // all this because I want to be able to do Dice dice = Dice.Empty;

        public override bool Equals(object obj)
        {
            var dice = obj as Dice;
            return dice != null && dice.GetHashCode() == GetHashCode();
        }

        public static bool operator ==(Dice d1, Dice d2)
        {
            return d1?.GetHashCode() == d2?.GetHashCode();
        }

        public static bool operator !=(Dice d1, Dice d2)
        {
            return d1?.GetHashCode() != d2?.GetHashCode();
        }

        #endregion

    }
}