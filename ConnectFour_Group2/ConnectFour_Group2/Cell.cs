using System.Collections;

namespace ConnectFour_Group2
{
	public class Cell
    {
        public enum value { empty = 0, p1 = 1, p2 = 2 };

        private Cell.value val;
        private RoundButton btn;

        public Cell(Cell.value v, RoundButton b/*, int r, int c */)
        {
            val = v;
            btn = b;
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
