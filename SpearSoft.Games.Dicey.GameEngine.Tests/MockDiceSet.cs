using System;
using System.Collections.Generic;

namespace SpearSoft.Games.Dicey.GameEngine.Tests
{
    public class MockDiceSet : List<IDie>, IDiceSet
    {
        public MockDiceSet(params byte[] values)
        {
            this.Clear();

            foreach (var value in values)
            {
                this.Add(new Die(value));
            }
        }

        public void Roll()
        {
            throw new NotImplementedException();
        }

        public IDie GetDieByPosition(byte position)
        {
            throw new NotImplementedException();
        }
    }
}