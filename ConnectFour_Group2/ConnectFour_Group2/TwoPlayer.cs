using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_Group2
{
    public partial class TwoPlayer : Form
    {
        WelcomePage sform;
        public TwoPlayer()
        {
            InitializeComponent();
        }
        public TwoPlayer(WelcomePage sf)
        {
            InitializeComponent();
            sform = sf;
        }
    }
}
