﻿using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Security.Cryptography;
using System.Windows.Forms;
using ConnectFour_Group2.Properties;


namespace ConnectFour_Group2
{
    public partial class GameOver : Form
    {
		private Game gameForm;
        private Stats stats;
        private GameDriver driver;
        
        Stream soundFile;
        SoundPlayer player;

        public GameOver(Game gameForm, Cell.value winner)
        {
            InitializeComponent();

			this.gameForm = gameForm;
            
            if(gameForm.isBotGame())
            {
                /* Potentially implement a new variable in the Player class for victory statement. */
                File.AppendAllText(Stats.PATH_SAVE, "\r\n" + Stats.getGame() + "," + (int)winner + ",");
            }
            SetVictoryStatment(winner);

        }
        public void SetVictoryStatment(Cell.value winner)
        {
            switch (winner)
            {
                case Cell.value.p1:
                case Cell.value.p2:
                    lbl_gameOutcome.Text = Player.PLAYERS[(int)winner].getName() + "  W O N !";
                    lbl_gameOutcome.Location = new Point(121, 116);
                    break;

                case Cell.value.ai:
                    lbl_gameOutcome.Text = "Y O U  L O S T !";
                    lbl_gameOutcome.BackColor = Color.Red;
                    lbl_gameOutcome.Location = new Point(172, 113);
                    break;

                case Cell.value.empty:
                    lbl_gameOutcome.Text = "I T ' S  A  T I E !";
                    lbl_gameOutcome.Location = new Point(172, 113);
                    break; 
            }

        }

        private void btn_reviewGame_Click(object sender, EventArgs e)
        {
            gameForm.getBoard().disableAllCells();
            gameForm.setIsReviewing(true);
            MainForm.load(gameForm, true);
            gameForm.hideTurnLabel();
        }

        private void btn_playAgain_Click(object sender, EventArgs e)
        {
            soundFile = Properties.Resources.chipsFalling;
            player = new SoundPlayer(soundFile);
            playSound();

            gameForm.getBoard().enableAllCells();
            gameForm.showTurnLabel();
            gameForm.reset();
            gameForm.setIsReviewing(false);
			MainForm.load(gameForm, false);
        }

        private void playSound()
        {
            player.Play();
        }

        //STATS
        private void btn_StatsGO_Click(object sender, EventArgs e)
        {
            MainForm.load(new Stats(), false);
        }
    }
}
