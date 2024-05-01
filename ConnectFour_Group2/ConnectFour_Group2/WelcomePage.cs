//====================================================================================
//Group 2 Names:    Kaylee Busenbark, Mitchell Kosoff, Mitchell Robbins, Jacob Walker
//Date:             4/03/2023
//Desc:             Final Project Connect 4
//====================================================================================


using System;
using System.Windows.Forms;


namespace ConnectFour_Group2
{
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        //SINGLE PLAYER
        private void btn_singlePlayer_Click(object sender, EventArgs e)
        {
			MainForm.load(new Game(true), false);
        }

        //TWO PLAYER
        private void btn_twoPlayer_Click(object sender, EventArgs e)
        {
			MainForm.load(new Game(false), false);
        }

        //STATS
        private void btn_Stats_Click(object sender, EventArgs e)
        {
            //MainForm.load(new Stats());
            Stats formToLoad = new Stats();
            formToLoad.ShowDialog(this);
        }
    }
}
