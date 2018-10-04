﻿using CircularGauges;

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

            _hourNeedle = new CGTrapezeNeedle(this);
            AddItem(_hourNeedle, 0);
            _hourNeedle.RLength = 0.7f;
            _hourNeedle.RWidth = 9;
            _hourNeedle.SetDegreeRange(90, -270);
            _hourNeedle.SetValueRange(0, 12);

            _minuteNeedle = new CGTrapezeNeedle(this);
            AddItem(_minuteNeedle,0);
            _minuteNeedle.RLength = 0.9f;
            _minuteNeedle.RWidth = 5;
            _minuteNeedle.SetDegreeRange(90, -270);
            _minuteNeedle.SetValueRange(0, 60);

            _minuteNeedle.CurrentValue = 10;
        }

        private CGTrapezeNeedle _hourNeedle;
        private CGTrapezeNeedle _minuteNeedle;
    }
}
