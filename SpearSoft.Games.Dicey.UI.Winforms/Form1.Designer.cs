namespace SpearSoft.Games.Dicey.UI.Winforms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDice5 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnDice4 = new System.Windows.Forms.Button();
            this.btnDice3 = new System.Windows.Forms.Button();
            this.btnDice2 = new System.Windows.Forms.Button();
            this.btnDice1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBoxUpperSection = new System.Windows.Forms.GroupBox();
            this.lblTwos = new System.Windows.Forms.Label();
            this.lblThrees = new System.Windows.Forms.Label();
            this.lblFours = new System.Windows.Forms.Label();
            this.lblFives = new System.Windows.Forms.Label();
            this.lblSixes = new System.Windows.Forms.Label();
            this.lblAces = new System.Windows.Forms.Label();
            this.btnSixes = new System.Windows.Forms.Button();
            this.btnFives = new System.Windows.Forms.Button();
            this.btnFours = new System.Windows.Forms.Button();
            this.btnThrees = new System.Windows.Forms.Button();
            this.btnTwos = new System.Windows.Forms.Button();
            this.btnAces = new System.Windows.Forms.Button();
            this.groupBoxLowerSection = new System.Windows.Forms.GroupBox();
            this.lblChance = new System.Windows.Forms.Label();
            this.lbl4OfAKind = new System.Windows.Forms.Label();
            this.lblFullHouse = new System.Windows.Forms.Label();
            this.lblSmallStraight = new System.Windows.Forms.Label();
            this.lblLargeStraight = new System.Windows.Forms.Label();
            this.lblYahtzee = new System.Windows.Forms.Label();
            this.lbl3OfAKind = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnYahtzee = new System.Windows.Forms.Button();
            this.btnLargeStraight = new System.Windows.Forms.Button();
            this.btnSmallStraight = new System.Windows.Forms.Button();
            this.btnFullHouse = new System.Windows.Forms.Button();
            this.btn4OfAKind = new System.Windows.Forms.Button();
            this.btn3OfAKind = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBoxUpperSection.SuspendLayout();
            this.groupBoxLowerSection.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDice5);
            this.panel1.Controls.Add(this.btnDice4);
            this.panel1.Controls.Add(this.btnDice3);
            this.panel1.Controls.Add(this.btnDice2);
            this.panel1.Controls.Add(this.btnDice1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 84);
            this.panel1.TabIndex = 0;
            // 
            // btnDice5
            // 
            this.btnDice5.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDice5.ImageList = this.imageList1;
            this.btnDice5.Location = new System.Drawing.Point(327, 3);
            this.btnDice5.Name = "btnDice5";
            this.btnDice5.Size = new System.Drawing.Size(75, 78);
            this.btnDice5.TabIndex = 4;
            this.btnDice5.Tag = "5";
            this.btnDice5.Text = "btnDice5";
            this.btnDice5.UseVisualStyleBackColor = true;
            this.btnDice5.Click += new System.EventHandler(this.btnDice5_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "LockedIcon.ico");
            // 
            // btnDice4
            // 
            this.btnDice4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDice4.ImageList = this.imageList1;
            this.btnDice4.Location = new System.Drawing.Point(246, 3);
            this.btnDice4.Name = "btnDice4";
            this.btnDice4.Size = new System.Drawing.Size(75, 78);
            this.btnDice4.TabIndex = 3;
            this.btnDice4.Tag = "4";
            this.btnDice4.Text = "btnDice4";
            this.btnDice4.UseVisualStyleBackColor = true;
            this.btnDice4.Click += new System.EventHandler(this.btnDice4_Click);
            // 
            // btnDice3
            // 
            this.btnDice3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDice3.ImageList = this.imageList1;
            this.btnDice3.Location = new System.Drawing.Point(165, 3);
            this.btnDice3.Name = "btnDice3";
            this.btnDice3.Size = new System.Drawing.Size(75, 78);
            this.btnDice3.TabIndex = 2;
            this.btnDice3.Tag = "3";
            this.btnDice3.Text = "btnDice3";
            this.btnDice3.UseVisualStyleBackColor = true;
            this.btnDice3.Click += new System.EventHandler(this.btnDice3_Click);
            // 
            // btnDice2
            // 
            this.btnDice2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDice2.ImageList = this.imageList1;
            this.btnDice2.Location = new System.Drawing.Point(84, 3);
            this.btnDice2.Name = "btnDice2";
            this.btnDice2.Size = new System.Drawing.Size(75, 78);
            this.btnDice2.TabIndex = 1;
            this.btnDice2.Tag = "2";
            this.btnDice2.Text = "btnDice2";
            this.btnDice2.UseVisualStyleBackColor = true;
            this.btnDice2.Click += new System.EventHandler(this.btnDice2_Click);
            // 
            // btnDice1
            // 
            this.btnDice1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDice1.ImageList = this.imageList1;
            this.btnDice1.Location = new System.Drawing.Point(3, 3);
            this.btnDice1.Name = "btnDice1";
            this.btnDice1.Size = new System.Drawing.Size(75, 78);
            this.btnDice1.TabIndex = 0;
            this.btnDice1.Tag = "1";
            this.btnDice1.Text = "btnDice1";
            this.btnDice1.UseVisualStyleBackColor = true;
            this.btnDice1.Click += new System.EventHandler(this.btnDice1_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(166, 522);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "Roll";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBoxUpperSection
            // 
            this.groupBoxUpperSection.Controls.Add(this.lblTwos);
            this.groupBoxUpperSection.Controls.Add(this.lblThrees);
            this.groupBoxUpperSection.Controls.Add(this.lblFours);
            this.groupBoxUpperSection.Controls.Add(this.lblFives);
            this.groupBoxUpperSection.Controls.Add(this.lblSixes);
            this.groupBoxUpperSection.Controls.Add(this.lblAces);
            this.groupBoxUpperSection.Controls.Add(this.btnSixes);
            this.groupBoxUpperSection.Controls.Add(this.btnFives);
            this.groupBoxUpperSection.Controls.Add(this.btnFours);
            this.groupBoxUpperSection.Controls.Add(this.btnThrees);
            this.groupBoxUpperSection.Controls.Add(this.btnTwos);
            this.groupBoxUpperSection.Controls.Add(this.btnAces);
            this.groupBoxUpperSection.Location = new System.Drawing.Point(15, 123);
            this.groupBoxUpperSection.Name = "groupBoxUpperSection";
            this.groupBoxUpperSection.Size = new System.Drawing.Size(202, 383);
            this.groupBoxUpperSection.TabIndex = 2;
            this.groupBoxUpperSection.TabStop = false;
            this.groupBoxUpperSection.Text = "Upper Section";
            // 
            // lblTwos
            // 
            this.lblTwos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTwos.Location = new System.Drawing.Point(88, 50);
            this.lblTwos.Name = "lblTwos";
            this.lblTwos.Size = new System.Drawing.Size(100, 22);
            this.lblTwos.TabIndex = 11;
            // 
            // lblThrees
            // 
            this.lblThrees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThrees.Location = new System.Drawing.Point(88, 79);
            this.lblThrees.Name = "lblThrees";
            this.lblThrees.Size = new System.Drawing.Size(100, 22);
            this.lblThrees.TabIndex = 10;
            // 
            // lblFours
            // 
            this.lblFours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFours.Location = new System.Drawing.Point(88, 108);
            this.lblFours.Name = "lblFours";
            this.lblFours.Size = new System.Drawing.Size(100, 22);
            this.lblFours.TabIndex = 9;
            // 
            // lblFives
            // 
            this.lblFives.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFives.Location = new System.Drawing.Point(88, 137);
            this.lblFives.Name = "lblFives";
            this.lblFives.Size = new System.Drawing.Size(100, 22);
            this.lblFives.TabIndex = 8;
            // 
            // lblSixes
            // 
            this.lblSixes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSixes.Location = new System.Drawing.Point(88, 166);
            this.lblSixes.Name = "lblSixes";
            this.lblSixes.Size = new System.Drawing.Size(100, 22);
            this.lblSixes.TabIndex = 7;
            // 
            // lblAces
            // 
            this.lblAces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAces.Location = new System.Drawing.Point(88, 21);
            this.lblAces.Name = "lblAces";
            this.lblAces.Size = new System.Drawing.Size(100, 22);
            this.lblAces.TabIndex = 6;
            // 
            // btnSixes
            // 
            this.btnSixes.Location = new System.Drawing.Point(7, 165);
            this.btnSixes.Name = "btnSixes";
            this.btnSixes.Size = new System.Drawing.Size(75, 23);
            this.btnSixes.TabIndex = 5;
            this.btnSixes.Text = "Sixes";
            this.btnSixes.UseVisualStyleBackColor = true;
            // 
            // btnFives
            // 
            this.btnFives.Location = new System.Drawing.Point(7, 136);
            this.btnFives.Name = "btnFives";
            this.btnFives.Size = new System.Drawing.Size(75, 23);
            this.btnFives.TabIndex = 4;
            this.btnFives.Text = "Fives";
            this.btnFives.UseVisualStyleBackColor = true;
            // 
            // btnFours
            // 
            this.btnFours.Location = new System.Drawing.Point(7, 107);
            this.btnFours.Name = "btnFours";
            this.btnFours.Size = new System.Drawing.Size(75, 23);
            this.btnFours.TabIndex = 3;
            this.btnFours.Text = "Fours";
            this.btnFours.UseVisualStyleBackColor = true;
            // 
            // btnThrees
            // 
            this.btnThrees.Location = new System.Drawing.Point(7, 78);
            this.btnThrees.Name = "btnThrees";
            this.btnThrees.Size = new System.Drawing.Size(75, 23);
            this.btnThrees.TabIndex = 2;
            this.btnThrees.Text = "Threes";
            this.btnThrees.UseVisualStyleBackColor = true;
            // 
            // btnTwos
            // 
            this.btnTwos.Location = new System.Drawing.Point(7, 49);
            this.btnTwos.Name = "btnTwos";
            this.btnTwos.Size = new System.Drawing.Size(75, 23);
            this.btnTwos.TabIndex = 1;
            this.btnTwos.Text = "Twos";
            this.btnTwos.UseVisualStyleBackColor = true;
            // 
            // btnAces
            // 
            this.btnAces.Location = new System.Drawing.Point(7, 20);
            this.btnAces.Name = "btnAces";
            this.btnAces.Size = new System.Drawing.Size(75, 23);
            this.btnAces.TabIndex = 0;
            this.btnAces.Text = "Aces";
            this.btnAces.UseVisualStyleBackColor = true;
            // 
            // groupBoxLowerSection
            // 
            this.groupBoxLowerSection.Controls.Add(this.lblChance);
            this.groupBoxLowerSection.Controls.Add(this.lbl4OfAKind);
            this.groupBoxLowerSection.Controls.Add(this.lblFullHouse);
            this.groupBoxLowerSection.Controls.Add(this.lblSmallStraight);
            this.groupBoxLowerSection.Controls.Add(this.lblLargeStraight);
            this.groupBoxLowerSection.Controls.Add(this.lblYahtzee);
            this.groupBoxLowerSection.Controls.Add(this.lbl3OfAKind);
            this.groupBoxLowerSection.Controls.Add(this.button1);
            this.groupBoxLowerSection.Controls.Add(this.btnYahtzee);
            this.groupBoxLowerSection.Controls.Add(this.btnLargeStraight);
            this.groupBoxLowerSection.Controls.Add(this.btnSmallStraight);
            this.groupBoxLowerSection.Controls.Add(this.btnFullHouse);
            this.groupBoxLowerSection.Controls.Add(this.btn4OfAKind);
            this.groupBoxLowerSection.Controls.Add(this.btn3OfAKind);
            this.groupBoxLowerSection.Location = new System.Drawing.Point(223, 124);
            this.groupBoxLowerSection.Name = "groupBoxLowerSection";
            this.groupBoxLowerSection.Size = new System.Drawing.Size(202, 381);
            this.groupBoxLowerSection.TabIndex = 3;
            this.groupBoxLowerSection.TabStop = false;
            this.groupBoxLowerSection.Text = "Lower Section";
            // 
            // lblChance
            // 
            this.lblChance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChance.Location = new System.Drawing.Point(99, 196);
            this.lblChance.Name = "lblChance";
            this.lblChance.Size = new System.Drawing.Size(92, 20);
            this.lblChance.TabIndex = 20;
            // 
            // lbl4OfAKind
            // 
            this.lbl4OfAKind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl4OfAKind.Location = new System.Drawing.Point(99, 51);
            this.lbl4OfAKind.Name = "lbl4OfAKind";
            this.lbl4OfAKind.Size = new System.Drawing.Size(92, 20);
            this.lbl4OfAKind.TabIndex = 19;
            // 
            // lblFullHouse
            // 
            this.lblFullHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFullHouse.Location = new System.Drawing.Point(99, 80);
            this.lblFullHouse.Name = "lblFullHouse";
            this.lblFullHouse.Size = new System.Drawing.Size(92, 20);
            this.lblFullHouse.TabIndex = 18;
            // 
            // lblSmallStraight
            // 
            this.lblSmallStraight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSmallStraight.Location = new System.Drawing.Point(99, 109);
            this.lblSmallStraight.Name = "lblSmallStraight";
            this.lblSmallStraight.Size = new System.Drawing.Size(92, 20);
            this.lblSmallStraight.TabIndex = 17;
            // 
            // lblLargeStraight
            // 
            this.lblLargeStraight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLargeStraight.Location = new System.Drawing.Point(99, 138);
            this.lblLargeStraight.Name = "lblLargeStraight";
            this.lblLargeStraight.Size = new System.Drawing.Size(92, 20);
            this.lblLargeStraight.TabIndex = 16;
            // 
            // lblYahtzee
            // 
            this.lblYahtzee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYahtzee.Location = new System.Drawing.Point(99, 167);
            this.lblYahtzee.Name = "lblYahtzee";
            this.lblYahtzee.Size = new System.Drawing.Size(92, 20);
            this.lblYahtzee.TabIndex = 15;
            // 
            // lbl3OfAKind
            // 
            this.lbl3OfAKind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl3OfAKind.Location = new System.Drawing.Point(99, 22);
            this.lbl3OfAKind.Name = "lbl3OfAKind";
            this.lbl3OfAKind.Size = new System.Drawing.Size(92, 20);
            this.lbl3OfAKind.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Chance";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnYahtzee
            // 
            this.btnYahtzee.Location = new System.Drawing.Point(6, 165);
            this.btnYahtzee.Name = "btnYahtzee";
            this.btnYahtzee.Size = new System.Drawing.Size(87, 23);
            this.btnYahtzee.TabIndex = 11;
            this.btnYahtzee.Text = "Yahtzee";
            this.btnYahtzee.UseVisualStyleBackColor = true;
            // 
            // btnLargeStraight
            // 
            this.btnLargeStraight.Location = new System.Drawing.Point(6, 136);
            this.btnLargeStraight.Name = "btnLargeStraight";
            this.btnLargeStraight.Size = new System.Drawing.Size(87, 23);
            this.btnLargeStraight.TabIndex = 10;
            this.btnLargeStraight.Text = "Large Straight";
            this.btnLargeStraight.UseVisualStyleBackColor = true;
            // 
            // btnSmallStraight
            // 
            this.btnSmallStraight.Location = new System.Drawing.Point(6, 107);
            this.btnSmallStraight.Name = "btnSmallStraight";
            this.btnSmallStraight.Size = new System.Drawing.Size(87, 23);
            this.btnSmallStraight.TabIndex = 9;
            this.btnSmallStraight.Text = "Small Straight";
            this.btnSmallStraight.UseVisualStyleBackColor = true;
            // 
            // btnFullHouse
            // 
            this.btnFullHouse.Location = new System.Drawing.Point(6, 78);
            this.btnFullHouse.Name = "btnFullHouse";
            this.btnFullHouse.Size = new System.Drawing.Size(87, 23);
            this.btnFullHouse.TabIndex = 8;
            this.btnFullHouse.Text = "Full House";
            this.btnFullHouse.UseVisualStyleBackColor = true;
            // 
            // btn4OfAKind
            // 
            this.btn4OfAKind.Location = new System.Drawing.Point(6, 49);
            this.btn4OfAKind.Name = "btn4OfAKind";
            this.btn4OfAKind.Size = new System.Drawing.Size(87, 23);
            this.btn4OfAKind.TabIndex = 7;
            this.btn4OfAKind.Text = "4 of a kind";
            this.btn4OfAKind.UseVisualStyleBackColor = true;
            // 
            // btn3OfAKind
            // 
            this.btn3OfAKind.Location = new System.Drawing.Point(6, 20);
            this.btn3OfAKind.Name = "btn3OfAKind";
            this.btn3OfAKind.Size = new System.Drawing.Size(87, 23);
            this.btn3OfAKind.TabIndex = 6;
            this.btn3OfAKind.Text = "3 of a kind";
            this.btn3OfAKind.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 574);
            this.Controls.Add(this.groupBoxLowerSection);
            this.Controls.Add(this.groupBoxUpperSection);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.groupBoxUpperSection.ResumeLayout(false);
            this.groupBoxLowerSection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDice5;
        private System.Windows.Forms.Button btnDice4;
        private System.Windows.Forms.Button btnDice3;
        private System.Windows.Forms.Button btnDice2;
        private System.Windows.Forms.Button btnDice1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBoxUpperSection;
        private System.Windows.Forms.GroupBox groupBoxLowerSection;
        private System.Windows.Forms.Button btnSixes;
        private System.Windows.Forms.Button btnFives;
        private System.Windows.Forms.Button btnFours;
        private System.Windows.Forms.Button btnThrees;
        private System.Windows.Forms.Button btnTwos;
        private System.Windows.Forms.Button btnAces;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnYahtzee;
        private System.Windows.Forms.Button btnLargeStraight;
        private System.Windows.Forms.Button btnSmallStraight;
        private System.Windows.Forms.Button btnFullHouse;
        private System.Windows.Forms.Button btn4OfAKind;
        private System.Windows.Forms.Button btn3OfAKind;
        private System.Windows.Forms.Label lblTwos;
        private System.Windows.Forms.Label lblThrees;
        private System.Windows.Forms.Label lblFours;
        private System.Windows.Forms.Label lblFives;
        private System.Windows.Forms.Label lblSixes;
        private System.Windows.Forms.Label lblAces;
        private System.Windows.Forms.Label lblChance;
        private System.Windows.Forms.Label lbl4OfAKind;
        private System.Windows.Forms.Label lblFullHouse;
        private System.Windows.Forms.Label lblSmallStraight;
        private System.Windows.Forms.Label lblLargeStraight;
        private System.Windows.Forms.Label lblYahtzee;
        private System.Windows.Forms.Label lbl3OfAKind;
    }
}

