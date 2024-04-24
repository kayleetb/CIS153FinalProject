using System.Windows.Forms;


namespace ConnectFour_Group2
{
	/*
	 * GameDriver should hold information related to the game that isn't applicable to the board.
	 * For example, the board does not need to know who's turn it is, but it should know what to do when a player presses a button (which the GameDriver does not need to know).
	 */
    public class GameDriver
    {
		private Label lbl_turn;
		private Cell.value currentTurn;


		public GameDriver(Label lbl_turn)
		{
			this.lbl_turn = lbl_turn;
			this.setTurn(Cell.value.empty);
		}


		public Cell.value getTurn()
		{
			return currentTurn;
		}

		public void setTurn(Cell.value turn)
		{
			currentTurn = turn;
			lbl_turn.Text = Player.PLAYERS[(int)currentTurn].getName() + "'s Turn";
			lbl_turn.ForeColor = Player.PLAYERS[(int)currentTurn].getColor();
		}

		/*
		 * nextTurn:	Next Turn
		 * ARG:			NONE
		 * RET:			bool	SUCCESS
		 * DES:			Increments the turn. If the turn is GameDriver.turn.none, do nothing.
		 */
		public bool nextTurn()
		{
			switch (currentTurn)
			{
				case Cell.value.empty:
					return false;
				case Cell.value.p1:
					this.setTurn(Cell.value.p2);
					break;
				case Cell.value.p2:
					this.setTurn(Cell.value.p1);
					break;
			}

			return true;
		}
    }
} 