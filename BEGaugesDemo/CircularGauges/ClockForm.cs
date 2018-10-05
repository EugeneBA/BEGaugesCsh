using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEGaugesDemo.CircularGauges
{
    public partial class ClockForm : Form
    {
        public ClockForm()
        {
            InitializeComponent();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _clockControl.SetTime();
        }
    }
}
