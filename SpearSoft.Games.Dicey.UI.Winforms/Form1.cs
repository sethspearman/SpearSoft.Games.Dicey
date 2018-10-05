using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if (!skipRoll)
            {
                dice.Roll();    
            }

            btnDice1.Text = dice[0].Value.ToString();
            btnDice2.Text = dice[1].Value.ToString();
            btnDice3.Text = dice[2].Value.ToString();
            btnDice4.Text = dice[3].Value.ToString();
            btnDice5.Text = dice[4].Value.ToString();

            var player = Globals.Game.Players[0];
            var gameCard = player.GameCard;

            foreach (var hand in gameCard.Hands)
            {
                hand.SetDice(dice.ToByteArray());
            }

            //upper section
            lblAces.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Aces")?.Score.ToString();
            lblTwos.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Twos")?.Score.ToString();
            lblThrees.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Threes")?.Score.ToString();
            lblFours.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Fours")?.Score.ToString();
            lblFives.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Fives")?.Score.ToString();
            lblSixes.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Sixes")?.Score.ToString();

            //lower section
            lbl3OfAKind.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Three of a Kind")?.Score.ToString();
            lbl4OfAKind.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Four of a Kind")?.Score.ToString();
            lblFullHouse.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Full House")?.Score.ToString();
            lblSmallStraight.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Small Straight")?.Score.ToString();
            lblLargeStraight.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Large Straight")?.Score.ToString();
            lblYahtzee.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Yahtzee")?.Score.ToString();
            lblChance.Text = gameCard.Hands.SingleOrDefault(h => h.Name == "Chance")?.Score.ToString();

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
            byte position = Convert.ToByte( button.Tag );

            Die die = Globals.Dice.GetDieByPosition(position);

            if (button.ImageIndex == 0)
                die.Locked = false; //unlock
            else
                die.Locked = true; 


        }

        private void btnDice1_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetButtonImage(button);
            }

        }

        private void btnDice2_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetButtonImage(button);
            }

        }

        private void btnDice3_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetButtonImage(button);
            }

        }

        private void btnDice4_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetButtonImage(button);
            }

        }

        private void btnDice5_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetButtonImage(button);
            }

        }
    }
}
