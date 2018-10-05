using System;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Die
    {
        public Die(byte position)
        {
            this.Value = Rand.GetByte();
            Position = position;
        }

        public Die(byte position, byte initialValue)
        {
            this.Value = initialValue;
            Position = position;
        }

        public byte Value { get; private set; }
        public bool Locked { get; set; }
        public byte Position { get; private set; }

        public void Roll()
        {
            if (!Locked)
            {
                this.Value = Rand.GetByte();
            }
        }

    }
}