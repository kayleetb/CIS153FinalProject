using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group2
{
    public partial class SinglePlayer : Form
    {
        private Board gameBoard;
        WelcomePage sform;
        public SinglePlayer()
        {
            InitializeComponent();
        }
        public SinglePlayer(WelcomePage sf)
        {
            InitializeComponent();
            sform = sf;
            gameBoard = new Board();
            setUpGame();
        }
        public void setUpGame()
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
        }
    }
}
