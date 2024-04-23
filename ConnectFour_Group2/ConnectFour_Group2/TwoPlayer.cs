using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace ConnectFour_Group2
{
    public partial class TwoPlayer : Form
    {
        private WelcomePage sform;
        private Board gameBoard;
		private GameDriver gameDriver;

        public TwoPlayer(WelcomePage sf)
        {
            InitializeComponent();
            sform = sf;
            gameBoard = new Board();
			gameDriver = new GameDriver(lbl_turn);


            gameBoard.initialize(tableLayoutPanel1.Controls.OfType<RoundButton>());
			gameDriver.setTurn(Cell.value.p1);
            //gameBoard.DisplayBoardToConsole();
        }

        private void TwoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if the x in the corner is pressed it will close the whole application
            Application.Exit();
        }


        private void RoundButton_Click(object sender, EventArgs e)
        {
			if (gameBoard.playMove(gameDriver.getTurn(), Board.getCoordFromButton((RoundButton)sender).col))
			{
				gameDriver.nextTurn();
			}

			if (gameBoard.getWinner() != Cell.value.empty)
			{
                //once a player wins we will hide this form and display the gameOver form
                this.Hide();
                loadGameOverForm(gameBoard.getWinner());
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
            
            int col = Board.getCoordFromButton(button).col;
            foreach (RoundButton btn in tableLayoutPanel1.Controls.OfType<RoundButton>())
            {
                if (Board.getCoordFromButton(btn).col == col && gameBoard.getCellFromButton(btn).getVal() == Cell.value.empty)
                {
                    btn.BackColor = Color.DarkGray;
                }
            }
        }

        public void loadGameOverForm(Cell.value winner)
        {
            GameOver formToLoad = new GameOver(this);
            formToLoad.SetGameOutCome(winner);
            formToLoad.Show();
        }

        public Board getBoard()
        {
            return gameBoard;
        }
    }
}