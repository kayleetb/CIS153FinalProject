using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectFour_Group2
{
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
        //Maybe I want to be able to get an individual cell from the gameboard given row and col
        public Cell getCell(int r, int c)
        {
            //Console.WriteLine("Getting Cell - Row: " + r + ", Col: " + c);
            return gameBoard[r, c];
        }

        //Maybe we want to be able to view the entire board not just a cell
        public Cell[,] getGameBoard()
        {
            return gameBoard;
        }

        //========SETTERS==========
        public void setGameBoardCell(Cell cell, int row, int col)
        {
            gameBoard[row, col] = cell;
        }
        public Cell GetCellFromButton(RoundButton button)
        {
            string name = button.Name;
            char delim = '_';
            int posDelim = name.IndexOf(delim);
            int row = Int32.Parse(name.Substring(posDelim + 1, 1));
            name = name.Substring(posDelim + 2);
            posDelim = name.IndexOf(delim);
            int col = Int32.Parse(name.Substring(posDelim + 1));

            return gameBoard[row, col];
        }

        /*
         * playMove: Play Move
         * Arg
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
    }
}
