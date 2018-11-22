using System.Collections.Generic;
using System.Linq;
using SpearSoft.Games.Dicey.GameEngine;

namespace SpearSoft.Games.Dicey.UI.Winforms
{
    public class UITestableDiceSet : List<IDie>, IDiceSet
    {
        public UITestableDiceSet() { }

        public UITestableDiceSet(params byte[] values)
        {
            LoadDice(values);
        }

        public void SetDice(params byte[] values)
        {
            LoadDice(values);
        }

        private void LoadDice(params byte[] values)
        {
            foreach (var value in values)
            {
                Add(new Die(value));
            }
        }

        public void Roll()
        {
            return;
        }

        public IDie GetDieByPosition(byte position)
        {
            return this.ElementAt(position);
        }
    }
}