using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group2
{
    class Cell
    {
        int row; 
        int col;
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
        public RoundButton getButton()
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
