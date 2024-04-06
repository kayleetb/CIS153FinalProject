//====================================================================================
//Group 2 Names:    Kaylee Busenbark, Mitchell Kosoff, Mitchell Robbins, Jacob Walker
//Date:             4/03/2023
//Desc:             Final Project Connect 4
//====================================================================================

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
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        //SINGLE PLAYER
        private void btn_singlePlayer_Click(object sender, EventArgs e)
        {
            loadSinglePlayerForm();
            this.Hide();
        }
        public void loadSinglePlayerForm()
        {
            SinglePlayer formToLoad = new SinglePlayer(this);
            formToLoad.Show();
        }

        //TWO PLAYER
        private void btn_twoPlayer_Click(object sender, EventArgs e)
        {
            loadTwoPlayerForm();
            this.Hide();
        }
        public void loadTwoPlayerForm()
        {
            TwoPlayer formToLoad = new TwoPlayer(this);
            formToLoad.Show();
        }

        //STATS
        private void btn_Stats_Click(object sender, EventArgs e)
        {
            loadStatsForm();
            this.Hide();
        }
        public void loadStatsForm()
        {
            Stats formToLoad = new Stats(this);
            formToLoad.Show();
        }
    }
}
