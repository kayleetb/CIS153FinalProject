using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectFour_Group2
{
	public struct CoordRC
	{
		public int row, col;
	}

    public class Board
    {
        private const int NUM_ROWS = 6;
        private const int NUM_COLS = 7;
        private const int WIN_CONDITION = 4;
        private Cell[,] gameBoard = new Cell[NUM_ROWS, NUM_COLS];


        //========GETTERS==========
        public int getNumRows()
        {
            return NUM_ROWS;
        }
        public int getNumCols()
        {
            return NUM_COLS;
        }

        public Cell getCell(int r, int c)
        {
            //Console.WriteLine("Getting Cell - Row: " + r + ", Col: " + c);
            return gameBoard[r, c];
        }

        public Cell[,] getGameBoard()
        {
            return gameBoard;
        }

		public Cell getCellFromButton(RoundButton button)
        {
			CoordRC coord;

			coord = Board.getCoordFromButton(button);

            return gameBoard[coord.row, coord.col];
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
            gameBoard[row, col] = cell;
        }
        

        /*
         * playMove: Play Move
         * ARG:	value	Cell.value
         *		col		int
		 * RET:	played	bool
		 * DES:	Attempts to play the move at the given column.
         */
        public bool playMove(Cell.value value, int col)
        {
            /* register */ int r;

            for (r = 0; r < NUM_ROWS; ++r)
            {
                if (gameBoard[r, col].getVal() != Cell.value.empty)
                    break;
            }

            /* The prior loop overshoots the index by one. */
            --r;

            if (r < 0)
                return false;

            gameBoard[r, col].setVal(value);

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
                    cell = gameBoard[r, c];

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
                    cell = gameBoard[r, c];

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
						cell = gameBoard[r + i, c + i];

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
                        cell = gameBoard[r - i, c + i];

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
            /* string name;
            char delim = '_';
            int posDelim;
            int col;
            int row; */
            Cell c;
			CoordRC coord;

            foreach (var button in buttons)
            {
				coord = Board.getCoordFromButton(button);
				c = new Cell(Cell.value.empty, button);

				this.setGameBoardCell(c, coord.row, coord.col);

                //if the cell is not in the bottom row it will be disabled
                //until a cell in the bottom row is selected by a player
                /* if(!IsBottomRow(c))
                {
                    button.Enabled=false;
                } */
            }

		}
    }
}
