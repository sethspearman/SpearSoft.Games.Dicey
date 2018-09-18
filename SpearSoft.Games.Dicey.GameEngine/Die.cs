using System;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Die
    {
        public Die()
        {
            Rand.GetByte(this);
        }

        public int Value { get; set; }
        public bool Locked { get; set; }

        public void Roll()
        {
            if (!Locked)
            {
                Rand.GetByte(this);
            }
        }

    }
}