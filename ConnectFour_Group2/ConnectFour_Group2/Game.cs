using System;
using System.Drawing;
using System.Linq;
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


        public Game(bool botGame)
        {
            InitializeComponent();
			this.botGame = botGame;
			this.reset();

			/* Use this line to change the window title */
			this.Text = botGame ? "Single Player" : "Two Player";

            colPictureBoxes = new PictureBox[] { pictureBox_0, pictureBox_1, pictureBox_2, pictureBox_3, pictureBox_4, pictureBox_5, pictureBox_6 };
        }


        private void RoundButton_Click(object sender, EventArgs e)
        {
			int winner;
			int col;

			col = tableLayoutPanel1.GetColumn((Control)sender);

			/* Note: only executes if the player makes a valid move (according to Board.playMove())! */
			if (gameBoard.playMove(gameDriver.getTurn(), col))
			{
				gameDriver.nextTurn();

				if (botGame)
				{
					lbl_turn.Visible = false;
					gameBoard.playMove(Cell.value.ai, ai.compMove(gameBoard));
					gameDriver.nextTurn();
					lbl_turn.Visible = true;
				}

				/* A bad fix for the chip not updating until the mouse leaves the cell... */
				RoundButton_MouseEnter(sender, null);
			}

			if ((winner = gameBoard.getWinner()) != Board.WINNER_NONE)
			{
                MainForm.load(new GameOver(this, (Cell.value)winner), false);
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
        public void HideTurnLabel()
        {
            lbl_turn.Visible = false;
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
    }
}