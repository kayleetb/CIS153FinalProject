namespace ConnectFour_Group2
{
	class Cell
    {
        public enum value { empty = 0, p1 = 1, p2 = 2 };


        private Cell.value val;
        private int row, col; /* Row and column are only able to be set in the constructor. */
        RoundButton btn;


        public Cell(Cell.value v, RoundButton b, int r, int c)
        {
            val = v;
            btn = b;
            row = r;
            col = c;
        }

        //======GETTERS=========
        public RoundButton getBtn()
        {
            return btn;
        }

        public Cell.value getVal()
        {
            return val;
        }

        public int getRow()
        {
            return row;
        }

        public int getCol()
        {
            return col;
        }

        //======SETTERS===========
        public void setBtn(RoundButton b)
        {
            btn = b;
        }

        public void setVal(Cell.value v)
        {
            val = v;
        }
    }

}
