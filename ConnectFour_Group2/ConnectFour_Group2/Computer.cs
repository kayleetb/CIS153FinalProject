using System;
using System.Collections.Generic;

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
                board.playMove(Cell.value.ai, 3);
            }
            else if (evalMove(board))
            {
                Console.WriteLine("comp else if");
                board.playMove(Cell.value.ai, move);
            }
            else
            {
                Console.WriteLine("comp else");
                //move = rnd.Next(0, 6);
                //board.playMove(Cell.value.ai, move);
            }
        }

        public bool evalMove(Board board)
        {
            if(vertBlock(board))
            {
                return true;
            }
            if(horzBlock(board))
            {
                return true;
            }
            if(upperRightBlock(board))
            {
                return true;
            }
            if(upperLeftBlock(board))
            {
                return true;
            }
            
            return false;
        }

        public bool vertBlock(Board board)
        {
            Cell cell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            bool consecutive = false;


            for (int  c = 0; c < 7; c++)
            {
                for (int r = 5; r >= 0; r--)
                {
                    cell = board.getCell(r, c);

                    if (cell.getVal() == Cell.value.p1)
                    {
                        coord.row = r;
                        coord.col = c;

                        pattern.Add(coord);

                        cell = board.getCell(r - 1, c);

                        if (cell.getVal() == Cell.value.p1)
                        {
                            coord.row = r - 1;
                            coord.col = c;

                            pattern.Add(coord);

                            cell = board.getCell(r - 2, c);

                            if (cell.getVal() == Cell.value.p1)
                            {

                                coord.row = r - 2;
                                coord.col = c;

                                pattern.Add(coord);

                                consecutive = true;
                            }
                            else
                            {
                                pattern.Clear();
                            }
                        }
                        else
                        {
                            pattern.Clear();
                        }

                        if (consecutive)
                        {
                            Console.WriteLine("Consecutive");
                            cell = board.getCell(pattern[2].row - 1, c);

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
                                consecutive = false;
                            }

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

        public bool upperRightBlock(Board board)
        {

            Cell cell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            bool consecutive = false;

            for (int r = 5; r >=0; r--)
            {
                for(int c = 0; c < 7; c++)
                {
                    cell = board.getCell(r, c);

                    if (r-1 > 1 && c + 1 < 6 && cell.getVal() == Cell.value.p1)
                    {
                        coord.row = r;
                        coord.col = c;
                        pattern.Add(coord);

                        cell = board.getCell(r - 1, c + 1);

                        if(r - 2 > 1 && c + 2 < 6 && cell.getVal() == Cell.value.p1)
                        {
                            coord.row = r - 1;
                            coord.col = c + 1;
                            pattern.Add(coord);

                            cell = board.getCell(r - 2, c + 2);

                            if(cell.getVal() == Cell.value.p1)
                            {
                                coord.row = r - 2;
                                coord.col = c + 2;
                                pattern.Add(coord);

                                consecutive = true;
                            }
                            else
                            {
                                pattern.Clear();
                                
                            }
                        }
                        else
                        {
                            pattern.Clear();
                            
                        }

                        if(consecutive)
                        {
                            cell = board.getCell(pattern[2].row - 1, pattern[2].col + 1);

                            if(cell.getVal() == Cell.value.empty)
                            {
                                cell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                if(cell.getVal() == Cell.value.empty)
                                {
                                    pattern.Clear();
                                    consecutive = false;
                                    
                                }
                                else
                                {
                                    move = pattern[2].col + 1;
                                    return true;
                                }
                            }
                            else
                            {
                                pattern.Clear();
                                consecutive = false;
                                
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool upperLeftBlock(Board board)
        {

            Cell cell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            bool consecutive = false;


            for(int r = 5; r >= 0; r--)
            {
                for(int c = 0; c < 7; c++)
                {
                    cell = board.getCell(r, c);

                    if(r - 1 > 0 && c - 1 > 0 && cell.getVal() == Cell.value.p1)
                    {
                        Console.WriteLine("R: " + r + ", C: "+ c);

                        coord.row = r;
                        coord.col = c;
                        pattern.Add(coord);

                        cell = board.getCell(r - 1, c - 1);

                        if(r - 2 > 0 && c - 2 > 0 && cell.getVal() == Cell.value.p1)
                        {
                            Console.WriteLine("R2: " + (r - 1)+ ", C2: " + (c - 1));

                            coord.row = r - 1;
                            coord.col = c - 1;
                            pattern.Add(coord);

                            cell = board.getCell(r - 2, c - 2);

                            if (cell.getVal() == Cell.value.p1)
                            {
                                coord.row = r - 2;
                                coord.col = c - 2;
                                pattern.Add(coord);

                                consecutive = true;
                            }
                            else
                            {
                                pattern.Clear();
                            }

                        }
                        else
                        {
                            Console.WriteLine("Clear");
                            pattern.Clear();
                        }

                        if (consecutive)
                        {
                            Console.WriteLine("consecutive");

                            cell = board.getCell(pattern[2].row - 1, pattern[2].col - 1);

                            if (cell.getVal() == Cell.value.empty)
                            {
                                cell = board.getCell(pattern[2].row, pattern[2].col - 1);

                                if (cell.getVal() == Cell.value.empty)
                                {
                                    pattern.Clear();
                                    consecutive = false;
                                    
                                }
                                else
                                {
                                    move = pattern[2].col - 1;
                                    return true;
                                }
                            }
                            else
                            {
                                pattern.Clear();
                                consecutive = false;
                                
                            }
                        }

                    }
                }

            }

            return false;
        }
    }
}



