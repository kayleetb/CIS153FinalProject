using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace ConnectFour_Group2
{
    public partial class TwoPlayer : Form
    {
        private Board gameBoard;
		private GameDriver gameDriver;
		private Computer ai;
		private bool botGame;


        public TwoPlayer(bool botGame)
        {
            InitializeComponent();
			this.botGame = botGame;
			this.reset();
        }


        private void TwoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if the x in the corner is pressed it will close the whole application
            Application.Exit();
        }


        private void RoundButton_Click(object sender, EventArgs e)
        {
			Cell.value winner;

			/* Note: only executes if the player makes a valid move (according to Board.playMove())! */
			if (gameBoard.playMove(gameDriver.getTurn(), Board.getCoordFromButton((RoundButton)sender).col))
			{
				gameDriver.nextTurn();

				if (botGame)
				{
					lbl_turn.Visible = false;
					ai.compMove(gameBoard);
					lbl_turn.Visible = true;
				}
			}

			if ((winner = gameBoard.getWinner()) != Cell.value.empty)
			{
				MainForm.load(new GameOver(this, winner));
			}
        }
        private void RoundButton_MouseEnter(object sender, EventArgs e)
        {
            RoundButton button = (RoundButton)sender;
            Cell cell = gameBoard.getCellFromButton(button);
            if (cell.getVal() == Cell.value.empty)
            {
                int col = Board.getCoordFromButton(button).col;
                foreach (RoundButton btn in tableLayoutPanel1.Controls.OfType<RoundButton>())
                {
                    if (Board.getCoordFromButton(btn).col == col && gameBoard.getCellFromButton(btn).getVal() == Cell.value.empty)
                    {
                        btn.BackColor = Color.White;
                    }
                }
            }
        }

        private void RoundButton_MouseLeave(object sender, EventArgs e)
        {
            RoundButton button = (RoundButton)sender;
            Cell cell = gameBoard.getCellFromButton(button);

            if (cell.getVal() == Cell.value.empty)
            {
                int col = Board.getCoordFromButton(button).col;
                foreach (RoundButton btn in tableLayoutPanel1.Controls.OfType<RoundButton>())
                {
                    if (Board.getCoordFromButton(btn).col == col && gameBoard.getCellFromButton(btn).getVal() == Cell.value.empty)
                    {
                        btn.BackColor = Color.DarkGray;
                    }
                }
            }
        }


		/*
		 * reset	Reset
		 * ARG		NONE
		 * RET		NONE
		 * DES		Resets the game to starting conditions.
		 */
		public void reset()
		{
			gameBoard = new Board();
			gameDriver = new GameDriver(lbl_turn);

			if (this.botGame)
				ai = new Computer();

            gameBoard.initialize(tableLayoutPanel1.Controls.OfType<RoundButton>());
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
    }
}