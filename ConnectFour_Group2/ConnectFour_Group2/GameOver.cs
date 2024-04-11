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
    public partial class GameOver : Form
    {
        private Cell.value winner;
        private Form previousForm;
        private Board gameBoard;

        public GameOver(Form parentForm)
        {
            InitializeComponent();
            previousForm = parentForm;
        }
        private void GameOver_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if the x in the corner is pressed it will close the whole application
            Application.Exit();
        }


        //this will have to be changed once single player is finished
        public void SetGameOutCome(Cell.value winner) 
        {
            this.winner = winner;

            if(winner == Cell.value.p1)
            {
                lbl_gameOutCome.Text = "Player 1 has won!";
            }
            else if(winner == Cell.value.p2) 
            {
                lbl_gameOutCome.Text = "Player 2 has won!";
            }
            else
            {
                lbl_gameOutCome.Text = "It's a draw!";
            }
        }

        private void btn_reviewGame_Click(object sender, EventArgs e)
        {
            previousForm.Show();
        }

        private void btn_playAgain_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousForm.Hide();

        }
    }
}
