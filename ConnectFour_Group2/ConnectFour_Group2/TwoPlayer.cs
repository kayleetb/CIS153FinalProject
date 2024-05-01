using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;


namespace ConnectFour_Group2
{
    public partial class TwoPlayer : Form
    {
        private WelcomePage sform;
        private Board gameBoard;
		private GameDriver gameDriver;
        private PictureBox[] colPictureBoxes;

        public TwoPlayer(WelcomePage sf)
        {
            InitializeComponent();
            sform = sf;
            gameBoard = new Board();
			gameDriver = new GameDriver(lbl_turn);


            gameBoard.initialize(tableLayoutPanel1.Controls.OfType<RoundButton>());
			gameDriver.setTurn(Cell.value.p1);
            //gameBoard.DisplayBoardToConsole();


            //needs to be moved to work with both board but i have it here right now just to work with it
            colPictureBoxes = new PictureBox[] { pictureBox_0, pictureBox_1, pictureBox_2, pictureBox_3, pictureBox_4, pictureBox_5, pictureBox_6 };

            //pictureBox_3.BackgroundImage = Player.PLAYERS[(int)gameDriver.getTurn()].getBackgroundImage();
            //pictureBox_3.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void TwoPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if the x in the corner is pressed it will close the whole application
            Application.Exit();
        }


        private void RoundButton_Click(object sender, EventArgs e)
        {
            RoundButton button = (RoundButton)sender;

            int col = Board.getCoordFromButton(button).col;

            if (gameBoard.playMove(gameDriver.getTurn(), Board.getCoordFromButton((RoundButton)sender).col))
			{
				gameDriver.nextTurn();
                UpdateColumnPictureBox(col);
                colPictureBoxes[col].BackgroundImage = Player.PLAYERS[(int)gameDriver.getTurn()].getBackgroundImage();
                colPictureBoxes[col].BackgroundImageLayout = ImageLayout.Stretch;
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
            if (cell.getVal() == Cell.value.empty || cell.getVal() == Cell.value.p1 || cell.getVal() == Cell.value.p2)
            {
                int col = Board.getCoordFromButton(button).col;
                foreach (RoundButton btn in tableLayoutPanel1.Controls.OfType<RoundButton>())
                {
                    if (Board.getCoordFromButton(btn).col == col && gameBoard.getCellFromButton(btn).getVal() == Cell.value.empty)
                    {
                        btn.BackColor = Color.White;

                        colPictureBoxes[col].BackgroundImage = Player.PLAYERS[(int)gameDriver.getTurn()].getBackgroundImage();
                        colPictureBoxes[col].BackgroundImageLayout = ImageLayout.Stretch;
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
                    UpdateColumnPictureBox(col);
                }
            
            }
        }

        private void UpdateColumnPictureBox(int col)
        {
            colPictureBoxes[col].BackgroundImage = null;
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