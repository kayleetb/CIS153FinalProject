using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace ConnectFour_Group2
{
    public partial class GameOver : Form
    {
		private Game gameForm;
        private Stats stats;
        private GameDriver driver;


        public GameOver(Game gameForm, Cell.value winner)
        {
            InitializeComponent();

			this.gameForm = gameForm;

			/* Potentially implement a new variable in the Player class for victory statement. */
			File.AppendAllText(Stats.PATH_SAVE, "\r\n" + Stats.getGame() + "," + (int)winner + ",");
            SetVictoryStatment(winner);
        }
        public void SetVictoryStatment(Cell.value winner)
        {
            switch (winner)
            {
                case Cell.value.p1:
                case Cell.value.p2:
                    lbl_gameOutcome.Text = Player.PLAYERS[(int)winner].getName() + "  W O N !";
                    break;

                //case Cell.value.tie:
                //    lbl_gameOutcome.Text = "It's a Tie!";
                //    break;

                case Cell.value.ai:
                    lbl_gameOutcome.Text = "You Lost";
                    lbl_gameOutcome.BackColor = Color.Red;
                    break;
            }
            //if (gameForm.getBoard().isBoardFull())
            //{
            //}

        }

        /* WARNING: UNABLE TO RETURN BACK TO ANY OTHER SCREEN! */
        private void btn_reviewGame_Click(object sender, EventArgs e)
        {
            gameForm.getBoard().disableAllCells();
            MainForm.load(gameForm, true);
            gameForm.HideTurnLabel();
        }

        private void btn_playAgain_Click(object sender, EventArgs e)
        {
			gameForm.reset();
			MainForm.load(gameForm, false);
        }

        //STATS
        private void btn_StatsGO_Click(object sender, EventArgs e)
        {
            MainForm.load(new Stats(), false);
        }
    }
}
