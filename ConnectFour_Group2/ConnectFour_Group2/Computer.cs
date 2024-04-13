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
            move = evalMove(board);
            Console.WriteLine("move: " + move);


            if (board.getCell(5, 3).getVal() == Cell.value.empty)
            {
                Console.WriteLine("comp if");
                board.playMove(Cell.value.Ai, 3);
            }
            else if (move != 9)
            {
                Console.WriteLine("comp else if");
                board.playMove(Cell.value.Ai, move);
            }
            else
            {
                Console.WriteLine("comp else");
                colMove = rnd.Next(0, 6);
                board.playMove(Cell.value.Ai, colMove);
            }
        }

        public int evalMove(Board board)
        {
            Cell[,] internalBoard = new Cell[6, 7];
            Cell cell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            int consecutive = 0;


            //vertical check
            for (int c = 0; c < 7; c++)
            {
                for (int r = 0; r < 6; r++)
                {
                    cell = board.getCell(r, c);

                    if (cell.getVal() == Cell.value.Ai )
                    {
                        break;

                    }
                    else if (cell.getVal() == Cell.value.p1)
                    {
                        coord.row = r;
                        coord.col = c;

                        pattern.Add(coord);

                        consecutive++;

                    }
                    else
                    {
                        pattern.Clear();
                        consecutive = 0;
                    }

                    if (consecutive == 3)
                    {
                        Console.WriteLine("Consecutive 3");

                        if (pattern[0].row == 0)
                        {
                            Console.WriteLine("if");
                            colMove = rnd.Next(0, 6);
                        }
                        else
                        {
                            Console.WriteLine("else" + pattern[0].col);
                            colMove = pattern[0].col;
                        }
                        
                        //if (pattern[2].col == 6)
                        //{
                        //    Console.WriteLine("if");
                        //    //cell = internalBoard[r, pattern[0].col - 1];
                        //    cell = board.getCell(r, pattern[0].col);
                        //    if (cell.getVal() == Cell.value.empty)
                        //    {
                        //        colMove = pattern[0].col;
                        //    }
                        //    else
                        //    {
                        //        colMove = rnd.Next(0, 6);
                                
                        //    }
                        //}
                        //else if (pattern[0].col == 0)
                        //{

                        //    Console.WriteLine("else if");
                        //    //cell = internalBoard[r, pattern[2].col + 1];
                        //    cell = board.getCell(r, pattern[2].col);
                        //    if (cell.getVal() == Cell.value.empty)
                        //    {
                        //        colMove = pattern[2].col;
                        //    }
                        //    else
                        //    {
                        //        colMove = rnd.Next(0, 6);
                        //    }
                        //}
                        //else
                        //{
                        //    Console.WriteLine("else");
                        //    //cell = internalBoard[r, pattern[2].col + 1];
                        //    cell = board.getCell(r, pattern[2].col);
                        //    if (cell.getVal() == Cell.value.empty)
                        //    {
                        //        colMove = pattern[2].col;
                        //    }
                        //    else
                        //    {
                        //        colMove = pattern[2].col;
                        //    }
                        //}
                        return colMove;
                    }
                }
            }

            return 9;
        }
    }
}
