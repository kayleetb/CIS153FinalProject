using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group2
{
    public partial class Stats : Form
    {
        private int game;

        WelcomePage sform;
        public Stats()
        {
            InitializeComponent();
        }
        public Stats(WelcomePage sf)
        {
            InitializeComponent();
            readTextFile();
            sform = sf;
        }

        private void Stats_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if the x in the corner is pressed it will close the whole application
            Application.Exit();
        }

        private void readTextFile()
        {
            StreamReader file = new StreamReader("../../Stats.txt");
            String line = file.ReadLine();

            string gamesPlayed = "0";
            string winner = "";
            int p1Wins = 0;
            int aiWins = 0;
            int ties = 0;
            int intGames = 0;

            int comma;
            char delim = ',';

            line = file.ReadLine();
            while (line != null)
            {
                comma = line.IndexOf(delim);
                gamesPlayed = line.Substring(0, comma);

                line = line.Substring(comma + 1);
                comma = line.IndexOf(delim);
                winner = line.Substring(0, comma);

                if (winner == "p1")
                {
                    p1Wins++;
                    intGames++;
                }
                else if (winner == "ai")
                {
                    aiWins++;
                    intGames++;
                }
                else if (winner == "tie")
                {
                    ties++;
                    intGames++;
                }

                line = file.ReadLine();
            }
            file.Close();

            label4.Text = p1Wins.ToString();
            label5.Text = ties.ToString();
            label6.Text = aiWins.ToString();

            label12.Text = gamesPlayed;

            double p1WinPercent = (p1Wins / intGames) * 100;
            Console.WriteLine("p1 win %: " + p1Wins + " / " + intGames + " = " + p1WinPercent);
            double aiWinPercent = (aiWins / intGames) * 100;
            Console.WriteLine("ai win %: " + aiWins + " / " + intGames + " = " + aiWinPercent);

            label10.Text = p1WinPercent.ToString() + "%";
            label11.Text = aiWinPercent.ToString() + "%";
        }
        
        public int getGame() 
        {
            StreamReader file = new StreamReader("../../Stats.txt");
            String line = file.ReadLine();

            string gamesPlayed = "0";
            string winner = "";

            int comma;
            char delim = ',';

            line = file.ReadLine();
            while (line != null)
            {
                comma = line.IndexOf(delim);
                gamesPlayed = line.Substring(0, comma);

                line = line.Substring(comma + 1);
                comma = line.IndexOf(delim);
                winner = line.Substring(0, comma);

                line = file.ReadLine();
            }
            file.Close();

            int games = Convert.ToInt32(gamesPlayed);

            return games + 1;
        }
    }
}
