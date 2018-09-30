using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircularGauges;

namespace BEGaugesDemo.CircularGauges
{
    public partial class ClockControl : CGControl
    {
        public ClockControl()
        {
            InitializeComponent();
            CenterPos = EnumCenterPos.CenterCenter;
            var outArc = new CGArc(this);
            AddItem(outArc,1);
            outArc.RWidth = 10;
            outArc.SetDegreeRange(90, -270);
        }
    }
}
