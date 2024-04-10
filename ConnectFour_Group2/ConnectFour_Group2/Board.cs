using System;
using System.Collections.Generic;


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
        private const int WIN_CONDITION = 4;
        private Cell[,] internalBoard = new Cell[NUM_ROWS, NUM_COLS];


        //========GETTERS==========
        public Cell getCell(int r, int c)
        {
            //Console.WriteLine("Getting Cell - Row: " + r + ", Col: " + c);
            return internalBoard[r, c];
        }

        public Cell[,] getGameBoard()
        {
            return internalBoard;
        }

		public Cell getCellFromButton(RoundButton button)
        {
			CoordRC coord;

			coord = Board.getCoordFromButton(button);

            return internalBoard[coord.row, coord.col];
        }

		/*
		 * getCoordFromButton:	Get Coord From Button
		 * ARG:	button	RoundButton
		 * RET:	coord	CoordRC
		 * DES:	Uses the name of the RoundButton control to find it's coordinates.
		 */
		public static CoordRC getCoordFromButton(RoundButton button)
		{
			const char DELIM = '_';
			CoordRC coord;
			string name;
			int posDelim;

			coord = new CoordRC();

            name = button.Name;
            posDelim = name.IndexOf(DELIM);
            coord.row = Int32.Parse(name.Substring(posDelim + 1, 1));
            name = name.Substring(posDelim + 2);
            posDelim = name.IndexOf(DELIM);
            coord.col = Int32.Parse(name.Substring(posDelim + 1));

			/* coord.row = button.row;
			coord.col = button.col; */

			return coord;
		}

        //========SETTERS==========
        public void setGameBoardCell(Cell cell, int row, int col)
        {
            internalBoard[row, col] = cell;
        }
        

        /*
         * playMove: Play Move
         * ARG:	value	Cell.value
         *		col		int
		 * RET:	played	bool
		 * DES:	Attempts to play the move at the given column.
         */
        public bool playMove(Cell.value value, int col) {
			Console.WriteLine("playMove(" + value + ", " + col + ")");

			/* register */
			int r;

			/* Guard against no one trying to play. */
			if (value == Cell.value.empty)
				return false;

			/* Find the first instance of a non-empty cell (or the last cell). */
			for (r = 0; r < NUM_ROWS && internalBoard[r, col].getVal() == Cell.value.empty; ++r) ;

            /* The prior loop overshoots the index by one. */
			/* Apparently not?? */
            --r;

			Console.WriteLine("PLAYMOVE: r = " + r);

			if (r < 0)
                return false;

			Console.WriteLine("PLAYMOVE: r = " + r);

            internalBoard[r, col].setVal(value);
			internalBoard[r, col].getBtn().BackColor = Player.PLAYERS[(int)value].getColor();

            return true;
        }

		/*
		 * WARNING: THIS HAS NOT BEEN PROPERLY TESTED YET.
		 */
		public Cell.value getWinner()
		{
            Cell cell;
            Cell.value pattern;
            int consecutive;
			/* register */ int r, c;

            /*
             * I'm just going to split up all of the checks across different loops
             * Because I am lazy...
             */

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
						return pattern;
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
                        return pattern;
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
                            return pattern;
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
                            return pattern;
                    }
                }
            }

            /* No winner was found. */
            return Cell.value.empty;
		}

		public void initialize(IEnumerable<RoundButton> buttons)
		{
            Cell c;
			CoordRC coord;

            foreach (var button in buttons)
            {
				coord = Board.getCoordFromButton(button);
				c = new Cell(Cell.value.empty, button);

				this.setGameBoardCell(c, coord.row, coord.col);
            }

		}
    }
}
