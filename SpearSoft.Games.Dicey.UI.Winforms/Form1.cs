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

#if TESTING_DICE
            Globals.Dice = new UITestableDiceSet();
#else
            Globals.Dice = new Dice();
#endif

            Globals.Game.IncrementRound += Game_IncrementRound;
            Globals.Game.NextPlayer += Game_NextPlayer;

            Globals.Game.CurrentPlayer.GameCard.GameHandApplied += GameCard_GameHandApplied;

            SetDiceUI(true);
        }

        private void GameCard_GameHandApplied(object sender, GameHandAppliedEventArgs e)
        {
            if (e.Hand.Name == GameCard.Yahtzee)
            {
                chkBonusYahtzee1.Enabled = true;
            }
        }

        private void Game_NextPlayer(object sender, NextPlayerEventArgs e)
        {
            //Globals.Game.CurrentPlayer = e.Player;
        }

        private void Game_IncrementRound(object sender, NextRoundEventArgs e)
        {
            //Globals.CurrentRound = e.NewRound;
        }

        private void SetDiceUI(bool skipRoll)
        {
            var dice = Globals.Dice;

            if (!skipRoll) Globals.Game.Players[0].RollDice(dice);

            btnDice1.Text = dice.GetDieByPosition(0).Value.ToString();
            btnDice2.Text = dice.GetDieByPosition(1).Value.ToString();
            btnDice3.Text = dice.GetDieByPosition(2).Value.ToString();
            btnDice4.Text = dice.GetDieByPosition(3).Value.ToString();
            btnDice5.Text = dice.GetDieByPosition(4).Value.ToString();

            foreach (var player in Globals.Game.Players)
            {
                var gameCard = player.GameCard;

                foreach (var hand in gameCard.Hands) hand.SetDice(dice);

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
            lblSmallStraight.Text =
                gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.SmallStraight)?.Score.ToString();
            lblLargeStraight.Text =
                gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.LargeStraight)?.Score.ToString();
            lblYahtzee.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Yahtzee)?.Score.ToString();
            lblChance.Text = gameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Chance)?.Score.ToString();

            lblCurrentPlayer.Text = Globals.Game.CurrentPlayer.PlayerName;

            SetScoreUI(gameCard);
        }

        private void SetScoreUI(GameCard gameCard)
        {
            lblScoreValue.Text = Globals.Game.CurrentPlayer.GameCard.PotentialScore.ToString();

            lblUpperTotalValue.Text = gameCard.PotentialUpperScore.ToString();
            lblLowerTotalValue.Text = gameCard.PotentialLowerScore.ToString();

            lblUpperBonusValue.Text = gameCard.UpperBonus.ToString();
            lblLowerBonusValue.Text = gameCard.LowerBonus.ToString();

            lblScoreValue.Text = gameCard.Score.ToString();

            //lblScoreValue.Text = (gameCard.UpperScore + gameCard.LowerScore).ToString();
        }

        private void SetScoreUI()
        {
            SetScoreUI(Globals.Game.CurrentPlayer.GameCard);
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            SetDiceUI(false);
            Globals.Game.CurrentPlayer.GameCard.ClearSelected();
            SetLockedImage(this);
        }

        private void SetDiceButtonImage(Button button)
        {
            LockDie(button);

            if (button.ImageIndex == 0)
                button.ImageIndex = -1;
            else
                button.ImageIndex = 0;
        }

        private void SetHandButtonImage(Button button, bool isSelected)
        {
            if (isSelected)
                button.ImageIndex = 0;
            else
                button.ImageIndex = -1;
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
            if (sender is Button button) SetDiceButtonImage(button);
        }

        private void btnDice2_Click(object sender, EventArgs e)
        {
            if (sender is Button button) SetDiceButtonImage(button);
        }

        private void btnDice3_Click(object sender, EventArgs e)
        {
            if (sender is Button button) SetDiceButtonImage(button);
        }

        private void btnDice4_Click(object sender, EventArgs e)
        {
            if (sender is Button button) SetDiceButtonImage(button);
        }

        private void btnDice5_Click(object sender, EventArgs e)
        {
            if (sender is Button button) SetDiceButtonImage(button);
        }

        private void btnAces_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void SetSelectedUpdateImages(object sender)
        {
            if (sender is Button)
            {
                var ctrl = sender as Button;

                var tag = ctrl.Tag?.ToString() ?? string.Empty;
                if (tag.Contains("IsHand"))
                {
                    var tagvals = tag.Split(';');

                    var handName = tagvals[1];

                    SelectHand(handName);

                    SetLockedImage(this);
                }
                SetScoreUI();
            }
        }

        private void SetLockedImage(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button)
                {
                    var c = control as Button;
                    if ((c.Tag?.ToString() ?? "").Contains("IsHand"))
                    {

                        var tag = c.Tag?.ToString() ?? string.Empty;
                        var tagvals = tag.Split(';');

                        var handName = tagvals[1];
                        var hand = GetHand(handName);

                        SetHandButtonImage(c, hand.IsSelected);
                    }
                }
                else
                {
                    SetLockedImage(control);
                }
            }
        }

        private static void SelectHand(string handName)
        {
            Globals.Game.CurrentPlayer.GameCard.SelectUnselectHand(
                Globals.Game.CurrentPlayer.GameCard.Hands.First(h => h.Name == handName));
        }

        private static Hand GetHand(string handName)
        {
            return Globals.Game.CurrentPlayer.GameCard.Hands.First(h => h.Name == handName);
        }

        private void btnTwos_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btnThrees_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btnFours_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btnFives_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btnSixes_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btn3OfAKind_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btn4OfAKind_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btnFullHouse_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btnSmallStraight_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btnLargeStraight_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btnYahtzee_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void btnChance_Click(object sender, EventArgs e)
        {
            SetSelectedUpdateImages(sender);
        }

        private void chkBonusYahtzee1_CheckedChanged(object sender, EventArgs e)
        {
            //var hand = Globals.Game.CurrentPlayer.GameCard.Hands.First(h => h.Name == GameCard.Yahtzee);
            var hand = GetHand(GameCard.Yahtzee);

            if (hand.IsApplied)
            {
                Globals.Game.CurrentPlayer.GameCard.BonusYahtzeeCount++;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
#if TESTING_DICE // You could even make adding the button to the UI conditional on the symbol
            var bytes = new byte[] { 1, 1, 1, 1, 1 };

            var hand = Globals.Game.CurrentPlayer.GameCard.Hands.SingleOrDefault(h => h.Name == GameCard.Yahtzee);

            hand.SetDice(Globals.Dice); // or hand.SetDice(new UITestableDiceSet(1,1,1,1,1)); 
            //hand.SetDice(bytes);
            //Globals.Dice.Roll(bytes);
#endif
        }
    }
}