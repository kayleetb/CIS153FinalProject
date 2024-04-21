using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ConnectFour_Group2
{
    public partial class SinglePlayer : Form
    {
        WelcomePage sform;
        private Board gameBoard;
        private bool isPlayer1Turn = true;
        Computer ai;
       
        public SinglePlayer(WelcomePage sf)
        {
            InitializeComponent();
            sform = sf;
            ai = new Computer();
            gameBoard = new Board();
            /* setUpGame(); */
            gameBoard.initialize(tableLayoutPanel1.Controls.OfType<RoundButton>());
            //DisplayBoardtoConsole(); for testing
        }
        /* public void setUpGame()
        {
            string name;
            char delim = '_';
            int posDelim;
            int col;
            int row;
            Cell c;
            foreach(var button in this.Controls.OfType<RoundButton>())
            {
                name = button.Name;
                posDelim = name.IndexOf(delim);
                row = Int32.Parse(name.Substring(posDelim + 1, 1));
                name = name.Substring(posDelim + 2);
                posDelim = name.IndexOf(delim);
                col = Int32.Parse(name.Substring(posDelim + 1));

                c = new Cell(row, col, button);
                gameBoard.setGameBoardCell(c);
            }
        } */
        private void SinglePlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if the x in the corner is pressed it will close the whole application
            Application.Exit();
        }

       
        
        
        
        private void RoundButton_Click(object sender, System.EventArgs e)
        {
            if(isPlayer1Turn)
            {
                lbl_turn.Visible = true;

                gameBoard.playMove(Cell.value.p1, Board.getCoordFromButton((RoundButton)sender).col);

                if (gameBoard.getWinner() != Cell.value.empty)
                {
                    this.Hide();
                    loadGameOverForm(gameBoard.getWinner());
                }

                isPlayer1Turn=false;
                lbl_turn.Visible = false;

            }

            //maybe needs different placement?
            //Thread.Sleep(3000);

            if (!isPlayer1Turn) 
            {

                ai.compMove(gameBoard);

                if (gameBoard.getWinner() != Cell.value.empty)
                {
                    this.Hide();
                    loadGameOverForm(gameBoard.getWinner());
                }

                isPlayer1Turn = true;
                lbl_turn.Visible = true;


            }
        }



        public void loadGameOverForm(Cell.value winner)
        {
            GameOver formToLoad = new GameOver(this);
            formToLoad.SetGameOutCome(winner);
            formToLoad.Show();
        }

        //just testing with this
        //public void DisplayBoardtoConsole()
        //{
        //    for (int row = 0; row < gameBoard.getNumRows(); row++)
        //    {
        //        for (int col = 0; col < gameBoard.getNumCols(); col++)
        //        {
        //            Cell cell = gameBoard.getCell(row, col);
        //            Console.Write("- ");

        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}
