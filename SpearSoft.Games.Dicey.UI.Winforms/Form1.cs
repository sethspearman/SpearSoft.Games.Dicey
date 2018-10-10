using System;
using System.Linq;
using System.Windows.Forms;
using SpearSoft.Games.Dicey.GameEngine;

namespace SpearSoft.Games.Dicey.UI.Winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Globals.Game = new Game();
            Globals.Dice = new Dice();

            SetDiceUI(true);
        }

        private void SetDiceUI(bool skipRoll)
        {
            var dice = Globals.Dice;

            if (!skipRoll) dice.Roll();

            btnDice1.Text = dice[0].Value.ToString();
            btnDice2.Text = dice[1].Value.ToString();
            btnDice3.Text = dice[2].Value.ToString();
            btnDice4.Text = dice[3].Value.ToString();
            btnDice5.Text = dice[4].Value.ToString();

            foreach (var player in Globals.Game.Players)
            {
                var gameCard = player.GameCard;

                foreach (var hand in gameCard.Hands)
                {
                    hand.SetDice(dice.ToByteArray());
                }

                SetupGameCard(gameCard);
            }
        }

        private void SetupGameCard(GameCard gameCard)
        {
            //upper section
            lblAces.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Aces)?.Score.ToString();
            lblTwos.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Twos)?.Score.ToString();
            lblThrees.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Threes)?.Score.ToString();
            lblFours.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Fours)?.Score.ToString();
            lblFives.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Fives)?.Score.ToString();
            lblSixes.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Sixes)?.Score.ToString();

            //lower section
            lbl3OfAKind.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.ThreeOfAKind)?.Score.ToString();
            lbl4OfAKind.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.FourOfAKind)?.Score.ToString();
            lblFullHouse.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.FullHouse)?.Score.ToString();
            lblSmallStraight.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.SmallStraight)?.Score.ToString();
            lblLargeStraight.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.LargeStraight)?.Score.ToString();
            lblYahtzee.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Yahtzee)?.Score.ToString();
            lblChance.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Chance)?.Score.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetDiceUI(false);
        }

        private void SetButtonImage(Button button)
        {
            LockDie(button);

            if (button.ImageIndex == 0)
                button.ImageIndex = -1;
            else
                button.ImageIndex = 0;
        }

        private void LockDie(Button button)
        {
            var position = Convert.ToByte(button.Tag);

            var die = Globals.Dice.GetDieByPosition(position);

            if (button.ImageIndex == 0)
                die.Locked = false; //unlock
            else
                die.Locked = true;
        }

        private void btnDice1_Click(object sender, EventArgs e)
        {
            if (sender is Button button) SetButtonImage(button);
        }

        private void btnDice2_Click(object sender, EventArgs e)
        {
            if (sender is Button button) SetButtonImage(button);
        }

        private void btnDice3_Click(object sender, EventArgs e)
        {
            if (sender is Button button) SetButtonImage(button);
        }

        private void btnDice4_Click(object sender, EventArgs e)
        {
            if (sender is Button button) SetButtonImage(button);
        }

        private void btnDice5_Click(object sender, EventArgs e)
        {
            if (sender is Button button) SetButtonImage(button);
        }
    }
}