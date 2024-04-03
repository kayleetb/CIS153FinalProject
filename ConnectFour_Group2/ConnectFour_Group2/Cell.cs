using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //need to include this so button can be part of my cell class

namespace CIS153_03_30_2021_Connect4Helper
{
    class Cell
    {
        int row;
        int col;
        Button btn;
        
        //Default Constructor
        public Cell()
        {

        }

        //Overloaded consturctor might be nice
        public Cell(int r, int c, Button button)
        {
            row = r;
            col = c;
            btn = button;
        }

        //getters
        public int getRow()
        {
            return row;
        }
        public int getCol()
        {
            return col;
        }
        public Button getButton()
        {
            return btn;
        }


        //setters
        public void setRow(int r)
        {
            row = r;
        }

        public void setCol(int c)
        {
            col = c;
        }

        public void setBtn(Button b)
        {
            btn = b;
        }
    }
}
