using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group2
{
    public class Cell
    {
        private int row; 
        private int col;
        RoundButton btn;
        public Cell()
        {

        }
        public Cell(int r, int c, RoundButton b)
        {
            row = r;
            col = c;    
            btn = b;
        }
        //======GETTERS=========
        public int getRow()
        {
            return row;
        }
        public int getCol()
        {
            return col;
        }
        public RoundButton getBtn()
        {
            return btn;
        }
        //======SETTERS===========
        public void setRow(int r)
        {
            row = r;
        }
        public void setCol(int c)
        {
            col = c;
        }
        public void setBtn(RoundButton b)
        {
            btn = b;
        }
    }

}
