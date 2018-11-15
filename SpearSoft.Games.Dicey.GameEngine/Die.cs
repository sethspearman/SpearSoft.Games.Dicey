using System;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public interface IDie
    {
        bool Locked { get; set; }
        byte Value { get; }

        void Roll();
    }

    public class Die : IDie
    {
        public Die()
        {
            this.Value = Rand.GetByte();
        }

        public Die(byte initialValue)
        {
            this.Value = initialValue;
        }

        public byte Value { get; private set; }
        public bool Locked { get; set; }

        public void Roll()
        {
            if (!Locked)
            {
                this.Value = Rand.GetByte();
            }
        }

    }
}