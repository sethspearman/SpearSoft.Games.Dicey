using System;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public interface IDie
    {
        bool Locked { get; set; }
        byte Position { get; }
        byte Value { get; }
        void Roll();
        //void Roll(byte value);
    }

    class DieTest : IDie
    {
        public bool Locked { get; set; }
        public byte Position { get; }
        public byte Value { get; private set; }
        public void Roll()
        {
            if (!Locked)
            {
                this.Value = Rand.GetByte();
            }
        }

        public void SetDie(byte value)
        {
            Value = value;
        }
    }
}