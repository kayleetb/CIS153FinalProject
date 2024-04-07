using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ConnectFour_Group2
{
    public partial class TwoPlayer : Form
    {
        WelcomePage sform;
        private Board gameBoard;
        private bool isPlayer1Turn = true;
        private RoundButton currentButton;

        /* public TwoPlayer()
        {
            InitializeComponent();
        } */

        public TwoPlayer(WelcomePage sf)
        {
            InitializeComponent();
            sform = sf;
            gameBoard = new Board();

            lbl_turn.Text = "Player 1's Turn";
            lbl_turn.ForeColor = Color.Red;

            setUpGame();
            DisplayBoardToConsole();
        }

        private void TwoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if the x in the corner is pressed it will close the whole application
            Application.Exit();
        }

        private void RoundButton_Click(object sender, EventArgs e)
        {
            RoundButton button = (RoundButton)sender;
            Cell cell = gameBoard.GetCellFromButton(button);
            /* Console.WriteLine("Button Clicked - Row: " + cell.getRow() + ", Col: " + cell.getCol()); */
            if (IsBottomRow(cell))
            {
                if (isPlayer1Turn)
                {
                    button.BackColor = Color.Red;
                    lbl_turn.Text = "Player 2's Turn";
                    lbl_turn.ForeColor = Color.Yellow;
                }
                else
                {
                    button.BackColor = Color.Yellow;
                    lbl_turn.Text = "Player 1's Turn";
                    lbl_turn.ForeColor = Color.Red;
                }
            }
            if(IsCellBelowPressed(cell))
            {
                if(cell.getRow() > 0)
                {
                    Cell cellAbove = gameBoard.getCell(cell.getRow() - 1, cell.getCol());
                    RoundButton buttonAbove = cellAbove.getBtn();
                    buttonAbove.Enabled = true;
                }
                if (isPlayer1Turn)
                {
                    button.BackColor = Color.Red;
                    lbl_turn.Text = "Player 2's Turn";
                    lbl_turn.ForeColor = Color.Yellow;
                }
                else
                {
                    button.BackColor = Color.Yellow;
                    lbl_turn.Text = "Player 1's Turn";
                    lbl_turn.ForeColor = Color.Red;
                } 
            }

            //this will make sure you can't click on buttons that are already pressed
            button.Enabled = false;
            DisplayBoardToConsole();
            isPlayer1Turn = !isPlayer1Turn;
        }

        public bool IsBottomRow(Cell cell)
        {
            return cell.getRow() == gameBoard.getNumRows() - 1;
        }

        public bool IsCellBelowPressed(Cell cell)
        {
            //check if the cell is in the bottom row
            if (cell.getRow() == gameBoard.getNumRows() - 1)
            {
                //if the cell is in the bottom row it will be true
                //because there is no cell below it
                return true;
            }

            if(cell.getRow() < gameBoard.getNumRows() - 1)
            {
                //get the cell below the given cell
                Cell cellBelow = gameBoard.getCell(cell.getRow() + 1, cell.getCol());
                //return true if the cell below has already been pressed
                //now enable the cell above it 
                return !cellBelow.getBtn().Enabled;
            }
            return false;
        }

        public void setUpGame()
        {
            string name;
            char delim = '_';
            int posDelim;
            int col;
            int row;
            Cell c;

            foreach (var button in this.Controls.OfType<RoundButton>())
            {
                name = button.Name;
                posDelim = name.IndexOf(delim);
                row = Int32.Parse(name.Substring(posDelim + 1, 1));
                name = name.Substring(posDelim + 2);
                posDelim = name.IndexOf(delim);
                col = Int32.Parse(name.Substring(posDelim + 1));

                c = new Cell(row, col, button);

                //add that cell to the gameboard
                gameBoard.setGameBoardCell(c);

                //if the cell is not in the bottom row it will be disabled
                //until a cell in the bottom row is selected by a player
                if(!IsBottomRow(c))
                {
                    button.Enabled=false;
                }
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