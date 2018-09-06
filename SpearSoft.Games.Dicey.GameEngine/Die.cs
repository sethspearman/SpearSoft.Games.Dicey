using System;

namespace SpearSoft.Games.Dicey.GameEngine
{
    public class Die
    {
        public Die()
        {
            Value = 1;
        }

        public int Value { get; set; }

        public void Roll()
        {
            var r = new Random();
            this.Value = r.Next(1, 6); //some random number
        }

    }
}