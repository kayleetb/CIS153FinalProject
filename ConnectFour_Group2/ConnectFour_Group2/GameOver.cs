using System;
using System.IO;
using System.Windows.Forms;


namespace ConnectFour_Group2
{
    public partial class GameOver : Form
    {
		private TwoPlayer gameForm;


        public GameOver(TwoPlayer gameForm, Cell.value winner)
        {
            InitializeComponent();

			this.gameForm = gameForm;

			/* Potentially implement a new variable in the Player class for victory statement. */
			lbl_gameOutcome.Text = Player.PLAYERS[(int)winner].getName() + " has won!";
        }


		/* WARNING: UNABLE TO RETURN BACK TO ANY OTHER SCREEN! */
        private void btn_reviewGame_Click(object sender, EventArgs e)
        {
            gameForm.getBoard().disableAllCells();
			MainForm.load(gameForm);
        }

        private void btn_playAgain_Click(object sender, EventArgs e)
        {
			gameForm.reset();
			MainForm.load(gameForm);
        }

        //STATS
        private void btn_StatsGO_Click(object sender, EventArgs e)
        {
			Stats formToLoad = new Stats();
			formToLoad.ShowDialog(this);
        }
    }
}
