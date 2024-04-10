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

			gameBoard.initialize(this.Controls.OfType<RoundButton>());
			gameDriver.setTurn(Cell.value.p1);
            gameBoard.DisplayBoardToConsole();
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
#if DEBUG
				Console.WriteLine(gameBoard.getWinner() + " has won!");
#endif
			}
        }
    }
}