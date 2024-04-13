using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group2
{
    internal class Computer
    {
        private int colMove;
        Random rnd = new Random();


        public void compMove(Board board)
        {
            int move;
            move = evalMove();


            if (board.getCell(5, 3).getVal() == Cell.value.empty)
            {
                board.playMove(Cell.value.Ai, 3);
            }
            else if (move != 0)
            {
                board.playMove(Cell.value.Ai, evalMove());
            }
            else
            {
                colMove = rnd.Next(0, 6);
                board.playMove(Cell.value.Ai, colMove);
            }
        }

        public int evalMove()
        {
            Cell[,] internalBoard = new Cell[6, 7];
            Cell cell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            int consecutive = 0;

            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 7; c++)
                {
                    cell = internalBoard[r, c];

                    if (cell.getVal() == Cell.value.p1)
                    {
                        coord.row = r;
                        coord.col = c;

                        pattern.Add(coord);

                        consecutive++;

                    }

                    if (consecutive == 3)
                    {
                        if (pattern[2].col == 7)
                        {
                            cell = internalBoard[r, pattern[0].col - 1];
                            if (cell.getVal() == Cell.value.empty)
                            {
                                colMove = pattern[0].col - 1;
                            }
                            else
                            {
                                colMove = rnd.Next(0, 6);
                            }
                        }
                        else if (pattern[0].col == 0)
                        {
                            cell = internalBoard[r, pattern[2].col + 1];
                            if (cell.getVal() == Cell.value.empty)
                            {
                                colMove = pattern[2].col + 1;
                            }
                            else
                            {
                                colMove = rnd.Next(0, 6);
                            }
                        }
                        else
                        {
                            cell = internalBoard[r, pattern[2].col + 1];
                            if (cell.getVal() == Cell.value.empty)
                            {
                                colMove = pattern[2].col  + 1;
                            }
                            else
                            {
                                colMove = pattern[2].col - 1;
                            }
                        }
                    }
                }
            }

            return 0;
        }
    }
}
