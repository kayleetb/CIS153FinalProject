using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS153_03_30_2021_Connect4Helper
{
    class Board
    {
        //this should be 6x7 but for this simple example I am just going to make this 2x2
        private const int numRows = 2;
        private const int numCols = 2;
        Cell[,] gameBoard = new Cell[numRows,numCols];
        //I am going to put some other things down here that might be nice to have part of this class
        //However you could even have these in a different class called GameDriver.cs but only two classes
        //are required Board.cs and Cell.cs
        bool gameOver;
        bool playerTurn;
        //1 = red 2 = yellow
        int aiColor;

        //getters
        public int getNumRows()
        {
            return numRows;
        }
        public int getNumCols()
        {
            return numCols;
        }
        //Maybe I want to be able to get an individual cell from the gameboard given row and col
        public Cell getCell(int r, int c)
        {
            return gameBoard[r, c];
        }

        //Maybe we want to be able to view the entire board not just a cell
        public Cell[,] getGameBoard()
        {
            return gameBoard;
        }

        //setters
        //probably want to pass cells to game board not and entire board
        //however, you could definitely pass a full board
        public void setGameBoardCell(Cell cell)
        {
            //the only reason I can do this is because I am going to make sure that I 
            //set the row and col of a cell before I add it to the board
            gameBoard[cell.getRow(), cell.getCol()] = cell;
        }
    }
}
