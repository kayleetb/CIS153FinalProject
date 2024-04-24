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
			new Player(Color.Gray,   "", null),
			new Player(Color.Red,    "Player 1", Properties.Resources.redconnectfourpiece),
			new Player(Color.Yellow, "Player 2", Properties.Resources.yellowconnectfourpiece),
			new Player(Color.Yellow, "Computer", Properties.Resources.yellowconnectfourpiece)
		};
		private Color color;
		private string name;
		private Image backgroundImage;


		public Player(Color c, string n, Image img)
		{
			color = c;
			name = n;
			backgroundImage = img;
		}


		public Color getColor()
		{
			return color;
		}

		public string getName()
		{
			return name;
		}
		public Image getBackgroundImage() 
		{
			return backgroundImage;
		}
	}
}
