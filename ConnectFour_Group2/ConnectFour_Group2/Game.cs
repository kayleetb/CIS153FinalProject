using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConnectFour_Group2
{
    public partial class Game : Form
    {
        private Board gameBoard;
		private GameDriver gameDriver;
		private Computer ai;
		private bool botGame;
        private PictureBox[] colPictureBoxes;
		private bool isReviewing = true;
		private bool playerCanPlay;


        public Game(bool botGame)
        {
            InitializeComponent();
			this.botGame = botGame;
			this.reset();

			/* Use this line to change the window title */
			this.Text = botGame ? "Single Player" : "Two Player";
			playerCanPlay = true;

            colPictureBoxes = new PictureBox[] { pictureBox_0, pictureBox_1, pictureBox_2, pictureBox_3, pictureBox_4, pictureBox_5, pictureBox_6 };
        }


        private async void RoundButton_Click(object sender, EventArgs e)
        {
			int winner;
			int col;

			if (!playerCanPlay)
				return;

			col = tableLayoutPanel1.GetColumn((Control)sender);

			/* Note: only executes if the player makes a valid move (according to Board.playMove())! */
			if (gameBoard.playMove(gameDriver.getTurn(), col))
			{
				gameDriver.nextTurn();

				if ((winner = gameBoard.getWinner()) != Board.WINNER_NONE)
					MainForm.load(new GameOver(this, (Cell.value)winner), false);

				/* Begin the bot's turn. */
				if (botGame)
				{
					playerCanPlay = false;
					await Task.Delay(667);

					gameBoard.playMove(Cell.value.ai, ai.compMove(gameBoard));
					gameDriver.nextTurn();

					playerCanPlay = true;

					if ((winner = gameBoard.getWinner()) != Board.WINNER_NONE)
						MainForm.load(new GameOver(this, (Cell.value)winner), false);
				}
                colPictureBoxes[col].BackgroundImage = Player.PLAYERS[(int)gameDriver.getTurn()].getBackgroundImage();

            }

        }

        private void RoundButton_MouseEnter(object sender, EventArgs e)
        {
			int r, c;

			c = gameBoard.getTable().GetColumn((Control)sender);

			if (c < 0)
				return;

			for (r = 0; r < Board.NUM_ROWS; ++r)
				if (gameBoard.getCell(r, c).getVal() == Cell.value.empty)
					gameBoard.getCell(r, c).getBtn().BackColor = Color.White;

			if (playerCanPlay)
				colPictureBoxes[c].BackgroundImage = Player.PLAYERS[(int)gameDriver.getTurn()].getBackgroundImage();
        }

        private void RoundButton_MouseLeave(object sender, EventArgs e)
        {
			int r, c;

			c = gameBoard.getTable().GetColumn((Control)sender);

			if (c < 0)
				return;

			for (r = 0; r < Board.NUM_ROWS; ++r)
				if (gameBoard.getCell(r, c).getVal() == Cell.value.empty)
					gameBoard.getCell(r, c).getBtn().BackColor = Player.PLAYERS[(int)Cell.value.empty].getColor();

			/* Clear the hover chip. */
			colPictureBoxes[c].BackgroundImage = null;
        }
        public void hideTurnLabel()
        {
            lbl_turn.Visible = false;
        }
		public void showTurnLabel()
		{
			lbl_turn.Visible = true;
		}

        /*
		 * reset	Reset
		 * ARG		NONE
		 * RET		NONE
		 * DES		Resets the game to starting conditions.
		 */
        public void reset()
		{
			gameBoard = new Board(tableLayoutPanel1);
			gameDriver = new GameDriver(lbl_turn);

			if (this.botGame)
				ai = new Computer();

			gameDriver.setTurn(Cell.value.p1);

			tableLayoutPanel1.Refresh();
		}

		public bool getBotGame()
		{
			return botGame;
		}

        public Board getBoard()
        {
            return gameBoard;
        }

		public bool isBotGame()
		{
			return botGame;
		}
		public void setIsReviewing(bool value)
		{
			isReviewing = value;
		}

        private void btn_Back_Click(object sender, EventArgs e)
        {
			//if the game is NOT being reviewed we want to go back to the welcome page
			//if the game is being reviewed we want to go back to the gameover form 	

			if(isReviewing)
			{
                MainForm.loadPrevious();
                this.Hide();
            }
      
			else
			{
				MainForm.load(new WelcomePage(), false);
			}
		}

    }
}