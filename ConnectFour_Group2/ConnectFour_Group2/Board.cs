using System;
using System.Drawing;
using System.Windows.Forms;


namespace ConnectFour_Group2
{
	public struct CoordRC
	{
		public int row, col;
	}

    public class Board
    {
        public const int NUM_ROWS = 6;
        public const int NUM_COLS = 7;
		public const int WINNER_NONE = -1;
        private const int WIN_CONDITION = 4;
		private Cell[,] internalBoard;
		private TableLayoutPanel table;


		public Board(TableLayoutPanel table)
		{
			TableLayoutControlCollection tableCells;
			/* register */ int i;
			this.table = table;

			tableCells = this.table.Controls;

			/* Check to make sure that the table is the same size as our board. */
			if (table.ColumnCount != NUM_COLS || table.RowCount != NUM_ROWS || tableCells.Count != NUM_ROWS * NUM_COLS)
				throw new ArgumentException("TableLayoutPanel argument must have " + NUM_ROWS + " rows and " + NUM_COLS + "columns. Instead, a TableLayoutPanel with " + table.RowCount + " rows and " + table.ColumnCount + " columns was provided.");

			internalBoard = new Cell[NUM_ROWS, NUM_COLS];

			for (i = 0; i < tableCells.Count; ++i)
			{
				TableLayoutPanelCellPosition pos;

				pos = table.GetCellPosition(tableCells[i]);

				tableCells[i].BackgroundImage = null;
				tableCells[i].BackColor = Player.PLAYERS[(int)Cell.value.empty].getColor();
				internalBoard[pos.Row, pos.Column] = new Cell(Cell.value.empty, (RoundButton)tableCells[i]);
			}
		}


        //========GETTERS==========
        public Cell getCell(int r, int c)
        {
            return internalBoard[r, c];
        }

		public TableLayoutPanel getTable()
		{
			return table;
		}

        //========SETTERS==========
        /*
         * playMove: Play Move
         * ARG:	value	Cell.value
         *		col		int
		 * RET:	played	bool
		 * DES:	Attempts to play the move at the given column.
         */
        public bool playMove(Cell.value value, int col) {
#if DEBUG
			Console.WriteLine("playMove(" + value + ", " + col + ")");
#endif

			/* register */ int r;
			RoundButton btn;

            /* Guard against no one trying to play, bad input, and full colum. */
            if (value == Cell.value.empty || col < 0 || col >= NUM_COLS || internalBoard[0, col].getVal() != Cell.value.empty)
                return false;

            /* Find the first instance of a non-empty cell (or the last cell). */
            for (r = 0; r < NUM_ROWS && internalBoard[r, col].getVal() == Cell.value.empty; ++r);

            /* The prior loop overshoots the index by one. */
            --r;

			if (r < 0)
                return false;

			btn = internalBoard[r, col].getBtn();

			internalBoard[r, col].setVal(value);
            btn.BackgroundImageLayout = ImageLayout.Stretch;
			internalBoard[r, col].getBtn().BackgroundImage = Player.PLAYERS[(int)value].getBackgroundImage();
			/* btn.BackgroundImage = Properties.Resources.connectfourpiece_generic;
			btn.BackColor = Player.PLAYERS[(int)value].getColor(); */

            return true;
        }


