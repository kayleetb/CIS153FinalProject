﻿using System;
using System.IO;
using System.Windows.Forms;


namespace ConnectFour_Group2
{
    public partial class Stats : Form
    {
		private const string PATH_SAVE = "../../Stats.txt";
        private int game;

        public Stats()
        {
            InitializeComponent();
			readTextFile();
        }

        private void readTextFile()
        {
			StreamReader file;
			String line;

            string gamesPlayed = "0";
            string winner = "";
            int p1Wins = 0;
            int aiWins = 0;
            int ties = 0;
            int intGames = 0;

            int comma;
            char delim = ',';

			if (!File.Exists(PATH_SAVE))
				File.Create(PATH_SAVE).Close();

			file = new StreamReader(PATH_SAVE);

            line = file.ReadLine();
            while ((line = file.ReadLine()) != null)
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
            }
            file.Close();

            label4.Text = p1Wins.ToString();
            label5.Text = ties.ToString();
            label6.Text = aiWins.ToString();

            label12.Text = gamesPlayed;

            double p1WinPercent = (((double)p1Wins) / ((double)intGames)) * 100;
            p1WinPercent = Math.Round(p1WinPercent, 2);
            Console.WriteLine("p1 win %: " + p1Wins + " / " + intGames + " = " + p1WinPercent);
            double aiWinPercent = (((double)aiWins) / ((double)intGames)) * 100;
            aiWinPercent = Math.Round(aiWinPercent, 2);
            Console.WriteLine("ai win %: " + aiWins + " / " + intGames + " = " + aiWinPercent);

            label10.Text = p1WinPercent.ToString() + "%";
            label11.Text = aiWinPercent.ToString() + "%";
        }
        
        public int getGame() 
        {
            StreamReader file = new StreamReader(PATH_SAVE);
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
