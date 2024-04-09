using System.Drawing;


namespace ConnectFour_Group2
{
	/*
	 * Holds information about a player including their name and color.
	 * Variables are only able to be set in the constructor.
	 */
	public class Player
	{
		/* Array should potentially be held in GameDriver. */
		/* This array should be as long as there are entries in Cell.value. */
		public static readonly Player[] PLAYERS =
		{
			new Player(Color.Gray,   ""),
			new Player(Color.Red,    "Player 1"),
			new Player(Color.Yellow, "Player 2")
		};
		private Color color;
		private string name;


		public Player(Color c, string n)
		{
			color = c;
			name = n;
		}


		public Color getColor()
		{
			return color;
		}

		public string getName()
		{
			return name;
		}
	}
}