		/*
		 * getWinner	Get Winner
		 * ARG	NONE
		 * RET	WINNER	int
		 * INF	Find and returns the player who has won. Returns Cell.value.empty if the result is a tie.
		 *		Returns -1 if no winner was found. 
		 */
		public int getWinner()
		{
            Cell cell;
            Cell.value pattern;
            int consecutive;
			/* register */ int r, c;

            /*
             * I'm just going to split up all of the checks across different loops
             * Because I am lazy...
             */

			/* Find ties (a tie occurs when the board is filled). */
			for (consecutive = c = 0; c < NUM_COLS; ++c)
			{
				if (internalBoard[0, c].getVal() != Cell.value.empty)
					++consecutive;
			}

			if (consecutive == NUM_COLS)
				return (int)Cell.value.empty;

            /* VERTICAL */
			for (r = 0; r < NUM_ROWS; ++r)
			{
                pattern = Cell.value.empty;
                for (consecutive = c = 0; c < NUM_COLS; ++c)
                {
					cell = internalBoard[r, c];

                    if (cell.getVal() == Cell.value.empty)
                    {
                        pattern = Cell.value.empty;
                        consecutive = 0;
                        continue;
                    }

                    /* If this is a new pattern, reset count. */
                    if (cell.getVal() != pattern)
                    {
						pattern = cell.getVal();
                        consecutive = 0;
                    }

                    /* Increment regardless of whether or not this is a new pattern. */
					++consecutive;

                    if (consecutive >= WIN_CONDITION)
                    {
                        return (int)pattern;
                    }

                }
			}

            /* HORIZONTAL */
            for (c = 0; c < NUM_COLS; ++c)
            {
                pattern = Cell.value.empty;
                for (consecutive = r = 0; r < NUM_ROWS; ++r)
                {
                    cell = internalBoard[r, c];

                    if (cell.getVal() == Cell.value.empty)
                    {
                        pattern = Cell.value.empty;
                        consecutive = 0;
                        continue;
                    }

                    /* If this is a new pattern, reset count. */
                    if (cell.getVal() != pattern)
                    {
                        pattern = cell.getVal();
                        consecutive = 0;
                    }

                    /* Increment regardless of whether or not this is a new pattern. */
                    ++consecutive;

                    if (consecutive >= WIN_CONDITION)
                        return (int)pattern;
                }
            }

            /* DIAGONAL */
            /* Oh yeah, this is definitely some sleep medicated coding. Fix eventually. */
            for (r = 0; r < NUM_ROWS; ++r)
            {
                for (c = 0; c < NUM_COLS; ++c)
                {
                    int i;

                    /* DIAGONAL - DOWN+RIGHT */
                    pattern = Cell.value.empty;
                    for (consecutive = i = 0; r + i < NUM_ROWS && c + i < NUM_COLS; ++i)
                    {
						cell = internalBoard[r + i, c + i];

						if (cell.getVal() == Cell.value.empty)
						{
							pattern = Cell.value.empty;
							consecutive = 0;
							continue;
						}

                        /* If this is a new pattern, reset count. */
                        if (cell.getVal() != pattern)
                        {
                            pattern = cell.getVal();
                            consecutive = 0;
                        }

						/* Increment regardless of whether or not this is a new pattern. */
                        ++consecutive;

                        if (consecutive >= WIN_CONDITION)
                            return (int)pattern;
                    }

                    /* DIAGONAL - DOWN+LEFT */
                    pattern = Cell.value.empty;
                    for (consecutive = i = 0; r - i >= 0 && c + i < NUM_COLS; ++i)
                    {
                        cell = internalBoard[r - i, c + i];

                        if (cell.getVal() == Cell.value.empty)
                        {
                            pattern = Cell.value.empty;
                            consecutive = 0;
                            continue;
                        }

                        /* If this is a new pattern, reset count. */
                        if (cell.getVal() != pattern)
                        {
                            pattern = cell.getVal();
                            consecutive = 0;
                        }

						/* Increment regardless of whether or not this is a new pattern. */
                        ++consecutive;

                        if (consecutive >= WIN_CONDITION)
                            return (int)pattern;
                    }
                }
            }

            /* No winner was found. */
            return -1;
		}



        /*
		 * initialize	Initialize
		 * ARG	NONE
		 * RET	NONE
		 * INF	Initializes all cells in the Board with their RoundButtons.
		 */
        /* public void initialize()
        {
            Cell c;
            CoordRC coord;

            foreach (var button in buttons)
            {
				button.BackgroundImage = null;
				coord = 
                c = new Cell(Cell.value.empty, button);

				internalBoard[coord.row, coord.col] = new Cell(Cell.value.empty, button);
            }

        } */

        public void disableAllCells()
        {
			table.Enabled = false;
            /* foreach (Cell cell in internalBoard)
            {
                cell.getBtn().Enabled = false;
            } */
        }

        /*
		 * DisplayBoardToConsole	Display Board to Console
		 * ARG	NONE
		 * RET	NONE
		 * INF	Prints all cells and their current values to STDOUT.
		 */
        public void DisplayBoardToConsole()
        {
            string buf;

            buf = "";

            for (int col = 0; col < Board.NUM_COLS; col++)
            {
                for (int row = 0; row < Board.NUM_ROWS; row++)
                {
                    switch (this.getCell(row, col).getVal())
                    {
                        case Cell.value.p1:
                            buf += 'X';
                            break;
                        case Cell.value.p2:
                            buf += 'O';
                            break;
                        default:
                            buf += ' ';
                            break;
                    }

                    buf += " \n";
                }

            }

			buf += "\n============================\n";

            Console.Write(buf);
        }
    }
}
