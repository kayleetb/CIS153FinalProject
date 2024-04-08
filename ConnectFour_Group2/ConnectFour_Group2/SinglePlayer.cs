using System.Linq;
using System.Windows.Forms;

namespace ConnectFour_Group2
{
    public partial class SinglePlayer : Form
    {
        WelcomePage sform;
        private Board gameBoard;
        private bool isPlayer1Turn = true;
        public SinglePlayer()
        {
            InitializeComponent();
        }
        public SinglePlayer(WelcomePage sf)
        {
            InitializeComponent();
            sform = sf;
            gameBoard = new Board();
			/* setUpGame(); */
			gameBoard.initialize(this.Controls.OfType<RoundButton>());
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
