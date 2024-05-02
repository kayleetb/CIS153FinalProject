using System;
using System.Collections.Generic;

namespace ConnectFour_Group2
{
    internal class Computer
    {
        private int move;
        private Random rnd = new Random();


        public int compMove(Board board)
        {


            //computer always takes 5,3 first so player can not get 4 on bottom row (unless player takes it first)
            if (board.getCell(5, 3).getVal() == Cell.value.empty)
            {
                Console.WriteLine("comp if");
				return 3;
            }
            
            if (evalMove(board))
            {
                Console.WriteLine("comp else if");
				return move;
            }
            else 
            {
                Console.WriteLine("comp else");
                return move = rnd.Next(0, 6);

            }

			return -1;
        }

        public bool evalMove(Board board)
        {

            if(vertWin(board))
            {
                return true;
            }
            if(horzWin(board))
            {
                return true;
            }
            if(upperRightWin(board))
            {
                return true;
            }
            if(upperLeftWin(board))
            {
                return true;
            }
            if(vertBlock(board))
            {
                return true;
            }
            if(horzBlock(board))
            {
                return true;
            }
            if (upperRightBlock(board))
            {
                return true;
            }
            if (upperLeftBlock(board))
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

                    if (r - 1 > 0 && cell.getVal() == Cell.value.p1)
                    {
                        coord.row = r;
                        coord.col = c;

                        pattern.Add(coord);

                        cell = board.getCell(r - 1, c);

                        if (r - 2 > 0 && cell.getVal() == Cell.value.p1)
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
                            cell = board.getCell(pattern[2].row - 1, c);

                            if (cell.getVal() == Cell.value.empty)
                            {
                                if (pattern[2].row == 0)
                                {
                                    return false;
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
            bool consecutive = false;



            for(int r = 5; r >= 0; r--) 
            {
                for (int c = 0; c < 7; c++)
                {
                    cell = board.getCell(r, c);

                    if (c + 1 < 7 && cell.getVal() == Cell.value.p1)
                    {
                        pattern.Clear();
                        coord.row = r;
                        coord.col = c;

                        pattern.Add(coord);

                        cell = board.getCell(r, c + 1);

                        if(c + 2 < 7 && cell.getVal() == Cell.value.p1)
                        {
                            coord.row = r;
                            coord.col = c + 1;

                            pattern.Add(coord);

                            cell = board.getCell(r, c + 2);

                            if(cell.getVal() == Cell.value.p1)
                            {
                                coord.row = r;
                                coord.col = c + 2;

                                pattern.Add(coord);

                                consecutive = true;
                            }
                            else
                            {
                                pattern.Clear();
                                consecutive = false;
                            }
                        }
                        else
                        {
                            pattern.Clear();
                            consecutive = false;
                        }

                        if (consecutive)
                        {
                            //checks for block on bottom row
                            if(pattern[0].row == 5)
                            {
                               
                                if(pattern[0].col == 0)
                                {
                                    rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                    if(rCell.getVal() == Cell.value.empty)
                                    {
                                        move = pattern[2].col + 1;
                                        return true;
                                    }
                                    else
                                    {
                                        pattern.Clear();
                                        consecutive = false;
                                    }
                                }
                                else if(pattern[2].col == 6)
                                {
                                    lCell = board.getCell(pattern[0].row, pattern[0].col - 1);

                                    if (lCell.getVal() == Cell.value.empty)
                                    {
                                        move = pattern[0].col - 1;
                                        return true;
                                    }
                                    else
                                    {
                                        pattern.Clear();
                                        consecutive = false;
                                    }
                                }
                                else
                                {
                                    lCell = board.getCell(pattern[0].row, pattern[0].col - 1);
                                    rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                    if (lCell.getVal() == Cell.value.empty)
                                    {
                                        move = pattern[0].col - 1;
                                        return true;
                                    }
                                    else if(rCell.getVal() == Cell.value.empty)
                                    {
                                        move = pattern[2].col + 1;
                                        return true;
                                    }
                                    else
                                    {
                                        pattern.Clear();
                                        consecutive = false;
                                        
                                    }


                                }
                            }
                            //check block if not on bottom row
                            else
                            {
                                if (pattern[0].col == 0)
                                {
                                    rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                    if (rCell.getVal() == Cell.value.empty)
                                    {

                                        rCell = board.getCell(pattern[2].row + 1, pattern[2].col + 1);

                                        if(rCell.getVal() != Cell.value.empty)
                                        {
                                            move = pattern[2].col + 1;
                                            return true;
                                        }
                                        else
                                        {
                                            pattern.Clear();
                                            consecutive = false;
                                        }

                                    }
                                    else
                                    {
                                        pattern.Clear();
                                        consecutive = false;
                                    }
                                }
                                else if (pattern[2].col == 6)
                                {
                                    lCell = board.getCell(pattern[0].row, pattern[0].col - 1);

                                    if (lCell.getVal() == Cell.value.empty)
                                    {
                                        lCell = board.getCell(pattern[0].row + 1, pattern[0].col - 1);

                                        if (lCell.getVal() != Cell.value.empty)
                                        {
                                            move = pattern[0].col - 1;
                                            return true;
                                        }
                                        else
                                        {
                                            pattern.Clear();
                                            consecutive = false;
                                        }
                                    }
                                    else
                                    {
                                        pattern.Clear();
                                        consecutive = false;
                                    }
                                }
                                else
                                {
                                    lCell = board.getCell(pattern[0].row, pattern[0].col - 1);
                                    rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                    if (lCell.getVal() == Cell.value.empty)
                                    {
                                        lCell = board.getCell(pattern[0].row + 1, pattern[0].col - 1);
                                        
                                        if(lCell.getVal() != Cell.value.empty)
                                        {
                                            move = pattern[0].col - 1;
                                            return true;
                                        }


                                    }

                                    if ( rCell.getVal() == Cell.value.empty)
                                    {
                                        rCell = board.getCell(pattern[2].row + 1, pattern[2].col + 1);

                                        if (rCell.getVal() != Cell.value.empty)
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
                }

            }

            return false;
        }

        public bool upperRightBlock(Board board)
        {
            Cell cell;
            Cell lCell;
            Cell rCell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            bool consecutive = false;

            for (int r = 5; r >=0; r--)
            {
                for(int c = 0; c < 7; c++)
                {
                    cell = board.getCell(r, c);

                    if (r - 1 > 1 && c + 1 < 6 && cell.getVal() == Cell.value.p1)
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
                            rCell = board.getCell(pattern[2].row - 1, pattern[2].col + 1);

                            if(rCell.getVal() == Cell.value.empty)
                            {
                                rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                if(rCell.getVal() != Cell.value.empty)
                                {
                                    move = pattern[2].col + 1;
                                    return true;

                                }

                            }

                            if(pattern[0].row < 5)
                            {
                                lCell = board.getCell(pattern[0].row + 1, pattern[0].col - 1);

                                if (lCell.getVal() == Cell.value.empty)
                                {
                                    move = pattern[0].col - 1;
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
            Cell lCell;
            Cell rCell;
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
                        coord.row = r;
                        coord.col = c;
                        pattern.Add(coord);

                        cell = board.getCell(r - 1, c - 1);

                        if(r - 2 > 0 && c - 2 > 0 && cell.getVal() == Cell.value.p1)
                        {

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
                            pattern.Clear();
                        }

                        if (consecutive)
                        {
                            lCell = board.getCell(pattern[2].row - 1, pattern[2].col - 1);

                            if (lCell.getVal() == Cell.value.empty)
                            {
                                lCell = board.getCell(pattern[2].row, pattern[2].col - 1);

                                if (lCell.getVal() != Cell.value.empty)
                                {
                                    move = pattern[2].col - 1;
                                    return true;

                                }

                            }

                            if(pattern[2].row > 5 && pattern[0].col < 7)
                            {
                                rCell = board.getCell(pattern[0].row + 1, pattern[0].col + 1);

                                if (rCell.getVal() == Cell.value.empty)
                                {
                                    move = pattern[0].col + 1;
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

        public bool vertWin(Board board)
        {
            Cell cell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            bool consecutive = false;


            for (int c = 0; c < 7; c++)
            {
                for (int r = 5; r >= 0; r--)
                {
                    cell = board.getCell(r, c);

                    if (r - 1 > 0 && cell.getVal() == Cell.value.ai)
                    {
                        coord.row = r;
                        coord.col = c;

                        pattern.Add(coord);

                        cell = board.getCell(r - 1, c);

                        if (r - 2 > 0 && cell.getVal() == Cell.value.ai)
                        {
                            coord.row = r - 1;
                            coord.col = c;

                            pattern.Add(coord);

                            cell = board.getCell(r - 2, c);

                            if (cell.getVal() == Cell.value.ai)
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

                            cell = board.getCell(pattern[2].row - 1, c);

                            if (cell.getVal() == Cell.value.empty)
                            {
                                if (pattern[2].row == 0)
                                {
                                    return false;
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

        public bool horzWin(Board board)
        {
            Cell cell;
            Cell lCell;
            Cell rCell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            bool consecutive = false;



            for (int r = 5; r >= 0; r--)
            {
                for (int c = 0; c < 7; c++)
                {
                    cell = board.getCell(r, c);

                    if (c + 1 < 7 && cell.getVal() == Cell.value.ai)
                    {
                        pattern.Clear();
                        coord.row = r;
                        coord.col = c;

                        pattern.Add(coord);

                        cell = board.getCell(r, c + 1);

                        if (c + 2 < 7 && cell.getVal() == Cell.value.ai)
                        {
                            coord.row = r;
                            coord.col = c + 1;

                            pattern.Add(coord);

                            cell = board.getCell(r, c + 2);

                            if (cell.getVal() == Cell.value.ai)
                            {
                                coord.row = r;
                                coord.col = c + 2;

                                pattern.Add(coord);

                                consecutive = true;
                            }
                            else
                            {
                                pattern.Clear();
                                consecutive = false;
                            }
                        }
                        else
                        {
                            pattern.Clear();
                            consecutive = false;
                        }

                        if (consecutive)
                        {
                            //checks for block on bottom row
                            if (pattern[0].row == 5)
                            {

                                if (pattern[0].col == 0)
                                {
                                    rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                    if (rCell.getVal() == Cell.value.empty)
                                    {
                                        move = pattern[2].col + 1;
                                        return true;
                                    }
                                    else
                                    {
                                        pattern.Clear();
                                        consecutive = false;
                                    }
                                }
                                else if (pattern[2].col == 6)
                                {
                                    lCell = board.getCell(pattern[0].row, pattern[0].col - 1);

                                    if (lCell.getVal() == Cell.value.empty)
                                    {
                                        move = pattern[0].col - 1;
                                        return true;
                                    }
                                    else
                                    {
                                        pattern.Clear();
                                        consecutive = false;
                                    }
                                }
                                else
                                {
                                    lCell = board.getCell(pattern[0].row, pattern[0].col - 1);
                                    rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                    if (lCell.getVal() == Cell.value.empty)
                                    {
                                        move = pattern[0].col - 1;
                                        return true;
                                    }
                                    else if (rCell.getVal() == Cell.value.empty)
                                    {
                                        move = pattern[2].col + 1;
                                        return true;
                                    }
                                    else
                                    {
                                        pattern.Clear();
                                        consecutive = false;

                                    }


                                }
                            }
                            //check block if not on bottom row
                            else
                            {
                                if (pattern[0].col == 0)
                                {
                                    rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                    if (rCell.getVal() == Cell.value.empty)
                                    {

                                        rCell = board.getCell(pattern[2].row + 1, pattern[2].col + 1);

                                        if (rCell.getVal() != Cell.value.empty)
                                        {
                                            move = pattern[2].col + 1;
                                            return true;
                                        }
                                        else
                                        {
                                            pattern.Clear();
                                            consecutive = false;
                                        }

                                    }
                                    else
                                    {
                                        pattern.Clear();
                                        consecutive = false;
                                    }
                                }
                                else if (pattern[2].col == 6)
                                {
                                    lCell = board.getCell(pattern[0].row, pattern[0].col - 1);

                                    if (lCell.getVal() == Cell.value.empty)
                                    {
                                        lCell = board.getCell(pattern[0].row + 1, pattern[0].col - 1);

                                        if (lCell.getVal() != Cell.value.empty)
                                        {
                                            move = pattern[0].col - 1;
                                            return true;
                                        }
                                        else
                                        {
                                            pattern.Clear();
                                            consecutive = false;
                                        }
                                    }
                                    else
                                    {
                                        pattern.Clear();
                                        consecutive = false;
                                    }
                                }
                                else
                                {
                                    lCell = board.getCell(pattern[0].row, pattern[0].col - 1);
                                    rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                    if (lCell.getVal() == Cell.value.empty)
                                    {
                                        lCell = board.getCell(pattern[0].row + 1, pattern[0].col - 1);

                                        if (lCell.getVal() != Cell.value.empty)
                                        {
                                            move = pattern[0].col - 1;
                                            return true;
                                        }


                                    }

                                    if (rCell.getVal() == Cell.value.empty)
                                    {
                                        rCell = board.getCell(pattern[2].row + 1, pattern[2].col + 1);

                                        if (rCell.getVal() != Cell.value.empty)
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
                }

            }

            return false;
        }

        public bool upperRightWin(Board board)
        {

            Cell cell;
            Cell lCell;
            Cell rCell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            bool consecutive = false;

            for (int r = 5; r >= 0; r--)
            {
                for (int c = 0; c < 7; c++)
                {
                    cell = board.getCell(r, c);

                    if (r - 1 > 1 && c + 1 < 6 && cell.getVal() == Cell.value.ai)
                    {
                        coord.row = r;
                        coord.col = c;
                        pattern.Add(coord);

                        cell = board.getCell(r - 1, c + 1);

                        if (r - 2 > 1 && c + 2 < 6 && cell.getVal() == Cell.value.ai)
                        {
                            coord.row = r - 1;
                            coord.col = c + 1;
                            pattern.Add(coord);

                            cell = board.getCell(r - 2, c + 2);

                            if (cell.getVal() == Cell.value.ai)
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

                        if (consecutive)
                        {
                            rCell = board.getCell(pattern[2].row - 1, pattern[2].col + 1);

                            if (rCell.getVal() == Cell.value.empty)
                            {
                                rCell = board.getCell(pattern[2].row, pattern[2].col + 1);

                                if (rCell.getVal() != Cell.value.empty)
                                {
                                    move = pattern[2].col + 1;
                                    return true;

                                }

                            }

                            if (pattern[0].row < 5)
                            {
                                lCell = board.getCell(pattern[0].row + 1, pattern[0].col - 1);

                                if (lCell.getVal() == Cell.value.empty)
                                {
                                    move = pattern[0].col - 1;
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

        public bool upperLeftWin(Board board)
        {

            Cell cell;
            Cell lCell;
            Cell rCell;
            List<CoordRC> pattern = new List<CoordRC>();
            CoordRC coord;
            bool consecutive = false;


            for (int r = 5; r >= 0; r--)
            {
                for (int c = 0; c < 7; c++)
                {
                    cell = board.getCell(r, c);

                    if (r - 1 > 0 && c - 1 > 0 && cell.getVal() == Cell.value.ai)
                    {
                        coord.row = r;
                        coord.col = c;
                        pattern.Add(coord);

                        cell = board.getCell(r - 1, c - 1);

                        if (r - 2 > 0 && c - 2 > 0 && cell.getVal() == Cell.value.ai)
                        {

                            coord.row = r - 1;
                            coord.col = c - 1;
                            pattern.Add(coord);

                            cell = board.getCell(r - 2, c - 2);

                            if (cell.getVal() == Cell.value.ai)
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
                            pattern.Clear();
                        }

                        if (consecutive)
                        {
                            lCell = board.getCell(pattern[2].row - 1, pattern[2].col - 1);

                            if (lCell.getVal() == Cell.value.empty)
                            {
                                lCell = board.getCell(pattern[2].row, pattern[2].col - 1);

                                if (lCell.getVal() != Cell.value.empty)
                                {
                                    move = pattern[2].col - 1;
                                    return true;

                                }

                            }

                            if (pattern[2].row > 5 && pattern[0].col < 7)
                            {
                                rCell = board.getCell(pattern[0].row + 1, pattern[0].col + 1);

                                if (rCell.getVal() == Cell.value.empty)
                                {
                                    move = pattern[0].col + 1;
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



