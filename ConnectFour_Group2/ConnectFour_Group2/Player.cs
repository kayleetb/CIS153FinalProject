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
			new Player(Color.Transparent,   "", Properties.Resources.graybackground),
			new Player(Color.Firebrick,"P L A Y E R   1", Properties.Resources.redconnectfourpiece),
			new Player(Color.Gold, "P L A Y E R   2", Properties.Resources.yellowconnectfourpiece),
			new Player(Color.Gold, "C O M P U T E R", Properties.Resources.yellowconnectfourpiece)
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
