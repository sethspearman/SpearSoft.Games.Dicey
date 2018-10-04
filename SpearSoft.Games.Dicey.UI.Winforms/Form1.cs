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

            var game = new Game();
            Globals.Dice = new Dice();

            SetDiceUI();
        }

        private void SetDiceUI()
        {
            var dice = Globals.Dice;
            dice.Roll();

            btnDice1.Text = dice[0].Value.ToString();
            btnDice2.Text = dice[1].Value.ToString();
            btnDice3.Text = dice[2].Value.ToString();
            btnDice4.Text = dice[3].Value.ToString();
            btnDice5.Text = dice[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetDiceUI();
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
