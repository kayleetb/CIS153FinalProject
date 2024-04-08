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
            DisplayBoardToConsole();
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
        }


        public void DisplayBoardToConsole()
        {
            for (int row = 0; row < gameBoard.getNumRows(); row++)
            {
                for (int col = 0; col < gameBoard.getNumCols(); col++)
                {
                    Cell cell = gameBoard.getCell(row, col);
                    //player 1's turn
                    if (cell.getBtn().BackColor == Color.Red)
                    {
                        Console.Write("X ");
                    }
                    //player 2's turn
                    else if (cell.getBtn().BackColor == Color.Yellow)
                    {
                        Console.Write("O ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("============================");
        }
    }
}