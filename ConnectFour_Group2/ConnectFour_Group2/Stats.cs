﻿using System;
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
    public partial class Stats : Form
    {
        WelcomePage sform;
        public Stats()
        {
            InitializeComponent();
        }
        public Stats(WelcomePage sf)
        {
            InitializeComponent();
            sform = sf;
        }
    }
}