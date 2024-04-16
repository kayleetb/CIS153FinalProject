using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour_Group2
{
    internal class Computer
    {
        private int move;
        private  Random rnd = new Random();


        public void compMove(Board board)
        {
            //int move;
            //move = evalMove(board);
            //Console.WriteLine("move: " + move);

            //computer always takes 5,3 first so player can not get 4 on bottom row (unless player takes it first)
            if (board.getCell(5, 3).getVal() == Cell.value.empty)
            {
                Console.WriteLine("comp if");
                board.playMove(Cell.value.Ai, 3);
            }
            else if (horzBlock(board))
            {
                Console.WriteLine("comp else if");
                board.playMove(Cell.value.Ai, move);
            }
            else
            {
                Console.WriteLine("comp else");
                move = rnd.Next(0, 6);
                board.playMove(Cell.value.Ai, move);
            }
        }

        //public int evalMove(Board board)
        //{
        //    //Cell[,] internalBoard = new Cell[6, 7];
        //    Cell cell;
        //    List<CoordRC> pattern = new List<CoordRC>();
        //    CoordRC coord;
        //    int consecutive = 0;


        //    //vertical check
        //    for (int c = 0; c < 7; c++)
        //    {
        //        for (int r = 0; r < 6; r++)
        //        {
        //            cell = board.getCell(r, c);

        //            if (cell.getVal() == Cell.value.Ai )
        //            {
        //                break;

        //            }
        //            else if (cell.getVal() == Cell.value.p1)
        //            {
        //                coord.row = r;
        //                coord.col = c;

        //                pattern.Add(coord);

        //                consecutive++;

        //            }
        //            else
        //            {
        //                pattern.Clear();
        //                consecutive = 0;
        //            }

        //            if (consecutive == 3)
        //            {
        //                Console.WriteLine("Consecutive 3");

        //                if (pattern[0].row == 0)
        //                {
        //                    Console.WriteLine("if");
        //                    colMove = rnd.Next(0, 6);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("else" + pattern[0].col);
        //                    colMove = pattern[0].col;
        //                }
        //                return colMove;
        //            }
        //        }
        //    }

        //    return -1;
        //}

        public bool vertBlock(Board board)
        {
            Cell cell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            int consecutive = 0;


            for (int  c = 0; c < 7; c++)
            {
                for (int r = 5; r >= 0; r--)
                {
                    cell = board.getCell(r, c);

                    if(cell.getVal() == Cell.value.p1)
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

                    if(consecutive == 3)
                    {

                        cell = board.getCell(r - 1, c);

                        if (cell.getVal() == Cell.value.empty)
                        {
                            if (pattern[2].row == 0)
                            {
                                move = rnd.Next(0, 6);
                            }
                            else
                            {
                                move = pattern[2].col;
                            }

                            return true;
                        }
                        else
                        {
                            pattern.Clear();
                            consecutive = 0;
                        }

                    }
                    
                }
            }

            return false;
        }

        public bool horzBlock(Board board)
        {
            Cell cell;
            Cell lCell;
            Cell rCell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            int consecutive = 0;



            for(int r = 5; r >= 0; r--) 
            {
                for (int c = 0; c < 7; c++)
                {
                    cell = board.getCell(r, c);

                    if (cell.getVal() == Cell.value.p1)
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

                        // if consecutive 3 starts at col 0 dont need to check left side of pattern
                        if (pattern[0].col == 0)
                        {

                            Console.WriteLine("0");
                            rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                            if(rCell.getVal() != Cell.value.empty)
                            {
                                pattern.Clear();
                                consecutive = 0;
                                break;
                            }

                            if (pattern[2].row == 0)
                            {
                                if (rCell.getVal() == Cell.value.empty)
                                {
                                    move = pattern[2].col + 1;
                                }
                            }
                            // if consecutive is not on bottom row and down to the right is open dont need to block
                            else
                            {

                                rCell = board.getCell(pattern[2].row + 1, pattern[2].col + 1);
                                if (rCell.getVal() == Cell.value.empty)
                                {
                                    move = rnd.Next(0, 6);
                                }
                                else
                                {
                                    move = pattern[2].col + 1;
                                }
                            }
                        }
                        //if consecutive 3 end at col 6 dont need to check right side of pattern
                        else if (pattern[2].col == 6)
                        {
                            Console.WriteLine("1");
                            lCell = board.getCell(pattern[0].row, pattern[0].col - 1);

                            if (lCell.getVal() != Cell.value.empty)
                            {
                                pattern.Clear();
                                consecutive = 0;
                                break;
                            }

                            if (pattern[0].row == 0)
                            {
                                if (lCell.getVal() == Cell.value.empty)
                                {
                                    move = pattern[0].col - 1;
                                }
                            }
                            else
                            {

                                lCell = board.getCell(pattern[0].row + 1, pattern[0].col - 1);
                                // if consecutive is not on bottom row and down to the left is open dont need to block
                                if (lCell.getVal() == Cell.value.empty)
                                {
                                    move = rnd.Next(0, 6);
                                }
                                else
                                {
                                    move = pattern[0].col - 1;
                                }
                            }
                        }
                        //if 3 consecutive in middle of board need to evaluate both right and left to check for valid move
                        else
                        {
                            Console.WriteLine("2");
                            lCell = board.getCell(pattern[0].row, pattern[0].col - 1);
                            rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                            if (lCell.getVal() != Cell.value.empty )
                            {
                                pattern.Clear();
                                consecutive = 0;
                                break;
                            }
                            else if (rCell.getVal() != Cell.value.empty)
                            {
                                pattern.Clear();
                                consecutive = 0;
                                break;
                            }
                           
                            //if the computer is doing its job you should never be here but need to check just in case (see line 24)
                            if (pattern[0].row == 0)
                            {

                                if (lCell.getVal() == Cell.value.empty)
                                {
                                    move = pattern[0].col - 1;
                                }
                                else if (rCell.getVal() == Cell.value.empty)
                                {
                                    move = pattern[2].col + 1;
                                }
                                else
                                {
                                    move = rnd.Next(0, 6);
                                }
                            }
                            //if not on bottom row check down diagonal to see if computer should block
                            else
                            {
                                lCell = board.getCell(pattern[0].row + 1, pattern[0].col - 1);
                                rCell = board.getCell(pattern[2].row + 1, pattern[2].col + 1);

                                if (lCell.getVal() == Cell.value.empty)
                                {
                                    Console.WriteLine("left");
                                    if (rCell.getVal() == Cell.value.empty)
                                    {
                                        Console.WriteLine("right");
                                        move = rnd.Next(0, 6);
                                    }
                                    else
                                    {
                                        move = pattern[2].col + 1;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("move");
                                    move = pattern[0].col - 1;
                                }
                            }
                        }
                        return true;
                    }
                }

            }

            return false;
        }
    }
}
