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

            var ticks = new CGTicks(this);
            AddItem(ticks,0.97f);
            ticks.RLength = 0.03f;
            ticks.SetDegreeRange(90, -270);
            ticks.SetValueRange(0, 60);
            ticks.Step = 1;

            var bigTicks = new CGTicks(this);
            AddItem(bigTicks, 0.95f);
            bigTicks.RLength = 0.05f;
            bigTicks.RWidth = 5;
            bigTicks.SetDegreeRange(90, -270);
            bigTicks.SetValueRange(0, 12);
            bigTicks.Step = 1;

            var vals = new CGValues(this);
            AddItem(vals, 0.85f);
            vals.SetDegreeRange(60, -270);
            vals.SetValueRange(1, 12);
            vals.Step =1;
            vals.RFontSize = 38;
        }
    }
}
