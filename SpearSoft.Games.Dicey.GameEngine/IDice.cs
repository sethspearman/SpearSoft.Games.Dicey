using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public interface IDice
    {
        bool Equals(object obj);
        byte GetByteByPosition(byte position);
        Die GetDieByPosition(byte position);
        int GetHashCode();
        void Roll();
        byte[] ToByteArray();
    }

    public class DiceTest: List<IDie>, IDice
    {

        public DiceTest(List<IDie> dice)
        {
            this.AddRange(dice);
        }

        private byte[] _tempDice;
        public byte GetByteByPosition(byte position)
        {
            var die = this.First(d => d.Position == position);
            return die.Value;
        }

        public Die GetDieByPosition(byte position)
        {
            return (Die) this.First(d => d.Position == position);
        }

        public void Roll()
        {
            throw new NotImplementedException();

        }

        public void SetDice(byte[] dice)
        {
            _tempDice = dice;
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
    }
}